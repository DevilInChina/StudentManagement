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

namespace StudentManagement.ManagementDesign.SingleAcademyPage
{
    /// <summary>
    /// SingleAcademyPage.xaml 的交互逻辑
    /// </summary>
    public partial class SingleAcademyPage : UserControl, ThirdPage
    {
        MainWindow root;
        DataTable data;
        int Cnt = 0;
        public SingleAcademyPage(MainWindow prev,long AcademyID,String AcademyName)
        {
            InitializeComponent();
            root = prev;
            data = root.dataBase.getMajorOfAcademy(AcademyID);
            for(int i = 0; i < data.Rows.Count; ++i)
            {
                addListItem(data.Rows[i]["major_name"].ToString());
            }
        }
        public void addListItem(String header)
        {
            ListBoxItem menuItem = new ListBoxItem();
            menuItem.Content = header;
            listBox.Items.Add(menuItem);
            ++Cnt;
        }
        public void init(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }

        public void ReClick(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }

        public void ReClick()
        {
            throw new NotImplementedException();
        }
    }
}
