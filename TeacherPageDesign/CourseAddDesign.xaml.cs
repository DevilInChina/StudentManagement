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
namespace StudentManagement.TeacherPageDesign
{
    /// <summary>
    /// CourseAddDesign.xaml 的交互逻辑
    /// </summary>
    public partial class CourseAddDesign : UserControl,SecondPage
    {
        MainWindow root;
        public CourseAddDesign(MainWindow root)
        {
            InitializeComponent();
            this.root = root;
            DependencyProperty Dp = DependencyProperty.Register("Btn_to_int", typeof(int), typeof(Button));
            selectTable.init(Dp,"选择上课时间");//#FF2196F3
            
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
            if(Course_Name.Text==null || Cap_comboBox.SelectedItem==null || Circle_comboBox.SelectedItem == null)
            {

            }

        }
    }
}
