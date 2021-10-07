using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTIK.Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] filePaths = Directory.GetFiles(@".\Тексты\");
            string savePath1 = @".\SymFreq\";
            string savePath2 = @".\ByteFreq\";

            foreach (string s in filePaths)
            {
                TextData d = new TextData(File.ReadAllText(s), File.ReadAllBytes(s));
                File.WriteAllText(savePath1 + (s.Split('\\'))[s.Split('\\').Length - 1], d.GetTextResult());
                File.WriteAllText(savePath2 + (s.Split('\\'))[s.Split('\\').Length - 1], d.GetBytesResult());
                Console.WriteLine(s);
            }

            string[] piecesPaths = Directory.GetFiles(@".\Фрагменты\");
            string savePiecesPath = @".\PiecesFreq\";

            foreach (string s in piecesPaths)
            {
                TextData d = new TextData();
                File.WriteAllText(savePiecesPath + (s.Split('\\'))[s.Split('\\').Length - 1], d.GetPiecesResult(File.ReadAllText(s)));
                Console.WriteLine(s);
            }
            Console.ReadKey();
            
        }
    }
}
