using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PIN33_Tkach_DB_Lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindMainDataGrid("factory");
        }

        public void BindMainDataGrid(String tableName)
        {
            /// строка подключения к учебной БД
            String connectionString = "Data Source=DESKTOP-74QMQEE;Initial Catalog=study;Integrated Security=True";

            /// инициализация и запуск подключения
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            /// инициализация команда - получить все строки из таблицы
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [{tableName}]", connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable(tableName);
            dataAdapter.Fill(dataTable);

            FactoryDataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
