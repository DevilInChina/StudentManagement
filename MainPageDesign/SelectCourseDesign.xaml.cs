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

namespace StudentManagement.MainPageDesign
{
    /// <summary>
    /// SelectCourseDesign.xaml 的交互逻辑
    /// </summary>
    public partial class SelectCourseDesign : UserControl,SecondPage
    {
        MainWindow root;
        CurrentCourseDesign course;
        public DataTable TotalCourse { get; }
        List<CourseShowed_Info> Course_Ls;
        CourseShowed_Info Selected_course = null;
        public SelectCourseDesign(MainWindow prev,CurrentCourseDesign course)
        {
            InitializeComponent();
            root = prev;
            this.course = course;
            TotalCourse = root.dataBase.getCourseOfClassRoom(-1, -1, false);
            Course_Ls = new List<CourseShowed_Info>();
            
            for (int i= 0; i < TotalCourse.Rows.Count; ++i)
            {
                
                Course_Ls.Add(
                    new CourseShowed_Info(
                        TotalCourse.Rows[i]["course_name"].ToString(),
                        TotalCourse.Rows[i]["Teacher_name"].ToString(),
                        TotalCourse.Rows[i]["Classroom_name"].ToString(),
                        int.Parse(TotalCourse.Rows[i]["Max_capacity"].ToString()),
                        int.Parse(TotalCourse.Rows[i]["Credit"].ToString()),
                        long.Parse(TotalCourse.Rows[i]["Class_Time"].ToString()),
                        int.Parse(TotalCourse.Rows[i]["Now_capacity"].ToString()),
                        long.Parse(TotalCourse.Rows[i]["course_id"].ToString())

                        )
                    );
            }
            studentItemTemplate.ItemsSource = Course_Ls;

        }

        public void Click()
        {
            //throw new NotImplementedException();
        }

        public void init(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }

        private void studentItemTemplate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selected_course = (CourseShowed_Info)studentItemTemplate.SelectedItem;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Selected_course == null)
            {
                MessageBox.Show("请选择一门课程");
            }
            else
            {
                bool ret = course.SelectCourse(Selected_course);
                
            }
        }
    }
}
