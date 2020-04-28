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
using StudentManagement.MainPageDesign;
using MaterialDesignThemes.Wpf;
namespace StudentManagement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public ListView CurListView;
        public Color MainThemeColor;
        public MainWindow()
        {
            InitializeComponent();
            CurListView = null;
            List<SubItem> []SubMenu = new List<SubItem>[8];
            int i = 0;
            MainThemeColor = new Color();
            MainThemeColor.R = 0;
            MainThemeColor.G = 127;
            MainThemeColor.B = 255;
            MainThemeColor.A = 127;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("系统管理",new SystemManagement(this)));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("系统管理", SubMenu[i], PackIconKind.Monitor), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("学籍管理",new SelfManagement(this)));
            SubMenu[i].Add(new SubItem("学生异动"));
            SubMenu[i].Add(new SubItem("毕业设计"));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("个人管理", SubMenu[i], PackIconKind.Person), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("本学期课表"));
            SubMenu[i].Add(new SubItem("选课管理"));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("选课管理", SubMenu[i], PackIconKind.Cart), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("评估"));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("教学评估", SubMenu[i], PackIconKind.Pencil), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("考务管理"));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("考务管理", SubMenu[i], PackIconKind.Calendar), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("教学资源"));
            SubMenu[i].Add(new SubItem("自习查询"));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("教学资源", SubMenu[i], PackIconKind.Building), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("培养方案完成情况"));
            SubMenu[i].Add(new SubItem("指导性完成计划"));
            SubMenu[i].Add(new SubItem("课程"));
            SubMenu[i].Add(new SubItem("教材"));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("综合查询", SubMenu[i], PackIconKind.Magnify), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("缓考考试"));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("缓考考试", SubMenu[i], PackIconKind.Paper), this));
            /////
        }
        
        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
            else
            {
                
            }
        }

    }
}
