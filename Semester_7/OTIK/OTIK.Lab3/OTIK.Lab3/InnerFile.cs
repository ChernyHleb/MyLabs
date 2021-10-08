using System;

namespace OTIK.Lab3
{
    class InnerFile
    {
        public InnerFileHeader header;
        public byte[] encryptionHeader;
        public byte[] data;

        public InnerFile(InnerFileHeader header, byte[] encryptionHeader)
        {
            this.header = header;
            this.encryptionHeader = encryptionHeader;

            UInt32 compressedSize = BitConverter.ToUInt32(header.compressedSize, 0);
            UInt32 uncompressedSize = BitConverter.ToUInt32(header.uncompressedSize, 0);

            if (compressedSize != 0)
            {
                data = new byte[compressedSize];
            }
            else
            {
                data = new byte[uncompressedSize];
            }
        }
    }
}
