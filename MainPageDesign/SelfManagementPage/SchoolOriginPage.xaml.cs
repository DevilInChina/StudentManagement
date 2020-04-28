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
using StudentManagement.MainPageDesign;
using System.Data;
namespace StudentManagement.MainPageDesign.SelfManagementPage
{
    /// <summary>
    /// SchoolOriginPage.xaml 的交互逻辑
    /// </summary>
    public partial class SchoolOriginPage : UserControl,ThirdPage
    {
        public SchoolOriginPage()
        {
            InitializeComponent();

            button.Content = getRes();
            
        }
        String getRes()
        {
            String connectionString = "server=127.0.0.1;port=3306;user=root;password=root; database=studentmanaged;";
            
            MySqlConnection mysqlcon;
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();
            DataSet dataset = new DataSet();
            mysqlcon = new MySqlConnection(connectionString);
            mysqlcon.Open();
            mysqldata.SelectCommand = new MySqlCommand("GetStudentInfoFromID",mysqlcon);
            mysqldata.SelectCommand.Connection = mysqlcon;
            
            mysqldata.SelectCommand.CommandText = "GetStudentInfoFromID";
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter id_para = new MySqlParameter("?idn", MySqlDbType.Int32, 1);//mysql的存储过程参数是以?打头的！！！！
            id_para.Value = 1;
            mysqldata.SelectCommand.Parameters.Add(id_para);
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            MySqlParameter name = new MySqlParameter("?qName", MySqlDbType.VarChar, 12);//mysql的存储过程参数是以?打头的！！！！
            name.Value = "Null";
            
            mysqldata.SelectCommand.Parameters.Add(name);
            id_para.Direction = ParameterDirection.Input;
            name.Direction = ParameterDirection.Output;
            try
            {
                //mysqldata.Fill(dataset);
                mysqldata.SelectCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return (String)name.Value;
        }
        public void ReClick()
        {

        }
    }

}
