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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentManagement.MainPageDesign.SystemManagementPage;
namespace StudentManagement.MainPageDesign
{
    /// <summary>
    /// SystemManagement.xaml 的交互逻辑
    /// </summary>
    public partial class SystemManagement : UserControl
    {

        private UserControl CurrentPage;
        private UserControl[]BufferStore;
        public SystemManagement(MainWindow prev)
        {
            InitializeComponent();
            BufferStore = new UserControl[1];///

            MenuItem s = new MenuItem();
            s.Click+= new RoutedEventHandler(MenuClick);
            s.Header = "（学生）常用附件下载";
            Menu1.Background =new SolidColorBrush(prev.MainThemeColor);
            Menu1.Items.Add(s);
            CurrentPage = null;
        }
        private void MenuClick(object sender, EventArgs e)
        {
            //MessageBox.Show("跳转页面");
            if (CurrentPage == null)
            {
                //destoryPagee
            }
            CurrentPage = new DownloadFilePage();
            SubPanel.Children.Clear();
            SubPanel.Children.Add(CurrentPage);
        }
    }
}
