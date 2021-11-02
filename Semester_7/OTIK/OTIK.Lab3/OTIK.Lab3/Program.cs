using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTIK.Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region gay party
            string[] filePaths = Directory.GetFiles(@".\input\");


            foreach (string s in filePaths)
            {
                byte[] fileContent = File.ReadAllBytes(s);

                byte[] fileLen = BitConverter.GetBytes(fileContent.Length);

                string[] hexFileContent = BitConverter.ToString(fileContent).Split('-');

                for (int i = 0; i < hexFileContent.Length; i++)
                {
                    Console.Write(fileContent[i].ToString() + ' ');
                    if ((i + 1) % 16 == 0)
                        Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion

            Compressor compressor = new Compressor(@".\input\", @".\output\");
            compressor.getFiles();




            Console.ReadKey();
        }
    }
}
