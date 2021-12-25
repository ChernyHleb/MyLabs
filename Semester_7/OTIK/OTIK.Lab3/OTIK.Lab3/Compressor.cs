using OTIK.Lab3.Lab4_ShannonFano;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OTIK.Lab3
{
    class Compressor
    {
        string inputDir;
        string outputDir;

        public List<InnerFile> filesToCompress = new List<InnerFile>();
        public List<VSAS> filesToExtract = new List<VSAS>();
        Random rnd = new Random();

        public Compressor(string inputDir, string outputDir)
        {
            this.inputDir = inputDir;
            this.outputDir = outputDir;
        }

        public VSAS FormVSAS()
        {
            VSAS_Header header = new VSAS_Header();
            header.algNumContextCompression = 0;
            header.algNumEntropyCompression = 0;
            header.algNumNoiseProtection = 0;
            header.algNumEncryption = 0;
            header.filesAmount = BitConverter.GetBytes(filesToCompress.Count)[0];

            return new VSAS(header, filesToCompress);
        }

        public void Archive(VSAS fileArchive, string name, bool encrypt, int compress)
        {
            if (encrypt)
                fileArchive.header.algNumEncryption = 1;
            else
                fileArchive.header.algNumEncryption = 0;

            if (compress == 1)
                fileArchive.header.algNumContextCompression = 1;
            else
            if (compress == 0)
                fileArchive.header.algNumContextCompression = 0;
            else
            if (compress == 2)
                fileArchive.header.algNumContextCompression = 2;

            if (compress != 0)
                Console.WriteLine("INPUT FILES COMPRESSION");
            if (encrypt)
                Console.WriteLine("INPUT FILES ENCRYPTION");
            Console.WriteLine("TO:");

            // ЗАШИФРОВКА И УПАКОВКА
            List<byte> arr = new List<byte>();
            arr.AddRange(fileArchive.header.ToBytes());
            foreach(InnerFile file in fileArchive.files)
            {
                if(encrypt) Encrypt(file);
                if (compress == 1) CompressWithFano(file);
                if (compress == 2) CompressWithArythmetic(file);

                arr.AddRange(file.header.ToBytes());
                if (encrypt) arr.AddRange(file.encryptionHeader);
                if (compress == 1) arr.AddRange(file.symCodeTable);


                arr.AddRange(file.data);
            }

            string archivePath = outputDir + name;
            Console.WriteLine(archivePath);
            File.WriteAllBytes(archivePath, arr.ToArray());
        }

        public void Extract(VSAS fileArchive)
        {
            Console.WriteLine("EXTRACTED FILES:");
            foreach(InnerFile file in fileArchive.files)
            {
                string filepath = outputDir;
                foreach (byte b in file.header.fileName.Take(file.header.fileNameLength).ToArray())
                    filepath += (char)b;
                Console.WriteLine(filepath);
                File.WriteAllBytes(filepath, file.data);
            }
        }

        public void getFiles()
        {
            string[] filePaths = Directory.GetFiles(this.inputDir);

            foreach(string s in filePaths)
            {
                byte[] fileContent = File.ReadAllBytes(s);
                string fileName = s.Split('\\')[s.Split('\\').Length - 1];
                //if (fileContent.Length >= 3 &&
                //    fileContent[0] == 239 &&
                //    fileContent[1] == 187 &&
                //    fileContent[2] == 191)
                //{
                if(fileContent.Length >= 4 &&
                    fileContent[0] == (byte)'V' &&
                    fileContent[1] == (byte)'S' &&
                    fileContent[2] == (byte)'A' &&
                    fileContent[3] == (byte)'S')
                {
                    filesToExtract.Add(BytesToVSAS(fileContent));
                }
                else
                {
                    filesToCompress.Add(TxtToInnerFile(fileContent, fileName));
                }
            }
        }

        private InnerFile TxtToInnerFile(byte[] file, string filename)
        {
            //  заполнение сигнатуры
            //  UTF8 signature EF BB BF <--> 239 187 191
            InnerFileHeader innerFileHeader = new InnerFileHeader();
            //innerFileHeader.signature[0] = 0;
            //innerFileHeader.signature[1] = 239;
            //innerFileHeader.signature[2] = 187;
            //innerFileHeader.signature[3] = 191;
            // размер файла
            innerFileHeader.uncompressedSize = BitConverter.GetBytes(file.Length);
            // заполнение имени и длины имени
            byte[] byteFileName = Encoding.UTF8.GetBytes(filename);
            innerFileHeader.fileNameLength = BitConverter.GetBytes(byteFileName.Length)[0];
            for (int i = 0; i < innerFileHeader.fileNameLength; i++)
            {
                innerFileHeader.fileName[i] = byteFileName[i];
            }
            // ВРЕМЕННО заполнение смещения данных
            innerFileHeader.fileDataOffset = BitConverter.GetBytes(InnerFileHeader.size);

            return new InnerFile(innerFileHeader, null, null, file);
        }
        
        /// РАСШИФРОВКА ЗДЕСЬ!!! VVV
        private VSAS BytesToVSAS(byte[] file)
        {
            //VSAS archive = new VSAS();
            VSAS_Header archiveHeader = new VSAS_Header();
            List<InnerFile> innerFiles = new List<InnerFile>();
            int counter = 4;

            archiveHeader.algNumEntropyCompression = file[counter];
            counter++;
            archiveHeader.algNumContextCompression = file[counter];
            counter++;
            archiveHeader.algNumNoiseProtection = file[counter];
            counter++;
            archiveHeader.algNumEncryption = file[counter];
            counter++;
            archiveHeader.filesAmount = file[counter];
            counter++;
            archiveHeader.tail = file.Skip(counter).Take(7).ToArray();
            counter += 7;

            for(int i = 0; i < archiveHeader.filesAmount; i++)
            {
                InnerFileHeader innerFileHeader = new InnerFileHeader();
                innerFileHeader.signature = file.Skip(counter).Take(4).ToArray();
                counter += 4;
                innerFileHeader.compressedSize = file.Skip(counter).Take(4).ToArray();
                counter += 4;
                innerFileHeader.uncompressedSize = file.Skip(counter).Take(4).ToArray();
                counter += 4;
                innerFileHeader.fileNameLength = file[counter];
                counter ++;
                innerFileHeader.symTableOffset = file.Skip(counter).Take(4).ToArray();
                counter += 4;
                innerFileHeader.fileDataOffset = file.Skip(counter).Take(4).ToArray();
                counter += 4;
                innerFileHeader.fileName = file.Skip(counter).Take(104).ToArray();
                counter += 104;
                innerFileHeader.tail = file.Skip(counter).Take(3).ToArray();
                counter += 3;

                byte[] encryptionHeader = null;
                if(archiveHeader.algNumEncryption == 1)
                {
                    int len = BitConverter.ToInt32(innerFileHeader.symTableOffset, 0);
                    encryptionHeader = file.Skip(counter).Take(len).ToArray();
                    counter += len;
                }

                byte[] symCodeTable = null;
                if (archiveHeader.algNumContextCompression == 1)
                {
                    int len = BitConverter.ToInt32(innerFileHeader.fileDataOffset, 0);
                    symCodeTable = file.Skip(counter).Take(len).ToArray();
                    counter += len;
                }


                    Dictionary<string, byte> codeSym = new Dictionary<string, byte>();
                // формирование таблицы кодов в виде словаря
                if (archiveHeader.algNumContextCompression == 1)
                {
                    int scCounter = 0;
                    while(scCounter < symCodeTable.Length)
                    {
                        byte sym = symCodeTable.Skip(scCounter).Take(1).ToArray()[0];
                        scCounter++;
                        int len = symCodeTable.Skip(scCounter).Take(1).ToArray()[0];
                        scCounter++;
                        byte[] code = symCodeTable.Skip(scCounter).Take(len).ToArray();
                        scCounter += len;

                        string strcode = "";
                        foreach (byte b in code)
                        {
                            strcode += (char)b;
                        }
                        codeSym.Add(strcode, sym);
                    }
                }

                int dataSize = 0;
                byte[] data = null;



                byte[] uncompressedData = null;
                int uncompressedDataCounter = 0;
                //Расшифровка Фано РАЗЖАТИЕ :)
                if (archiveHeader.algNumContextCompression == 1)
                {
                    List<byte> uncompressedDataList = new List<byte>();
                    dataSize = BitConverter.ToInt32(innerFileHeader.compressedSize, 0);

                    BitArray bits = new BitArray(file.Skip(counter).Take(dataSize).ToArray());
                    counter += dataSize;
                    
                    string code = "";
                    foreach(bool bit in bits)
                    {
                        if (bit == true)
                            code += '1';
                        else
                            code += '0';
                       
                        if(codeSym.ContainsKey(code))
                        {
                            uncompressedDataList.Add(codeSym[code]);
                            code = "";
                        }
                    }

                    innerFileHeader.compressedSize = BitConverter.GetBytes(uncompressedDataList.Count);
                    uncompressedData = uncompressedDataList.ToArray();
                }
                else if (archiveHeader.algNumContextCompression == 2)
                {
                    List<byte> newData = new List<byte>();
                    dataSize = BitConverter.ToInt32(innerFileHeader.compressedSize, 0);
                    List<byte> oldData = new List<byte>();
                    oldData.AddRange(file.Skip(counter).Take(dataSize).ToArray());
                    counter += dataSize;

                    for(int c = 0; c < oldData.Count; c++)
                    {
                        if (oldData[c] == (byte)'^')
                        {
                            int amount = oldData[c + 1];
                            byte b = oldData[c + 2];
                            for (int c2 = 0; c2 < amount; c2++)
                                newData.Add(b);
                            c += 2;
                        }
                        else newData.Add(oldData[c]);
                    }

                    data = newData.ToArray();
                }

                if (archiveHeader.algNumEncryption == 1)
                {/// РАСШИФРОВКА ДАННЫХ
                    List<byte> encryptedData = new List<byte>();
                    dataSize = BitConverter.ToInt32(innerFileHeader.compressedSize, 0);
                    foreach(byte blockLen in encryptionHeader)
                    {
                        if(archiveHeader.algNumContextCompression != 1)
                        {
                            encryptedData.AddRange(file.Skip(counter).Take(blockLen).ToArray());
                            counter += blockLen + 5;
                        }
                        else
                        {
                            encryptedData.AddRange(uncompressedData.Skip(uncompressedDataCounter).Take(blockLen).ToArray());
                            uncompressedDataCounter += blockLen + 5;
                        }
                    }

                    data = encryptedData.ToArray();
                }
                else
                {
                    dataSize = BitConverter.ToInt32(innerFileHeader.uncompressedSize, 0);
                    data = new byte[dataSize];
                    data = file.Skip(counter).Take(dataSize).ToArray();
                    counter += dataSize;
                }

                innerFiles.Add(new InnerFile(innerFileHeader, encryptionHeader, null, data));
            }

            return new VSAS(archiveHeader, innerFiles);
        }
        
        protected void Encrypt(InnerFile file)
        {
            int dataSize = BitConverter.ToInt32(file.header.uncompressedSize, 0);
            List<byte> data = new List<byte>(file.data);
            List<byte> encryptionHeader = new List<byte>();
            List<byte> encryptedData = new List<byte>();
            int blockCounter = 0;

            for (int counter = 0; counter < dataSize; blockCounter++)
            {
                int blockLength = rnd.Next(1, 17);
                if (counter + blockLength > dataSize)
                    blockLength = dataSize - counter;
                encryptionHeader.Add((byte)blockLength);
                encryptedData.AddRange(data.GetRange(counter, blockLength));
                counter += blockLength; // индекс исходных данных
                encryptedData.Add((byte)'q');
                // 4 байта отвечают за порядковый номер блока
                encryptedData.AddRange(BitConverter.GetBytes(blockCounter)); 
            }

            file.data = encryptedData.ToArray();
            file.encryptionHeader = encryptionHeader.ToArray();
            file.header.compressedSize = BitConverter.GetBytes(encryptedData.Count);
            file.header.fileDataOffset = BitConverter.GetBytes(encryptionHeader.Count);
            file.header.symTableOffset = BitConverter.GetBytes(encryptionHeader.Count);
        }

        protected void CompressWithFano(InnerFile file)
        {
            int dataSize = 0;

            int compressedSize = BitConverter.ToInt32(file.header.compressedSize, 0);
            if (compressedSize == 0)
                dataSize = BitConverter.ToInt32(file.header.uncompressedSize, 0);
            else
                dataSize = compressedSize;

            List<byte> data = new List<byte>(file.data);
            ShannonFano sfc = new ShannonFano(data);
            Dictionary<byte, string> symCode = sfc.GetTable();

            // конвертируем таблицу кодов в массив
            // первый байт - символ
            // второй байт - длина кода символа
            // последовательность байтов - код символа
            List<byte> symCodeArr = new List<byte>();
            foreach (KeyValuePair<byte, string> entry in symCode)
            {
                symCodeArr.Add(entry.Key);
                symCodeArr.Add(Convert.ToByte(entry.Value.Length));
                symCodeArr.AddRange(Encoding.UTF8.GetBytes(entry.Value));
            }
            file.symCodeTable = symCodeArr.ToArray();

            //
            // переводим исходные данные в массив битов //
            //
            List<bool> compressedData = new List<bool>();
            foreach(byte b in file.data)
            {
                //Console.Write((char)b);
                foreach(char c in symCode[b])
                {
                    if (c == '1')
                        compressedData.Add(true);
                    else
                        compressedData.Add(false);
                }
            }
            BitArray bits = new BitArray(compressedData.ToArray());
            //
            // затем переводим биты в байты //
            // 
            byte[] newData = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(newData, 0);

            file.data = newData;
            file.header.compressedSize = BitConverter.GetBytes(newData.Length);
            file.header.fileDataOffset = BitConverter.GetBytes(file.symCodeTable.Length);
        }

        protected void CompressWithArythmetic(InnerFile file)
        {
            int dataSize = 0;

            int compressedSize = BitConverter.ToInt32(file.header.compressedSize, 0);
            if (compressedSize == 0)
                dataSize = BitConverter.ToInt32(file.header.uncompressedSize, 0);
            else
                dataSize = compressedSize;

            List<byte> newdata = new List<byte>();
            List<byte> data = new List<byte>(file.data);

            for (int i = 0; i < data.Count; i++)
            {
                byte symcounter = 1;
                for (int j = i + 1; j < data.Count; j++)
                {
                    if (data[j] == data[i])
                    {
                        symcounter++;
                        i = j;
                    }
                    else
                        break;
                }

                if(symcounter > 1)
                {
                    //newdata.Add((byte)'^');
                    newdata.Add(symcounter);
                }
                newdata.Add(data[i]);
            }

            file.data = newdata.ToArray();
            file.header.compressedSize = BitConverter.GetBytes(newdata.Count);
        }
    }
}
