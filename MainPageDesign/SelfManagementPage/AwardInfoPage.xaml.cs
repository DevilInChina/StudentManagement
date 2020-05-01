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
using StudentManagement.MainPageDesign;
namespace StudentManagement.MainPageDesign.SelfManagementPage
{
    /// <summary>
    /// AwardInfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class AwardInfoPage : UserControl,ThirdPage
    {
        MainWindow root;
        public AwardInfoPage(MainWindow prev)
        {
            InitializeComponent();
            root = prev;
        }

        public void ReClick()
        {
            throw new NotImplementedException();
        }

        public void ReClick(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }
    }
}

