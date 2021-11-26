using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTIK.Lab3.Lab4_ShannonFano
{
    class Message
    {
        List<byte> message;

        public Message(List<byte> data)
        {
            this.message = data;
        }

        public Message()
        {

        }
    }
}
