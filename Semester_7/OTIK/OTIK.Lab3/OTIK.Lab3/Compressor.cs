using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OTIK.Lab3
{
    class Compressor
    {
        string inputDir;
        string outputDir;

        List<InnerFile> innerFiles = new List<InnerFile>();

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
            header.filesAmount = BitConverter.GetBytes(innerFiles.Count)[0];

            return new VSAS(header, innerFiles);
        }

        public void Compress(VSAS fileArchive, string name)
        {
            List<byte> arr = new List<byte>();
            arr.AddRange(fileArchive.header.ToBytes());
            foreach(InnerFile file in fileArchive.files)
            {
                arr.AddRange(file.header.ToBytes());
                arr.AddRange(file.data);
            }

            string archivePath = outputDir + name;
            File.WriteAllBytes(archivePath, arr.ToArray());
        }

        public void Extract()
        {

        }

        public void getFiles()
        {
            string[] filePaths = Directory.GetFiles(this.inputDir);

            foreach(string s in filePaths)
            {
                byte[] fileContent = File.ReadAllBytes(s);
                string fileName = s.Split('\\')[s.Split('\\').Length - 1];
                innerFiles.Add(ToInnerFile(fileContent, fileName));                
            }
        }

        private InnerFile ToInnerFile(byte[] file, string filename)
        {
            // определение и заполнение сигнатуры
            //UTF8 signature EF BB BF <--> 239 187 191
            InnerFileHeader innerFileHeader = new InnerFileHeader();
            if(file.Length >= 3 && 
               file[0] == 239 && 
               file[1] == 187 && 
               file[2] == 191)
            {
                innerFileHeader.signature[0] = 0;
                innerFileHeader.signature[1] = 239;
                innerFileHeader.signature[2] = 187;
                innerFileHeader.signature[3] = 191;
            }
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

        //public void FilesToConsole(string s)
        //{
        //    Console.WriteLine(s);
        //    string[] hexFileContent = BitConverter.ToString(fileContent).Split('-');

        //    for (int i = 0; i < hexFileContent.Length; i++)
        //    {
        //        Console.Write(hexFileContent[i] + ' ');
        //        if ((i + 1) % 16 == 0)
        //            Console.WriteLine();
        //    }
        //    Console.WriteLine();
        //}
        
        /*
        public InnerFile Encrypt(byte[] file)
        {
            return null;
        }

        public void Decrypt()
        {
            
        }
        */
    }
}
