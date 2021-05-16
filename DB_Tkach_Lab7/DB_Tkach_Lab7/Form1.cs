using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.SqlClient;

namespace DB_Tkach_Lab7
{
    public partial class Form1 : Form
    {
        OleDbConnection cn = new OleDbConnection(
            "Data Source = DESKTOP-74QMQEE; " +
            "Initial Catalog = study; " +
            "Integrated Security = True; " +
            "Provider = .NET Framework Data Provider for SQL Server;"
        );


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
