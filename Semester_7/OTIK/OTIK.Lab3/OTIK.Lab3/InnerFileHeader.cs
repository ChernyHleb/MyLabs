namespace OTIK.Lab3
{
    class InnerFileHeader
    {
        public static readonly int size = 128;
        public byte[] signature = new byte[4];
        public byte[] compressedSize = new byte[4];
        public byte[] uncompressedSize = new byte[4];
        public byte fileNameLength;
        public byte[] encryptionInfoHeaderOffset = new byte[4];
        public byte[] fileDataOffset = new byte[4];
        public byte[] fileName = new byte[104];
        public byte[] tail = new byte[3];

        public InnerFileHeader() { }
    }
}
