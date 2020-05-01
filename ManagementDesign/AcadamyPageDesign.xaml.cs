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
        public AcadamyPageDesign(MainWindow prev)
        {
            InitializeComponent();
            root = prev;
            Menu1.Background = new SolidColorBrush(prev.MainThemeColor);
            DataTable data = root.dataBase.getAcadamy();
            MessageBox.Show(data.Rows[0]["Academy_name"].ToString());
        }
    }
}
