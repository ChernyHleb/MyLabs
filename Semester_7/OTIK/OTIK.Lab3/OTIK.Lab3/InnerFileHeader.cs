using System.Collections.Generic;

namespace OTIK.Lab3
{
    class InnerFileHeader
    {
        public static readonly int size = 128;
        public byte[] signature = new byte[4];
        public byte[] compressedSize = new byte[4];
        public byte[] uncompressedSize = new byte[4];
        public byte fileNameLength;
        public byte[] symTableOffset = new byte[4];
        public byte[] fileDataOffset = new byte[4];
        public byte[] fileName = new byte[104];
        public byte[] tail = new byte[3];

        public InnerFileHeader() { }

        public List<byte> ToBytes()
        {
            List<byte> arr = new List<byte>();
            foreach (byte b in signature) arr.Add(b);
            foreach (byte b in compressedSize) arr.Add(b);
            foreach (byte b in uncompressedSize) arr.Add(b);
            arr.Add(fileNameLength);
            foreach (byte b in symTableOffset) arr.Add(b);
            foreach (byte b in fileDataOffset) arr.Add(b);
            foreach (byte b in fileName) arr.Add(b);
            foreach (byte b in tail) arr.Add(b);

            return arr;
        }
    }
}
