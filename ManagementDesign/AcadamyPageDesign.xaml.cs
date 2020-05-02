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
using StudentManagement;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace StudentManagement.ManagementDesign
{
    /// <summary>
    /// AcadamyPageDesign.xaml 的交互逻辑
    /// </summary>
    public partial class AcadamyPageDesign : UserControl
    {

        MainWindow root;
        DependencyProperty dp;
        int Cnt;
        public AcadamyPageDesign(MainWindow prev)
        {
            InitializeComponent();
            root = prev;
            Menu1.Background = new SolidColorBrush(prev.MainThemeColor);
            dp = DependencyProperty.Register("MenuItemValue", typeof(int), typeof(MenuItem));
            DataTable data = root.dataBase.getAcadamy();
            
            for ( Cnt = 0; Cnt < data.Rows.Count;)
            {
                addMenuItem(data.Rows[Cnt]["Academy_name"].ToString());
            }
        }
        public void addMenuItem(String header)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Click += MenuItem_Click;
            menuItem.SetValue(dp, Cnt);
            menuItem.Header = header;
            Menu1.Items.Add(menuItem);
            ++Cnt;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            int indx = (int)((MenuItem)sender).GetValue(dp);
            MessageBox.Show(((MenuItem)Menu1.Items[indx]).Header.ToString());
        }
        private void addAcaButton_Click(object sender, RoutedEventArgs e)
        {
            Controls.InputBox info = new Controls.InputBox("请输入新增学院名");
            
            info.PassDataBetweenForm += new Controls.InputBox.PassDataBetweenFormHandler(FinishAddAcaButtonClick);
            info.Show();
            info.Activate();
        }
        private void FinishAddAcaButtonClick(object sender, Controls.PassDataWinFormEventArgs e)
        {
            String acaName = e.Info;
            root.dataBase.addAcadamy(acaName);
            long k = root.dataBase.getAcadamyID(acaName);
            if (k > 0)
            {
                addMenuItem(acaName);
            }
        }
    }
}
