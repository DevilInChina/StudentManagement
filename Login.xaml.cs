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
using System.Drawing;
namespace StudentManagement
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        MainWindow Father;
        int CurrentType;
        int UserIDSize;
        public Login()
        {
            InitializeComponent();
            ImageBrush b3 = new ImageBrush();
            b3.ImageSource = new BitmapImage(new Uri("../../Pictures/kon1cut.jpg", UriKind.RelativeOrAbsolute));
            this.Background = b3;
            CurrentType = -1;
            
            UserIDSize = 0;
            //this.Background = new SolidColorBrush(mainWindow.MainThemeColor);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentType != -1)
            {
                if (UserName.Text == null)
                {
                    MessageBox.Show("请输入用户名");
                    return;
                }else if (passwordBox.Password == null)
                {
                    MessageBox.Show("请输如密码");
                    return;
                }

                /*
                 * PassWordCheck
                 * 
                 */
                this.Hide();

                Father = new MainWindow();
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
                Father.type = CurrentType;
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

        private void UserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());
            
            int sa =  e.Key- Key.D0;
            int sb = e.Key - Key.NumPad0;
            if ((sa >= 0 && sa <= 9) || (sb >= 0 && sb <= 9))
            {
                if (UserIDSize < 15)
                {
                    e.Handled = false;
                    ++UserIDSize;
                }
                else
                {
                    e.Handled = true;
                }

            }
            else
            {
                if (e.Key != Key.Enter && e.Key != Key.Back && e.Key != Key.Tab)
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.Key == Key.Back && UserIDSize>0)
                    {
                        --UserIDSize;
                    }
                    e.Handled = false;
                }
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        
    }
}
