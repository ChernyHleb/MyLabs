using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tkach.Lab6.Observer
{
    class Report
    {
        public string report;
        public Teacher author;

        public Report(string report, Teacher author)
        {
            this.author = author;
            this.report = report;
        }
    }
}
