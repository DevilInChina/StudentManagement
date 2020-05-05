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
using StudentManagement.Controls;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace StudentManagement.ManagementDesign
{
    /// <summary>
    /// StudentImportDesign.xaml 的交互逻辑
    /// </summary>
    public partial class StudentImportDesign : UserControl,SecondPage
    {
        
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

        private int allocClass(int number)
        {
            int[] scal = { 29, 31 };
            int used = 0;
            int curmod = number % scal[0];
            for (int i = 1; i < scal.Length; ++i)
            {
                if (number % scal[i] <= curmod)
                {
                    used = i;
                    curmod = number % scal[i];
                }
            }///找到剩余人数较少的分配方案
            int ret = number / scal[used];
            if (ret == 0) return 1;

            return ret;
        }

        private String CsvFilePath;
        private void addStudent()
        {
            DataTable stuRawInfo = new DataTable();

            String[] header = { "name", "national", "birthday", "grade", "place", "major", "gender" };
            if (OpenCSVFile(ref stuRawInfo, CsvFilePath, header))
            {
                DataTable data = root.dataBase.getMajor();
                DataColumn[] keys = new DataColumn[1];
                keys[0] = data.Columns["major_name"];
                data.PrimaryKey = keys;

                Predeal.Visibility = Visibility.Hidden;
                AddInfo.Visibility = Visibility.Hidden;
                Predeal.Minimum = 0;
                AddInfo.Minimum = 0;
                
                
                List<Student> ls = new List<Student>();
                Predeal.Visibility = Visibility.Visible;
                for (int i = 0; i < stuRawInfo.Rows.Count; ++i)
                {
                    try
                    {
                        DataRow dataRow = data.Rows.Find(((String)stuRawInfo.Rows[i]["major"]));
                        ls.Add(new Student(((String)stuRawInfo.Rows[i]["name"]), ((String)stuRawInfo.Rows[i]["national"]),
                            ((String)stuRawInfo.Rows[i]["place"]), ((String)stuRawInfo.Rows[i]["birthday"]),
                            ((String)stuRawInfo.Rows[i]["gender"]),
                            int.Parse(((String)stuRawInfo.Rows[i]["grade"]).ToString()),
                            long.Parse(dataRow["major_id"].ToString()),
                            long.Parse(dataRow["Academy_id"].ToString()),
                            stuRawInfo.Rows[i]["major"].ToString()
                            ));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                ls.Sort();
                //MessageBox.Show(ls[0].name + " " + ls[0].majID.ToString() + " " + ls[0].gender);
                long curGrade = ls[0].grade;
                int cnt = 0;
                long curMajor = ls[0].majID;
                int total = 0;
                
                Student guards = new Student("g","n","f","1","s",-1,-1,-1,"s");
                ls.Add(guards);
                List<Class_info> Cls_ls = new List<Class_info>();

                Predeal.Maximum = ls.Count;
                
                for (int i = 0; i < ls.Count; ++i)
                {
                   
                    bool shiftGrade = false;
                    
                    if (curGrade != ls[i].grade)
                    {
                        shiftGrade = true;
                        curGrade = ls[i].grade;
                    }
                    if (shiftGrade || curMajor != ls[i].majID)
                    {
                        
                        int ClassNumber = allocClass(total);
                        long[] ClsID = new long[ClassNumber];
                        for (int id = 0; id < ClassNumber; ++id)
                        {
                            String ClsName = ls[i - 1].majName + (ls[i - 1].grade % 100) + "-" + (id + 1);
                            long Calclsid = ls[i - 1].grade;
                            Calclsid *= 1000;
                            Calclsid += ls[i - 1].majID;
                            Calclsid *= 100;
                            Calclsid+=id + 1;
                            Cls_ls.Add(new Class_info(ClsName, ls[i - 1].acaID, Calclsid, ls[i - 1].majID));
                            ClsID[id] = Calclsid;
                        }
                        int st = i - total;
                        for (int beg = 0; beg < total; ++beg)
                        {
                            ls[st + beg].classID = ClsID[beg % ClassNumber];
                        }
                        ls.Sort(st, total, null);
                        

                        for (int j = st; j < i; ++j)
                        {
                            ls[j].stuID = ls[j].grade * 100 + 1;
                            ls[j].stuID *= 10000;
                            ls[j].stuID += ++cnt;
                        }
                        if (shiftGrade)
                        {
                            //MessageBox.Show(cnt.ToString());
                            cnt = 0;
                        }
                        total = 0;
                        curMajor = ls[i].majID;
                        
                    }
                    ++total;
                }
                Predeal.Value = Predeal.Maximum ;
                AddInfo.Visibility = Visibility.Visible;
                ls.Remove(guards);
                AddInfo.Maximum = ls.Count+Cls_ls.Count;
                root.dataBase.AddClass(Cls_ls);
                root.dataBase.AddStudent(ls);
                AddInfo.Value = AddInfo.Maximum;
            }
            else
            {
                MessageBox.Show("文件不合法");
            }
        }
        
        private void button_importStudent_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog s = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> re = s.ShowDialog();

            if (re == true)
            {
                CsvFilePath = s.FileName;
            }
            addStudent();
        }

        private void Predeal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //MessageBox.Show("geto;");
            Predeal.Focus();
        }

        public void init(MainWindow curWindow)
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
            //throw new NotImplementedException();
        }
    }
}
