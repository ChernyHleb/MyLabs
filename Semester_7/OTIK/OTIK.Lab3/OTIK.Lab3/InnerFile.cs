using System;

namespace OTIK.Lab3
{
    class InnerFile
    {
        public InnerFileHeader header;
        public byte[] encryptionHeader;
        public byte[] symCodeTable;
        public byte[] data;

        public InnerFile(InnerFileHeader header, byte[] encryptionHeader, byte[] symCodeTable, byte[] data)
        {
            this.header = header;
            this.encryptionHeader = encryptionHeader;
            this.symCodeTable = symCodeTable;
            this.data = data;
        }
    }
}
