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
using StudentManagement.MainPageDesign.CourseChoosenPage;
namespace StudentManagement.MainPageDesign
{
    /// <summary>
    /// CourseChoosen.xaml 的交互逻辑
    /// </summary>
    public partial class CourseChoosen : UserControl,SecondPage
    {
        private UserControl[] BufferStore;
        private int curIndex = 0;
        public CourseChoosen(MainWindow prev)
        {
            InitializeComponent();
            init(prev);
            int size = 2;
            BufferStore = new UserControl[size];
            for (int i = 0; i < size; ++i)
            {
                BufferStore[i] = null;
            }
            curIndex = -1;
        }

        public void init(MainWindow curWindow)
        {
            Menu1.Background = new SolidColorBrush(curWindow.MainThemeColor);
        }

        private void CurJump(object sender, RoutedEventArgs e)
        {
            int Id = 0;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new CurrentYearPage();
            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }

        private void PrevJump(object sender, RoutedEventArgs e)
        {
            int Id = 1;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new PrevYearPage();
            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }
    }
}
