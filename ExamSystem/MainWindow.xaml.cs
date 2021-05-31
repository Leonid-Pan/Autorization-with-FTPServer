using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
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

namespace ExamSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Person();
            FTP ftp = new FTP();
            ftp.Show();
            this.Close();
        }

        private void regButton_OnClick(object sender, RoutedEventArgs e)
        {
            registration registration = new registration();
            registration.Show();
            this.Close();
        }

        void Person()
        {
            string path = "Login_Pass.txt";
            string login = tbLogin.Text;
            string pass = tbPass.Text;
           
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.UTF8.GetString(array);
                string[] loginPass = textFromFile.Split('\n');
                for (int i = 0; i < loginPass.Length; i++)
                {
                    loginPass[i] = loginPass[i].Substring(loginPass[i].IndexOf(':') + 1);
                    
                }
                MessageBox.Show("Пользователь авторизован");
            }
        }
    }
}
