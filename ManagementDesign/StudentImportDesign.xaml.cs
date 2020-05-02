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
            public String gender;
            public long classID;
            public long majID;
            public long stuID;
            public long acaID;
            public int grade;
            public Student(String name,String national, String From,String birthday,String gender,int grade, long majID,long acaID)
            {
                this.name = name;
                this.national = national;
                this.From = From;
                this.birthday = birthday;
                this.majID = majID;
                this.acaID = acaID;
                this.grade = grade;
                this.gender = gender;
            }
            public int CompareTo(Student other)
            {
                if (grade != other.grade)
                {
                    return (int)(grade - other.grade);
                }
                if (acaID != other.acaID)
                {
                    return (int)(acaID - other.acaID);
                }
                if (majID != other.majID)
                {
                    return (int)(majID - other.majID);
                }
                int gend = gender.CompareTo(other.gender);
                if (0!=gend)
                {
                    return name.CompareTo(other.name);
                }
                else
                {
                    return gend;
                }
            }
        }
        MainWindow root;
        public StudentImportDesign(MainWindow root)
        {
            InitializeComponent();
            this.root = root;
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
                        //MessageBox.Show(aryline.Length.ToString() + " " + header.Length.ToString());
                        return false;
                    }
                    //给datatable加上列名
                    if (blnFlag)
                    {
                        blnFlag = false;
                        intColCount = aryline.Length;
                        
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
            
            String[] header = {"name","national","birthday","grade","place","major","gender" };
            if(OpenCSVFile(ref stuRawInfo, csvFilePath, header))
            {
                DataTable data = root.dataBase.getMajor();
                DataColumn[] keys = new DataColumn[1];
                keys[0] = data.Columns["major_name"];
                data.PrimaryKey = keys;

                List<Student> ls = new List<Student>();
                
                for(int i = 0; i < stuRawInfo.Rows.Count; ++i)
                {
                    try
                    {
                        DataRow dataRow = data.Rows.Find(((String)stuRawInfo.Rows[i]["major"]));
                        ls.Add(new Student(((String)stuRawInfo.Rows[i]["name"]), ((String)stuRawInfo.Rows[i]["national"]),
                            ((String)stuRawInfo.Rows[i]["place"]), ((String)stuRawInfo.Rows[i]["birthday"]),
                            ((String)stuRawInfo.Rows[i]["gender"]),
                            int.Parse(((String)stuRawInfo.Rows[i]["grade"]).ToString()),
                            long.Parse(dataRow["major_id"].ToString()),
                            long.Parse(dataRow["Academy_id"].ToString())
                            ));
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                ls.Sort();
                MessageBox.Show(ls[0].name+" "+ls[0].majID.ToString()+" "+ls[0].gender);
                long curGrade = ls[0].grade;
                int cnt = 0;
                for(int i = 0; i < ls.Count; ++i)
                {
                    if (curGrade != ls[i].grade)
                    {
                        cnt = 0;
                        curGrade = ls[i].grade;
                    }
                    ls[i].stuID = curGrade * 100 + 1;
                    ls[i].stuID *= 10000;
                    ls[i].stuID += ++cnt ;

                }
            }
            else
            {
                MessageBox.Show("文件不合法");
            }
        }
    }
}
