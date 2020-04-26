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
using StudentManagement.MainPageDesign.SelfManagementPage;
namespace StudentManagement.MainPageDesign
{
    /// <summary>
    /// SelfManagement.xaml 的交互逻辑
    /// </summary>
    public partial class SelfManagement : UserControl
    {
        UserControl CurrentPage;
        public SelfManagement(MainWindow prev)
        {
            InitializeComponent();
            MenuItem s = new MenuItem();
            s.Click += new RoutedEventHandler(MenuClick);
            s.Header = "学籍管理";
            Menu1.Background = new SolidColorBrush(prev.MainThemeColor);
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
            CurrentPage = new SchoolOriginPage();
            SystemSubPanel.Children.Clear();
            SystemSubPanel.Children.Add(CurrentPage);
        }
    }
}
