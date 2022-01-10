
using System.Windows;
using MailKit.Net.Pop3;
using MailKit;
using MimeKit;
using System.Collections.Generic;

namespace MailReceiver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pop3Client client;
        public MainWindow()
        {
            client = new MailKit.Net.Pop3.Pop3Client();
            InitializeComponent();
        }
        public void ClickRecieveButton(object sender, RoutedEventArgs e)
        {
            //gayGrid.Items.Add(new Test { Test1 = "TkachTest tkachtest@gmail.com", Test2 = "TkachTest", Test3 = "07.01.2022 17:52" });
            client.Connect("pop.mail.ru", 995, true);

            client.Authenticate("tkachtest@gmail.com", "tusrfijvihxvszyqmnvc");

            for (int i = 0; i < client.Count; i++)
            {
                var message = client.GetMessage(i);
                tb_text.Text += "subject:" +  message.Subject;
            }

            client.Disconnect(true);

        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        public class Test
        {
            public string Test1 { get; set; }
            public string Test2 { get; set; }
            public string Test3 { get; set; }
        }

    }
}
