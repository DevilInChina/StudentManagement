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
using StudentManagement.MainPageDesign.SelfManagementPage;
namespace StudentManagement.MainPageDesign
{
    /// <summary>
    /// SelfManagement.xaml 的交互逻辑
    /// </summary>

    public partial class SelfManagement : UserControl,SecondPage
    {
        private UserControl[] BufferStore;
        private int curIndex = 0;
        
        public SelfManagement(MainWindow prev)
        {
            InitializeComponent();
            int size = 8;
            init(prev);
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

        private void OriginPageJump(object sender, RoutedEventArgs e)
        {
            int Id = 0;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new SchoolOriginPage();

            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }

        private void ChangeInfoJump(object sender, RoutedEventArgs e)
        {
            int Id = 1;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new SelfInfoChangePage();

            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }

        private void ChangeOriginJump(object sender, RoutedEventArgs e)
        {
            int Id = 2;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new OriginChangePage();

            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }

        private void AwardInfoJump(object sender, RoutedEventArgs e)
        {
            int Id = 3;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new AwardInfoPage();

            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }

        private void ERegJump(object sender, RoutedEventArgs e)
        {
            int Id = 4;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new ERegisterPage();

            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }

        private void GuardInfoJump(object sender, RoutedEventArgs e)
        {
            int Id = 5;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new GuarderInfoPage();

            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }

        private void MinorJump(object sender, RoutedEventArgs e)
        {
            int Id = 6;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new MinorRegisterPage();

            }
            if (curIndex != Id)
            {
                curIndex = Id;
                SubPanel.Children.Clear();
                SubPanel.Children.Add(BufferStore[Id]);
            }
        }

        private void IDMaintainJump(object sender, RoutedEventArgs e)
        {
            int Id = 7;
            if (BufferStore[Id] == null)
            {
                BufferStore[Id] = new MinorRegisterPage();

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
