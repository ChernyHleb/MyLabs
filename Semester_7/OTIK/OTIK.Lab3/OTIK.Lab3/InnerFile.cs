using System;

namespace OTIK.Lab3
{
    class InnerFile
    {
        public InnerFileHeader header;
        public byte[] encryptionHeader;
        public byte[] data;

        public InnerFile(InnerFileHeader header, byte[] encryptionHeader, byte[] data)
        {
            this.header = header;
            this.encryptionHeader = encryptionHeader;
            this.data = data;
        }
    }
}
