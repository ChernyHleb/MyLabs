using System;
using System.Windows;
using MailKit;  
using MailKit.Net.Smtp;
using MimeKit;



namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MimeMessage message;
        SmtpClient client;
        public MainWindow()
        {
            message = new MimeMessage();
            message.From.Add(new MailboxAddress("Никита Ткач", "tkach@internet.ru"));
            message.Subject = "From MailSender";
            client = new SmtpClient();
            InitializeComponent();
        }

        public void ClickSendButton(object sender, RoutedEventArgs e)
        {
            l_err.Text = "";
            try
            {            
                
                if (tb_adress.Text == "")
                    throw new Exception("No adress");                            
                if (tb_text.Text == "")
                    throw new Exception("No adress");
                message.To.Add(new MailboxAddress("Никита Ткач", tb_adress.Text));
                message.Body = new TextPart("plain")
                {
                    Text = tb_text.Text
                };

                    client.Connect("smtp.mail.ru", 465, true);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("tkach@internet.ru", "tUsrFijviHXvSzyQmnvc");

                    client.Send(message);
                    client.Disconnect(true);
            }
            catch(Exception ex)
            {
                l_err.Text = ex.Message;
            }
        }
    }
}
