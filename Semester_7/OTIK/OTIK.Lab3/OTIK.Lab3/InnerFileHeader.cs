namespace OTIK.Lab3
{
    class InnerFileHeader
    {
        public byte[] signature = new byte[4];
        public byte[] compressedSize = new byte[4];
        public byte[] uncompressedSize = new byte[4];
        public byte fileNameLength;
        public byte[] fileName = new byte[50];
        public byte tail;

        public InnerFileHeader() { }
    }
}
