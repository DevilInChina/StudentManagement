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
using StudentManagement.ManagementDesign;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace StudentManagement.ManagementDesign
{
    /// <summary>
    /// AcadamyPageDesign.xaml 的交互逻辑
    /// </summary>
    public partial class AcadamyPageDesign : UserControl,SecondPage
    {

        MainWindow root;
        DependencyProperty dp;
        int Cnt;
        DataTable data;
        SingleAcademyPage.SingleAcademyPage curPage = null;
        public AcadamyPageDesign(MainWindow prev)
        {
            InitializeComponent();
            root = prev;
            Menu1.Background = new SolidColorBrush(prev.MainThemeColor);
            dp = DependencyProperty.Register("MenuItemValue", typeof(SingleAcademyPage.SingleAcademyPage), typeof(MenuItem));
            data = root.dataBase.getAcadamy();
            for (Cnt = 0; Cnt < data.Rows.Count;)
            {
                String temp = data.Rows[Cnt]["Academy_name"].ToString();
                addMenuItem(temp);
                ((MenuItem)Menu1.Items[Cnt - 1]).
                    SetValue(dp, new SingleAcademyPage.SingleAcademyPage(
                        root, ((long)(data.Rows[Cnt-1]["Academy_id"])), temp));
            }
        }
        public void addMenuItem(String header)
        {
            MenuItem menuItem = new MenuItem();
            
            menuItem.Click += MenuItem_Click;
            menuItem.Header = header;
            Menu1.Items.Add(menuItem);
            
            ++Cnt;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (curPage == null)///初始化
            {
                curPage = (SingleAcademyPage.SingleAcademyPage)((MenuItem)sender).GetValue(dp); 
                SubPanel.Children.Clear();
                SubPanel.Children.Add(curPage);

            }
            else if (curPage == (SingleAcademyPage.SingleAcademyPage)((MenuItem)sender).GetValue(dp))///不是初始化重新点击当前页面
            {
                
            }
            else///更换页面
            {

                curPage = (SingleAcademyPage.SingleAcademyPage)((MenuItem)sender).GetValue(dp);
                SubPanel.Children.Clear();
                SubPanel.Children.Add(curPage);
            }

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
                ((MenuItem)Menu1.Items[Cnt - 1]).
                    SetValue(dp, new SingleAcademyPage.SingleAcademyPage(
                        root, k, acaName));
            }
        }

        public void init(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }
    }
}
