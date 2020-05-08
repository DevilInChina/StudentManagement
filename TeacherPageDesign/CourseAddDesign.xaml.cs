using System;
using System.Collections.Generic;
using System.Data;
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
namespace StudentManagement.TeacherPageDesign
{
    /// <summary>
    /// CourseAddDesign.xaml 的交互逻辑
    /// </summary>
    public partial class CourseAddDesign : UserControl,SecondPage
    {
        MainWindow root;
        DataTable ClassRoomInfo;
        DataTable CourseInfo;
        public CourseAddDesign(MainWindow root)
        {
            InitializeComponent();
            this.root = root;
            selectTable.init(root.Button_Int,"选择上课时间");//#FF2196F3
            ClassRoomInfo = root.dataBase.getClassRoom();
            DataColumn[] keys = new DataColumn[1];
            keys[0] = ClassRoomInfo.Columns["Classroom_name"];
            ClassRoomInfo.PrimaryKey = keys;
            CourseInfo = root.dataBase.getCourseOfClassRoom(0, root.PersonID);
            selectTable.RefreshButtionInfo(CourseInfo);
            for (int i = 0; i < ClassRoomInfo.Rows.Count; ++i)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = ClassRoomInfo.Rows[i]["Classroom_name"];
                Classroom_comboBox.Items.Add(comboBoxItem);
            }
        }

        public void Click()
        {
            //throw new NotImplementedException();
        }

        public void init(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(Course_Name.Text==null || Cap_comboBox.SelectedItem==null || Circle_comboBox.SelectedItem == null ||Classroom_comboBox.SelectedItem==null)
            {
                MessageBox.Show("请输入课程的基本信息");
                return;
            }
            if (selectTable.GetSelectInfo() == 0)
            {
                MessageBox.Show("请选择至少一个上课时间");
                return;
            }
            long id = selectTable.GetSelectInfo();
            int cnt = 0;
            while (id != 0)
            {
                ++cnt;
                id -= (-id) & id;
            }
            int Cir = int.Parse(((Label)(Circle_comboBox.SelectedItem)).Content.ToString());
            int res = Cir * 2 * cnt / 16;

            String Name = Course_Name.Text;
            DataRow dataRow = ClassRoomInfo.Rows.Find(
            ((ComboBoxItem)Classroom_comboBox.SelectedItem).Content.ToString());
            long CLSID = (long)dataRow["Classroom_id"];
            int Cap = int.Parse(((Label)Cap_comboBox.SelectedItem).Content.ToString());
            
            MessageBoxResult RES =
             MessageBox.Show("确定添加这门学分为"+res.ToString()+"的课程？", "提示", MessageBoxButton.YesNo);
            if (RES == MessageBoxResult.Yes)
            {
                bool AddSuc= root.dataBase.InsertCourse(new Course_info(
                    Course_Name.Text,
                    root.PersonID,
                    CLSID,-1,Cap,res, selectTable.GetSelectInfo()
                    )) ;//-1表示非专业必修课
                if (AddSuc)
                {
                    DataTable dataTable = root.dataBase.getCourseOfClassRoom(CLSID, root.PersonID);
                    selectTable.RefreshButtionInfo(dataTable);
                    MessageBox.Show("添加成功");
                }
            }
            else
            {

            }

        }

        private void Classroom_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRow dataRow = ClassRoomInfo.Rows.Find(
            ((ComboBoxItem)Classroom_comboBox.SelectedItem).Content.ToString());
            long CLSID = (long)dataRow["Classroom_id"];
            CourseInfo = root.dataBase.getCourseOfClassRoom(CLSID,root.PersonID);
            selectTable.RefreshButtionInfo(CourseInfo);
        }
    }
}
