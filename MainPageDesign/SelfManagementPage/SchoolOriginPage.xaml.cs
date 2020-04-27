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
using MySql.Data.MySqlClient;
namespace StudentManagement.MainPageDesign.SelfManagementPage
{
    /// <summary>
    /// SchoolOriginPage.xaml 的交互逻辑
    /// </summary>
    public partial class SchoolOriginPage : UserControl
    {
        public SchoolOriginPage()
        {
            InitializeComponent();

            String connetStr = "server=127.0.0.1;port=3306;user=root;password=root; database=StudentManaged;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                MessageBox.Show("リンク完了");
                //在这里使用代码对数据库进行增删查改
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("リンクファイル");
            }
            MySqlParameter[] collections =
            {
                new MySqlParameter("@idn",MySqlDbType.Int32,1),
                new MySqlParameter("@sname",MySqlDbType.VarChar,12)
            };
            collections[0].Value = 1;
               
        }
        
    }

}
