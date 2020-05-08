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
using System.Data;
using StudentManagement.Controls;
namespace StudentManagement.ManagementDesign
{
    /// <summary>
    /// TeacherAddDesign.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherAddDesign : UserControl,SecondPage
    {
        MainWindow root;
        private DataTable AcadamyInfo;
        private DataTable MajorInfo;
        private DataTable TeacherTable;
        private DataRowView SelectedTeacher;
        public TeacherAddDesign(MainWindow root)
        {
            InitializeComponent();
            this.root = root;
            AcadamyInfo = null;
            MajorInfo = null;

        }

        public void Click()
        {
            if (AcadamyInfo != null)
            {
                AcadamyInfo.Clear();
                MajorInfo.Clear();
            }
            AcadamyInfo = root.dataBase.getAcadamy();
            MajorInfo = root.dataBase.getMajor();
            RefTeacher();
        }

        public void init(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AddTeacherWindow s=  new AddTeacherWindow("添加教师信息",AcadamyInfo, MajorInfo, root);
        }

        private void RefTeacher()
        {

            TeacherTable = root.dataBase.getTeacher();
            TeacherInfo.ItemsSource = TeacherTable.DefaultView;

        }
        private void Refesh_button_Click(object sender, RoutedEventArgs e)
        {
            RefTeacher();
        }

        private void Delete_burron_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTeacher != null)
            {
                root.dataBase.delete_Teacher(long.Parse(SelectedTeacher.Row["Teacher_id"].ToString()));
                SelectedTeacher = null;
                RefTeacher();
            }
            else
            {
                MessageBox.Show("请选择一位教师");
            }
        }
        private void TeacherInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedTeacher = (DataRowView)TeacherInfo.SelectedItem;
        }
    }
}
