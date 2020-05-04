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
using System.Windows.Shapes;
using System.Data;
namespace StudentManagement.Controls
{
    /// <summary>
    /// AddTeacherWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddTeacherWindow : Window
    {
        private DataTable acaInfo;
        private DataTable majInfo;
        private MainWindow root;
        DependencyProperty dp;
        int UserIDSize = 0;
        String Gender = null;
        long curAcaID;
        long curMajID;
        public AddTeacherWindow(String title,DataTable acaInfo,DataTable majInfo,MainWindow root)
        {
            InitializeComponent();
            this.acaInfo = acaInfo;
            this.majInfo = majInfo;
            this.root = root;
            dp = root.ComboBoxItem_Long;
            //ImageBrush b3 = new ImageBrush();
            //b3.ImageSource = new BitmapImage(new Uri("../../Pictures/kon3.png", UriKind.RelativeOrAbsolute));
            //this.Background = b3;
            
            for (int i= 0; i < acaInfo.Rows.Count; ++i)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = acaInfo.Rows[i]["Academy_name"];
                comboBoxItem.SetValue(dp, acaInfo.Rows[i]["Academy_id"]);
                AcademyBox.Items.Add(comboBoxItem);
            }
            this.Title = title;
            this.Show();
            curAcaID = 0;
            curMajID = 0;
        }

        private void AcademyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem Selected = (ComboBoxItem)AcademyBox.SelectedItem;
            DataRow[]temp =  majInfo.Select("Academy_id = "+Selected.GetValue(dp));
            curAcaID = (long)Selected.GetValue(dp);
            curMajID = 0;
            MajorBox.Items.Clear();
            for(int i = 0; i < temp.Length; ++i)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = temp[i]["major_name"];
                comboBoxItem.SetValue(dp, temp[i]["major_id"]);
                MajorBox.Items.Add(comboBoxItem);
            }
        }

        private void male_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "M";
        }

        private void female_Checked(object sender, RoutedEventArgs e)
        {
            Gender = "F";
        }

        private void USERID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());

            int sa = e.Key - Key.D0;
            int sb = e.Key - Key.NumPad0;
            if ((sa >= 0 && sa <= 9) || (sb >= 0 && sb <= 9))
            {
                if (UserIDSize < 15)
                {
                    e.Handled = false;
                    ++UserIDSize;
                }
                else
                {
                    e.Handled = true;
                }

            }
            else
            {
                if (e.Key != Key.Enter && e.Key != Key.Back && e.Key != Key.Tab)
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.Key == Key.Back && UserIDSize > 0)
                    {
                        --UserIDSize;
                    }
                    e.Handled = false;
                }
            }
        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            bool can = true;
            if(curMajID ==0 || curAcaID == 0 || Gender==null)
            {
                can = false;
            }
            if(can &&(nameBox.Text==null || nationalBox.Text==null))
            {
                can = false;
            }
            if (can && datePicker.SelectedDate==null)
            {
                can = false;
            }
            if(can && USER_ID.Text != null)
            {
                string[] info = datePicker.SelectedDate.ToString().Split(' ');
                string[] dat = info[0].Split('/');
                if (dat[1].Length < 2)
                {
                    dat[1] = "0" + dat[1];
                }
                if (dat[2].Length < 2)
                {
                    dat[2] = "0" + dat[2];
                }
                bool ret = root.dataBase.AddTeacher(new Teacher(
                    nameBox.Text,nationalBox.Text,(dat[0]+dat[1]+dat[2]),Gender,curMajID,curAcaID,
                    long.Parse(USER_ID.Text)
                    ));
                MessageBox.Show("添加" + (ret?"成功":"失败"));
            }
        }

        private void MajorBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem Selected = (ComboBoxItem)MajorBox.SelectedItem;
            if (Selected != null)
            {
                curMajID = (long)Selected.GetValue(dp);
            }
            else
            {
                curMajID = 0;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
