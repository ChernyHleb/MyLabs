namespace OTIK.Lab3
{
    class VSAS_Header
    {
        public byte[] signature = new byte[4];
        public byte algNumEntropyCompression;
        public byte algNumContextCompression;
        public byte algNumNoiseProtection;
        public byte algNumEncryption;
        public byte filesAmount;
        public byte[] tail = new byte[7];

        public VSAS_Header() { }
    }
}
