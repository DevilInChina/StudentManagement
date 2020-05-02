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

namespace StudentManagement.Controls
{
    /// <summary>
    /// InputBox.xaml 的交互逻辑
    /// </summary>
    public class PassDataWinFormEventArgs : EventArgs
    {

        public PassDataWinFormEventArgs()
        {
            //
        }
        public PassDataWinFormEventArgs(string info)
        {
            this.info = info;
        }

        private string info;

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
        
    }
public partial class InputBox : Window
    {
        String info;
        public InputBox( String Quest, String Confirm="确定", String Cancle = "取消")
        {
            InitializeComponent();
            button.Content = Confirm;
            button1.Content = Cancle;
            textBox.Text = null;
            this.Title = Quest; 
        }
        public delegate void PassDataBetweenFormHandler(object sender, PassDataWinFormEventArgs e);
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs(textBox.Text);
            PassDataBetweenForm(this, args);
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
