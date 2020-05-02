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
        private long acaId;
        int Cnt = 0;
        public SingleAcademyPage(MainWindow prev,long AcademyID,String AcademyName)
        {
            InitializeComponent();
            root = prev;
            acaId = AcademyID;
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

        private void button_add_major(object sender, RoutedEventArgs e)
        {
            Controls.InputBox info = new Controls.InputBox("请输入新增专业名");

            info.PassDataBetweenForm += new Controls.InputBox.PassDataBetweenFormHandler(FinishAddButtonClick);
            info.Show();
            info.Activate();
        }
        private void FinishAddButtonClick(object sender, Controls.PassDataWinFormEventArgs e)
        {
            String majorNane = e.Info;
            root.dataBase.addMajor(acaId,majorNane);
            long k = root.dataBase.getAcadamyID(majorNane);
            if (k > 0)
            {
                addListItem(majorNane);
            }
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
