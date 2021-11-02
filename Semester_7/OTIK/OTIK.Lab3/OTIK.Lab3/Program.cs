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
            //Compressor compressor = new Compressor(@".\input\", @".\output\");
            //compressor.getFiles();



            #region gay party
            string[] filePaths = Directory.GetFiles(@".\input\");


            foreach (string s in filePaths)
            {
                
                Console.WriteLine(filename);
                byte[] fileContent = File.ReadAllBytes(s);

                byte[] fileLen = BitConverter.GetBytes(fileContent.Length);

                string[] hexFileContent = BitConverter.ToString(fileContent).Split('-');

                for (int i = 0; i < hexFileContent.Length; i++)
                {
                    Console.Write(hexFileContent[i] + ' ');
                    if ((i + 1) % 16 == 0)
                        Console.WriteLine();
                }

                Console.WriteLine();

                //239 187 191

                for (int i = 0; i < fileContent.Length; i++)
                {
                    Console.Write((fileContent[i]).ToString() + ' ');
                }

                //break;
                Console.WriteLine();
            }
            #endregion

            Console.ReadKey();
        }
    }
}
