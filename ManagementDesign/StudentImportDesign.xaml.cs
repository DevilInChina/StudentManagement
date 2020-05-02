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
using System.Data;
using System.IO;
using AutoMapper;
namespace StudentManagement.ManagementDesign
{
    /// <summary>
    /// StudentImportDesign.xaml 的交互逻辑
    /// </summary>
    public partial class StudentImportDesign : UserControl
    {
        private class Student:IComparable<Student>
        {
            public String name;
            public String national;
            public String From;
            public String birthday;
            public long classID;
            public long majID;
            public long stuID;
            public int CompareTo(Student other)
            {
                if (majID != other.majID)
                {
                    return (int)majID - (int)other.majID;
                }
                return name.CompareTo(other.name);
            }
        }
        public StudentImportDesign(MainWindow root)
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 代码来自 https://blog.csdn.net/weizhiai12/article/details/7099823
        /// 完成了对csv文件的读取。当csv不符合格式时认为读取失败
        /// </summary>
        /// <param name="mycsvdt">数据表</param>
        /// <param name="filepath">文件地址</param>
        /// <param name="header">数据表拟定名</param>
        /// <returns>是否添加成功</returns>
        private bool OpenCSVFile(ref DataTable mycsvdt, string filepath,string [] header)
        {
            string strpath = filepath; //csv文件的路径
            try
            {
                int intColCount = 0;
                bool blnFlag = true;

                DataColumn mydc;
                DataRow mydr;

                string strline;
                string[] aryline;
                StreamReader mysr = new StreamReader(strpath, System.Text.Encoding.Default);

                while ((strline = mysr.ReadLine()) != null)
                {
                    aryline = strline.Split(new char[] { ',' });
                    
                    if (aryline.Length != header.Length)
                    {
                        
                        return false;
                    }
                    //给datatable加上列名
                    if (blnFlag)
                    {
                        blnFlag = false;
                        intColCount = aryline.Length;
                        int col = 0;
                        for (int i = 0; i < aryline.Length; i++)
                        {
                            mydc = new DataColumn(header[i]);
                            mycsvdt.Columns.Add(mydc);
                        }
                    }

                    //填充数据并加入到datatable中
                    mydr = mycsvdt.NewRow();
                    for (int i = 0; i < intColCount; i++)
                    {
                        mydr[i] = aryline[i];
                    }
                    mycsvdt.Rows.Add(mydr);
                }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        private void button_importStudent_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog s = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> re = s.ShowDialog();

            String csvFilePath = null ;
            if (re == true)
            {
                csvFilePath = s.FileName;
            }
            
            DataTable stuRawInfo = new DataTable();
            String[] header = {"name","national","birthday","grade","place","major" };
            if(OpenCSVFile(ref stuRawInfo, csvFilePath, header))
            {
                
            }
            else
            {
                MessageBox.Show("文件不合法");
            }
        }
    }
}
