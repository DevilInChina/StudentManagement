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
using StudentManagement.DropDownMenu;
using MaterialDesignThemes.Wpf;
namespace StudentManagement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<SubItem> []SubMenu = new List<SubItem>[5];
            for(int i = 0; i < 5; ++i)
            {
                SubMenu[i] = new List<SubItem>();
                SubMenu[i].Add(new SubItem("A"));
                SubMenu[i].Add(new SubItem("B"));
                SubMenu[i].Add(new SubItem("C"));
                SubMenu[i].Add(new SubItem("D"));
                Menu.Children.Add(new UserControlMenuItem(new ItemMenu("Header "+i, SubMenu[i], PackIconKind.Schedule), this));
            }
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
    }
}
