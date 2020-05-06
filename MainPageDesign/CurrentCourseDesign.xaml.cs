using StudentManagement.Controls;
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

namespace StudentManagement.MainPageDesign
{
    /// <summary>
    /// CurrentCourseDesign.xaml 的交互逻辑
    /// </summary>
    public partial class CurrentCourseDesign : UserControl,SecondPage
    {
        MainWindow root;
        SelectCourseDesign courseSelected = null;
        DataTable stored_selectedCourse = null;
        Brush []CourseColors = null;
        public CurrentCourseDesign(MainWindow prev)
        {
            InitializeComponent();
            root = prev;
            CourseTable.init(root.Button_Int,"本学期课程表", false);
            CourseColors = new Brush[7];
            BrushConverter brushConverter = new BrushConverter();
            int indx = 0;
            CourseColors[indx++] = (Brush)brushConverter.ConvertFromString("#FF006000");
            CourseColors[indx++] = (Brush)brushConverter.ConvertFromString("#FF6C3365");
            CourseColors[indx++] = (Brush)brushConverter.ConvertFromString("#FFFFDC35");
            CourseColors[indx++] = (Brush)brushConverter.ConvertFromString("#FFFF0000");
            CourseColors[indx++] = (Brush)brushConverter.ConvertFromString("#FF930093");
            CourseColors[indx++] = (Brush)brushConverter.ConvertFromString("#FF467500");
            CourseColors[indx++] = (Brush)brushConverter.ConvertFromString("#FF00CACA");

        }
        public void init(SelectCourseDesign selectCourseDesign)
        {
            courseSelected = selectCourseDesign;
            DataTable temp = root.dataBase.getSelectedCourseByID(root.PersonID);
            stored_selectedCourse = courseSelected.TotalCourse.Clone();
            String Str = null;
            
            for (int i = 0; i < temp.Rows.Count; ++i)
            {

                Str = temp.Rows[i]["course_id"].ToString();

                DataRow[] dataRows = courseSelected.TotalCourse.Select("course_id=" + Str);

                stored_selectedCourse.Rows.Add(dataRows[0].ItemArray);
                //
                

            }
            CourseTable.RefreshButtionInfo(stored_selectedCourse,CourseColors);

        }
        public void Click()
        {
            //throw new NotImplementedException();

        }

        public void init(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }
        public bool SelectCourse(CourseShowed_Info selected)
        {
            long s = selected.Class_Time;
            if((s& CourseTable.GetConfilictInfo()) != 0)
            {
                MessageBox.Show("上课时间冲突");
                return false;
            }
            else
            {
                int res = root.dataBase.SelectCourse(root.PersonID, selected.course_id) ;
                switch (res)
                {
                    case 0:
                        MessageBox.Show("添加失败，课容量已满");
                        break;
                    case 1:
                        MessageBox.Show("添加成功");

                        return true;
                    case 2:
                        MessageBox.Show("请勿重复添加");
                        break;
                }

            }
            return false;
        }
    }
}
