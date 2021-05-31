using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ExamSystem
{
    /// <summary>
    /// Логика взаимодействия для FTP.xaml
    /// </summary>
    public partial class FTP : Window
    {
        const string ftp = "ftp://192.168.1.105/";
        const string directoryName = "asd";
        const string directoryAddressFTP = ftp + directoryName;
        const string fileName = "NewTextFile.txt";
        const string fileAddressFTP = ftp + fileName;
        const string saveFileAddress = fileName;
        const string newFileName = "NewFile.txt";
        const string newFileAddress = newFileName;
        const string newFileAddressFTP = ftp + newFileName;
        const string path = "Login_Pass.txt";
        public FTP()
        {
            InitializeComponent();
        }

        private void ok_onClick(object sender, RoutedEventArgs e)
        {
            if (tb1.IsChecked == true)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(newFileAddressFTP);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                FileStream fs = new FileStream(newFileAddress, FileMode.Open);
                byte[] fileData = File.ReadAllBytes(path);
                fs.Read(fileData, 0, fileData.Length);
                fs.Close();
                request.ContentLength = fileData.Length;
                var r = request.GetRequestStream();
                r.Write(fileData, 0, fileData.Length);
                r.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Console.ForegroundColor = ConsoleColor.Green;
                MessageBox.Show($"File is Uploaded! \n Status: {response.StatusDescription}");
                //response.Close();

            }
            else if (tb2.IsChecked == true)
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(fileAddressFTP);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileStream fs = new FileStream(saveFileAddress, FileMode.Create);
                byte[] buffer = new byte[64];
                int size;
                while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, size);
                }
                fs.Close();
                response.Close();
                MessageBox.Show("File saved!!!");

            }
            else if(tb3.IsChecked == true)
            {
                WebRequest request = WebRequest.Create(directoryAddressFTP);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show("Папка создана");
                }
            }
            else if (tb4.IsChecked == true)
            {
                WebRequest request = WebRequest.Create(directoryAddressFTP);
                request.Method = WebRequestMethods.Ftp.RemoveDirectory;
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show("Папка удалена");
                }
            }

        }

        private void cancel_onClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        
    }
}
