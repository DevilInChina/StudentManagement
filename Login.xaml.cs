using System;
using System.Collections.Generic;
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

namespace StudentManagement
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        MainWindow Father;
        int CurrentType;
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            CurrentType = -1;
            Father = mainWindow;
            Father.type = CurrentType;
            //this.Background = new SolidColorBrush(mainWindow.MainThemeColor);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentType != -1)
            {
                this.Hide();
                switch (CurrentType)
                {
                    case 0:
                        Father.LoadStudent();
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                }
                Father.Show();
                
                this.Close();
            }
            else{
                MessageBox.Show("キャラを選んでください");
            }
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            CurrentType = 0;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            CurrentType = 1;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            CurrentType = 2;
        }

       
    }
}
