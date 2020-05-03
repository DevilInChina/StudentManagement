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

namespace StudentManagement.TeacherPageDesign
{
    /// <summary>
    /// ScoreReportDesign.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreReportDesign : UserControl,SecondPage
    {
        MainWindow root;
        public ScoreReportDesign(MainWindow root)
        {
            InitializeComponent();
            this.root = root;
        }

        public void init(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }
    }
}
