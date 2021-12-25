
using System.Windows;
using MailKit.Net.Pop3;
using MailKit;
using MimeKit;


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
            
                client.Connect("pop.mail.ru", 995, true);

                client.Authenticate("tkach@internet.ru", "tUsrFijviHXvSzyQmnvc");

                for (int i = 0; i < client.Count; i++)
                {
                    var message = client.GetMessage(i);
                    tb_text.Text += "Subject:" +  message.Subject;
                }

                client.Disconnect(true);
            
        }
    }
}
