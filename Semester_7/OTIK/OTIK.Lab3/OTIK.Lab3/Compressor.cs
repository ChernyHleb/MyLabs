using OTIK.Lab3.Lab4_ShannonFano;
using System;
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

        public void Archive(VSAS fileArchive, string name, bool encrypt, bool compress)
        {
            if (encrypt)
                fileArchive.header.algNumEncryption = 1;
            else
                fileArchive.header.algNumEncryption = 0;

            if (compress)
                fileArchive.header.algNumContextCompression = 1;
            else
                fileArchive.header.algNumContextCompression = 0;

            if(compress)
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
                arr.AddRange(file.header.ToBytes());
                if (encrypt) arr.AddRange(file.encryptionHeader);
                arr.AddRange(file.data);

                if(compress)
                {
                    ShannonFanoCompressor sfc = new ShannonFanoCompressor();
                    sfc.Sort();
                    sfc.Fano(0, 32);
                    for (int i = 0; i < 33; i++)
                    {
                        Console.WriteLine(sfc.Alpha[i] + " " + sfc.Res[i]);
                    }

                    Console.ReadKey();
                }
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

            return new InnerFile(innerFileHeader, null, file);
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
                innerFileHeader.encryptionInfoHeaderOffset = file.Skip(counter).Take(4).ToArray();
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
                    int len = BitConverter.ToInt32(innerFileHeader.fileDataOffset, 0);
                    encryptionHeader = file.Skip(counter).Take(len).ToArray();
                    counter += len;
                }

                int dataSize = 0;
                byte[] data = null;
                if (archiveHeader.algNumEncryption == 1)
                {/// РАСШИФРОВКА ДАННЫХ
                    List<byte> encryptedData = new List<byte>();
                    dataSize = BitConverter.ToInt32(innerFileHeader.compressedSize, 0);
                    foreach(byte blockLen in encryptionHeader)
                    {
                        encryptedData.AddRange(file.Skip(counter).Take(blockLen).ToArray());
                        counter += blockLen + 5;
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

                innerFiles.Add(new InnerFile(innerFileHeader, encryptionHeader, data));
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
            file.header.encryptionInfoHeaderOffset = BitConverter.GetBytes(InnerFileHeader.size);
        }

        protected void Compress(InnerFile file)
        {
            int dataSize = 0;

            int compressedSize = BitConverter.ToInt32(file.header.compressedSize, 0);
            if (compressedSize == 0)
                dataSize = BitConverter.ToInt32(file.header.uncompressedSize, 0);
            else
                dataSize = compressedSize;



            List<byte> data = new List<byte>(file.data);
        }
    }
}
