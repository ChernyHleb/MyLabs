using System.Collections.Generic;

namespace OTIK.Lab3
{
    class VSAS
    {
        public VSAS_Header header;
        public List<InnerFile> files = new List<InnerFile>();

        public VSAS(VSAS_Header header, List<InnerFile> files)
        {
            this.header = header;
            this.files = files;
        }
    }
}
