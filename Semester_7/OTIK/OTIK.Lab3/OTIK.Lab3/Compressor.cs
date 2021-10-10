using System;
using System.Collections.Generic;
using System.IO;

namespace OTIK.Lab3
{
    class Compressor
    {
        string inputDir;
        string outputDir;
        public Compressor(string inputDir, string outputDir)
        {
            this.inputDir = inputDir;
            this.outputDir = outputDir;
        }

        public void Compress(string archiveName, bool compress)
        {

        }

        public void Extract()
        {

        }

        public void getFiles()
        {
            string[] filePaths = Directory.GetFiles(@".\input\");

            foreach (string s in filePaths)
            {
                byte[] fileContent = File.ReadAllBytes(s);
                Console.WriteLine(s);
                string[] hexFileContent = BitConverter.ToString(fileContent).Split('-');

                for (int i = 0; i < hexFileContent.Length; i++)
                {
                    Console.Write(hexFileContent[i] + ' ');
                    if ((i + 1) % 16 == 0)
                        Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public void Encrypt()
        {

        }

        public void Decrypt()
        {
            
        }
    }
}
