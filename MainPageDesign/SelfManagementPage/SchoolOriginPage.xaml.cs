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
using StudentManagement.DataBase;
namespace StudentManagement.MainPageDesign.SelfManagementPage
{
    /// <summary>
    /// SchoolOriginPage.xaml 的交互逻辑
    /// </summary>
    public partial class SchoolOriginPage : UserControl,ThirdPage
    {
        MySqlParameterCollection info;
        public SchoolOriginPage(MainWindow root)
        {
            InitializeComponent();
            StaticDataBase db = new StaticDataBase();
            db.SetConnector("s");
            info = db.getInfoFromId(1);
            
            
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
