using System.Collections.Generic;

namespace OTIK.Lab3
{
    class VSAS_Header
    {
        public static readonly int size = 16;
        public byte[] signature = new byte[4];
        public byte algNumEntropyCompression;
        public byte algNumContextCompression;
        public byte algNumNoiseProtection;
        public byte algNumEncryption;
        public byte filesAmount;
        public byte[] tail = new byte[7];

        public VSAS_Header() 
        {
            this.signature[0] = (byte)'V';
            this.signature[1] = (byte)'S';
            this.signature[2] = (byte)'A';
            this.signature[3] = (byte)'S';
        }

        public List<byte> ToBytes()
        {
            List<byte> arr = new List<byte>();
            foreach (byte b in signature) arr.Add(b);
            arr.Add(algNumEntropyCompression);
            arr.Add(algNumContextCompression);
            arr.Add(algNumNoiseProtection);
            arr.Add(algNumEncryption);
            arr.Add(filesAmount);
            foreach (byte b in tail) arr.Add(b);
            return arr;
        }
    }
}
