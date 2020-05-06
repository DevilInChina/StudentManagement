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
using StudentManagement.Controls;
using StudentManagement.MainPageDesign;
using StudentManagement.ManagementDesign;
using MaterialDesignThemes.Wpf;
using StudentManagement.DataBase;
using StudentManagement.TeacherPageDesign;
using System.Data;
namespace StudentManagement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public ListView CurListView;
        public DataTable selfInfo;
        public Color MainThemeColor;
        public StaticDataBase dataBase;
        public int type;//0 学生 1 教师 2 管理
        public DependencyProperty ComboBoxItem_Long;

        public DependencyProperty Button_Int; 
        public long PersonID { get; }
        public void LoadStudent()
        {
            
            List<SubItem>[] SubMenu = new List<SubItem>[8];
            int i = 0;
            selfInfo = dataBase.getStudentByID(PersonID);
            label.Content = "欢迎," + selfInfo.Rows[0]["Student_name"] + "同学";
            CurListView = null;
            
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("系统管理", new SystemManagement(this)));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("系统管理", SubMenu[i], PackIconKind.Monitor), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("学籍管理", new SelfManagement(this)));
            SubMenu[i].Add(new SubItem("学生异动"));
            SubMenu[i].Add(new SubItem("毕业设计"));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("个人管理", SubMenu[i], PackIconKind.Person), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            CurrentCourseDesign temp = new CurrentCourseDesign(this);
            SubMenu[i].Add(new SubItem("本学期课表",temp));
            SelectCourseDesign temp2 = new SelectCourseDesign(this, temp);
            temp.init(temp2);
            SubMenu[i].Add(new SubItem("选课管理",temp2));
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
        }
        public void LoadManaged()
        {
            List<SubItem>[] SubMenu = new List<SubItem>[8];
            int i = 0;
            selfInfo = dataBase.getManagerByID(PersonID);
            label.Content = "欢迎," + selfInfo.Rows[0]["Clerk_name"] + "先生";
            CurListView = null;

            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("学院管理", new AcadamyPageDesign(this)));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("学院管理", SubMenu[i], PackIconKind.Gear), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("导入学生信息", new StudentImportDesign(this)));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("学生管理", SubMenu[i], PackIconKind.Person), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("添加教师信息", new TeacherAddDesign(this)));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("教师管理", SubMenu[i], PackIconKind.Person), this));
        }
        public void LoadTeacher()
        {
            List<SubItem>[] SubMenu = new List<SubItem>[8];
            int i = 0;
            selfInfo = dataBase.getTeacherByID(PersonID);
            label.Content = "欢迎," + selfInfo.Rows[0]["Teacher_name"] +"老师";
            CurListView = null;

            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("分数登记", new ScoreReportDesign(this)));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("学生管理", SubMenu[i], PackIconKind.Gear), this));
            ++i;
            SubMenu[i] = new List<SubItem>();
            SubMenu[i].Add(new SubItem("添加课程", new CourseAddDesign(this)));
            Menu.Children.Add(new UserControlMenuItem(new ItemMenu("课程管理", SubMenu[i], PackIconKind.Gear), this));


        }

        public MainWindow(StaticDataBase mysqlConnector,long ID)
        {
            ComboBoxItem_Long = DependencyProperty.Register("ComboBoxItem_Long", typeof(long), typeof(ComboBoxItem));
            Button_Int = DependencyProperty.Register("Btn_to_int", typeof(int), typeof(Button));
            InitializeComponent();
            MainThemeColor = new Color();
            MainThemeColor.R = 0;
            MainThemeColor.G = 127;
            MainThemeColor.B = 255;
            MainThemeColor.A = 127;
            dataBase = mysqlConnector; 
            PersonID = ID;
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);
           
           //MessageBox.Show("Shift");
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
                ((SecondPage)(screen)).Click();
            }
            else
            {
            }
        }

    }
}
