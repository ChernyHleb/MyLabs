using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTIK.Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Compressor compressor = new Compressor(null, null);
            compressor.getFiles();
        }
    }
}
