using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;

namespace ExamSystem
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
        }

        private void registration_onClick(object sender, RoutedEventArgs e)
        {
            SavePerson();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void cancel_onClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        } 
        
        void SavePerson()
        {
                string path = "Login_Pass.txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine($"Имя: {tbNameReg.Text}");
                sw.WriteLine($"Логин: {tbLoginReg.Text}");
                sw.WriteLine($"Пароль: {tbPassReg.Text}");
                MessageBox.Show("Данные сохранены");
                sw.Close();
        }
    }
}
