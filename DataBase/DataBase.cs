using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using StudentManagement.Controls;
namespace StudentManagement.DataBase
{
    public class StaticDataBase
    {
        private string dataBaseConnectorString = null;
        public string GetConnectorString()
        {
            return dataBaseConnectorString;
        }
        private MySqlConnection mysqlcon = null;
        public  void SetConnector(string dataBaseConnector)
        {
            dataBaseConnectorString = "server=127.0.0.1;port=3306;user=root;password=root; database=studentmanaged;";
            try
            {
                mysqlcon = new MySqlConnection(dataBaseConnectorString);
            }catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        public bool AddClass(String class_name,long class_id,long majID,long AcaID)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.SelectCommand = new MySqlCommand("AddClass", mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter[] mySqlParameter = new MySqlParameter[10];
            int indx = 0;
            mySqlParameter[indx++] = new MySqlParameter("?iClass_name", MySqlDbType.VarChar, 24);
            mySqlParameter[indx - 1].Value = class_name;
            mySqlParameter[indx++] = new MySqlParameter("?iClass_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = class_id;
            mySqlParameter[indx++] = new MySqlParameter("?imajor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = majID;
            mySqlParameter[indx++] = new MySqlParameter("?iAcademy_id", MySqlDbType.Int64, 1); 
            mySqlParameter[indx - 1].Value = AcaID;
            for (int i = 0; i < indx; ++i)
            {
                mySqlParameter[i].Direction = ParameterDirection.Input;
                mysqldata.SelectCommand.Parameters.Add(mySqlParameter[i]);
            }
            bool ret = true;
            try
            {
                //mysqldata.Fill(dataset, "Student");
                mysqldata.SelectCommand.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                ret = false;
            }
            mysqlcon.Close();

            return ret;
        }
        public bool AddStudent(Student info)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.SelectCommand = new MySqlCommand("InsertStudent", mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter[] mySqlParameter = new MySqlParameter[12];
            int indx = 0;
            mySqlParameter[indx++] = new MySqlParameter("?idn", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.stuID;
            mySqlParameter[indx++] = new MySqlParameter("?iname", MySqlDbType.VarChar, 24);
            mySqlParameter[indx - 1].Value = info.name;
            mySqlParameter[indx++] = new MySqlParameter("?igender", MySqlDbType.VarChar, 8);
            mySqlParameter[indx - 1].Value = info.gender;
            mySqlParameter[indx++] = new MySqlParameter("?inational", MySqlDbType.VarChar, 8);
            mySqlParameter[indx - 1].Value = info.national;
            mySqlParameter[indx++] = new MySqlParameter("?iGrade", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.grade;
            mySqlParameter[indx++] = new MySqlParameter("?imajor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.majID;
            mySqlParameter[indx++] = new MySqlParameter("?iminor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = null;
            mySqlParameter[indx++] = new MySqlParameter("?iclass_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.classID;
            mySqlParameter[indx++] = new MySqlParameter("?iPSD", MySqlDbType.VarChar, 24);
            mySqlParameter[indx - 1].Value = "666666";
            mySqlParameter[indx++] = new MySqlParameter("?ibirthday", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.birthday;
            mySqlParameter[indx++] = new MySqlParameter("?igraduate", MySqlDbType.VarChar, 8);
            mySqlParameter[indx - 1].Value = "U";
            mySqlParameter[indx++] = new MySqlParameter("?iOriginPlace", MySqlDbType.VarChar, 24);
            mySqlParameter[indx - 1].Value = info.From;
            for (int i = 0; i < indx; ++i)
            {
                mySqlParameter[i].Direction = ParameterDirection.Input;
                mysqldata.SelectCommand.Parameters.Add(mySqlParameter[i]);
            }
            bool ret = true;
            try
            {
                //mysqldata.Fill(dataset, "Student");
                mysqldata.SelectCommand.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
                ret = false;
            }
            mysqlcon.Close();

            return ret;
        }
        public bool AddTeacher(Teacher info)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.InsertCommand = new MySqlCommand("InsertTeacher", mysqlcon);
            mysqldata.InsertCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter[] mySqlParameter = new MySqlParameter[12];
            int indx = 0;
            mySqlParameter[indx++] = new MySqlParameter("?iTeacher_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.Teaid;
            mySqlParameter[indx++] = new MySqlParameter("?iTeacher_name", MySqlDbType.VarChar, 24);
            mySqlParameter[indx - 1].Value = info.name;
            mySqlParameter[indx++] = new MySqlParameter("?igender", MySqlDbType.VarChar, 8);
            mySqlParameter[indx - 1].Value = info.gender;
            mySqlParameter[indx++] = new MySqlParameter("?inational", MySqlDbType.VarChar, 8);
            mySqlParameter[indx - 1].Value = info.national;
            mySqlParameter[indx++] = new MySqlParameter("?imajor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.majID;
            mySqlParameter[indx++] = new MySqlParameter("?iAcademy_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.acaID;
            mySqlParameter[indx++] = new MySqlParameter("?iPSD", MySqlDbType.VarChar, 24);
            mySqlParameter[indx - 1].Value = "666666";
            mySqlParameter[indx++] = new MySqlParameter("?ibirthday", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.birthday;
            for (int i = 0; i < indx; ++i)
            {
                mySqlParameter[i].Direction = ParameterDirection.Input;
                mysqldata.InsertCommand.Parameters.Add(mySqlParameter[i]);
            }
            bool ret = true;
            try
            {
                mysqldata.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                ret = false;
            }
            mysqlcon.Close();

            return ret;
        }
        public bool AddClass(List<Class_info>Info)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.InsertCommand = new MySqlCommand("AddClass", mysqlcon);
            mysqldata.InsertCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter[] mySqlParameter = new MySqlParameter[4];
            int indx = 0;
            mySqlParameter[indx++] = new MySqlParameter("?iClass_name", MySqlDbType.VarChar, 24);
            mySqlParameter[indx++] = new MySqlParameter("?iClass_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?imajor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iAcademy_id", MySqlDbType.Int64, 1);
            for (int j = 0; j < indx; ++j)
            {
                mySqlParameter[j].Direction = ParameterDirection.Input;
                mysqldata.InsertCommand.Parameters.Add(mySqlParameter[j]);
            }
            MySqlTransaction mySqlTransaction = mysqlcon.BeginTransaction();
            mysqldata.InsertCommand.Transaction = mySqlTransaction;
            bool ret = true;
            try
            {

                for (int i = 0; i < Info.Count; ++i)
                {
                    int ind = 0;
                    mySqlParameter[ind++].Value = Info[i].name;
                    mySqlParameter[ind++].Value = Info[i].cls_id;
                    mySqlParameter[ind++].Value = Info[i].maj_id;
                    mySqlParameter[ind++].Value = Info[i].aca_id;

                    mysqldata.InsertCommand.ExecuteNonQuery();
                    if ((i > 0 && (i % 500 == 0)) || i == Info.Count - 1)
                    {
                        mySqlTransaction.Commit();
                        mySqlTransaction = mysqlcon.BeginTransaction();
                    }

                }
            }
            catch (MySqlException EX)
            {

                MessageBox.Show(EX.Message);
                mySqlTransaction.Rollback();
                ret = false;
            }
            mysqlcon.Close();

            return ret;
        }
        public bool AddStudent(List<Student> Info)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();
            mysqldata.InsertCommand = new MySqlCommand("InsertStudent", mysqlcon);
            mysqldata.InsertCommand.CommandType = CommandType.StoredProcedure;
           
            MySqlParameter[] mySqlParameter = new MySqlParameter[12];
            MySqlTransaction mySqlTransaction = mysqlcon.BeginTransaction();
            mysqldata.InsertCommand.Transaction = mySqlTransaction;
            int indx =0;
            mySqlParameter[indx++] = new MySqlParameter("?idn", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iname", MySqlDbType.VarChar, 24);
            mySqlParameter[indx++] = new MySqlParameter("?igender", MySqlDbType.VarChar, 8);
            mySqlParameter[indx++] = new MySqlParameter("?inational", MySqlDbType.VarChar, 8);
            mySqlParameter[indx++] = new MySqlParameter("?iGrade", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?imajor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iminor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iclass_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iPSD", MySqlDbType.VarChar, 24);
            mySqlParameter[indx++] = new MySqlParameter("?ibirthday", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?igraduate", MySqlDbType.VarChar, 8);
            mySqlParameter[indx++] = new MySqlParameter("?iOriginPlace", MySqlDbType.VarChar, 24);
            for (int i = 0; i < indx; ++i)
            {
                mySqlParameter[i].Direction = ParameterDirection.Input;
                mysqldata.InsertCommand.Parameters.Add(mySqlParameter[i]);
            }

            bool ret = true;
            try
            {
                for (int i = 0; ret && i < Info.Count; ++i)
                {
                    int ind = 0;
                    mySqlParameter[ind++].Value = Info[i].stuID;
                    mySqlParameter[ind++].Value = Info[i].name;
                    mySqlParameter[ind++].Value = Info[i].gender;
                    mySqlParameter[ind++].Value = Info[i].national;
                    mySqlParameter[ind++].Value = Info[i].grade;
                    mySqlParameter[ind++].Value = Info[i].majID;
                    mySqlParameter[ind++].Value = null;
                    mySqlParameter[ind++].Value = Info[i].classID;
                    mySqlParameter[ind++].Value = "666666";
                    mySqlParameter[ind++].Value = Info[i].birthday;
                    mySqlParameter[ind++].Value = "U";
                    mySqlParameter[ind++].Value = Info[i].From;
                    mysqldata.InsertCommand.ExecuteNonQuery();
                    if ((i > 0 && (i % 500 == 0)) || i == Info.Count - 1)
                    {
                        mySqlTransaction.Commit();
                        mySqlTransaction = mysqlcon.BeginTransaction();
                    }
                }
            }catch(MySqlException EX)
            {
                MessageBox.Show(EX.Message);
                mySqlTransaction.Rollback();
            }
            mysqlcon.Close();

            return ret;
        }
        private DataTable getXXXX(String table)
        {
            DataTable s = new DataTable();
            mysqlcon.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("select * from "+table+";", mysqlcon);
            mySqlCommand.CommandType = CommandType.Text;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            try
            {
                mySqlDataAdapter.Fill(s);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            mysqlcon.Close();
            return s;
        }
        
        public DataTable getAcadamy()
        {
            return getXXXX("academy_information");
        }
        public DataTable getMajor()
        {
            return getXXXX("major_information");
        }
        public DataTable getClassRoom()
        {
            return getXXXX("classroom_information");
        }
        private DataTable getXXXXByID(String table, String id_name, long ID)
        {
            DataTable s = new DataTable();
            mysqlcon.Open();
            MySqlCommand mySqlCommand =
                new MySqlCommand("select * from " + table + " where " + id_name + " = " + ID.ToString() + ";", mysqlcon);
            mySqlCommand.CommandType = CommandType.Text;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            try
            {
                mySqlDataAdapter.Fill(s);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            mysqlcon.Close();
            return s;
        }

        public DataTable getStudentByID(long ID)
        {
            return getXXXXByID("Student", "Student_id",ID);
        }
        public DataTable getManagerByID(long ID)
        {
            return getXXXXByID("jwc_information", "Clerk_id", ID);
        }
        public DataTable getTeacherByID(long ID)
        {
            return getXXXXByID("teacher", "Teacher_id", ID);
        }
        public DataTable getCourseOfClassRoom(long classRoomID,long TeacherID)
        {
            DataTable s = new DataTable();
            mysqlcon.Open();
            MySqlCommand mySqlCommand = 
                new MySqlCommand("select teacher_name ,Classroom_name,course_information.* from course_information,teacher,classroom_information where " +
                "teacher.teacher_id=course_information.teacher_id and course_information.classroom_id=classroom_information.classroom_id and (classroom_information.Classroom_id = " + classRoomID.ToString()+
                " or teacher.Teacher_id = " + TeacherID.ToString()+ ") ;",
                mysqlcon);
            mySqlCommand.CommandType = CommandType.Text;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            try
            {
                mySqlDataAdapter.Fill(s);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            mysqlcon.Close();
            return s;
        }
        /// <summary>
        /// 从某一个名字得到ID，要求事先写好存储过程
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Procedure"></param>
        /// <param name="_in"></param>
        /// <param name="_out"></param>
        /// <param name="failInfo"></param>
        /// <returns></returns>
        private long getXXID(String Name,String Procedure,String _in,String _out,String failInfo)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.SelectCommand = new MySqlCommand(Procedure, mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter name_para = new MySqlParameter(_in, MySqlDbType.VarChar, 24);
            name_para.Value = Name;
            mysqldata.SelectCommand.Parameters.Add(name_para);
            name_para.Direction = ParameterDirection.Input;

            MySqlParameter id_para = new MySqlParameter(_out, MySqlDbType.Int64, 1);
            id_para.Value = -1;
            mysqldata.SelectCommand.Parameters.Add(id_para);
            id_para.Direction = ParameterDirection.Output;

            try
            {
                mysqldata.SelectCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show(failInfo);
                mysqlcon.Close();
                return -1;
            }

            mysqlcon.Close();

            return (long)id_para.Value;
        }
        public long getAcadamyID(String AcaName)
        {
            return getXXID(AcaName, "GetAcademyID", "?iAcademy_name", "?iAcademy_id", "不存在" + AcaName);
        }
        public long getMajorID(String MajorName)
        {
            return getXXID(MajorName, "GetMajorID", "?iMajor_name", "?imajor_id", "不存在" + MajorName);
        }

        public long getClassID(String MajorName)
        {
            return getXXID(MajorName, "GetClassID", "?iClass_name", "?iClass_id", "不存在" + MajorName);
        }
        public bool addAcadamy(String AcaName)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.SelectCommand = new MySqlCommand("AddAcademy", mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter name_para = new MySqlParameter("?iAcademy_name", MySqlDbType.VarChar, 24);
            name_para.Value = AcaName;
            mysqldata.SelectCommand.Parameters.Add(name_para);
            name_para.Direction = ParameterDirection.Input;
            try
            {
                mysqldata.SelectCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("添加失败");
                mysqlcon.Close();
                return false;
            }

            mysqlcon.Close();
            return true ;
        }
        public DataTable getMajorOfAcademy(long AcademyID)
        {
            DataTable s = new DataTable();
            mysqlcon.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("select * from major_information where Academy_id = "+AcademyID.ToString()+";", mysqlcon);
            mySqlCommand.CommandType = CommandType.Text;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            try
            {
                mySqlDataAdapter.Fill(s);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            mysqlcon.Close();
            return s;
        }
        public bool addMajor(long Acaid,String majorName)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.SelectCommand = new MySqlCommand("AddMajor", mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter id_para = new MySqlParameter("?iAcademy_id", MySqlDbType.Int64, 1);
            id_para.Value = Acaid;
            mysqldata.SelectCommand.Parameters.Add(id_para);
            id_para.Direction = ParameterDirection.Input;

            MySqlParameter name_para = new MySqlParameter("?iMajor_name", MySqlDbType.VarChar, 24);
            name_para.Value = majorName;
            mysqldata.SelectCommand.Parameters.Add(name_para);
            name_para.Direction = ParameterDirection.Input;
            
            try
            {
                mysqldata.SelectCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("添加失败");
                mysqlcon.Close();
                return false;
            }

            mysqlcon.Close();
            return true;
        }

        public bool CheckPsd(String Procedure,long ID,String psd)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.SelectCommand = new MySqlCommand(Procedure, mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter id_para = new MySqlParameter("?idn", MySqlDbType.Int64, 1);
            id_para.Value = ID;
            mysqldata.SelectCommand.Parameters.Add(id_para);
            id_para.Direction = ParameterDirection.Input;

            MySqlParameter iPSD = new MySqlParameter("?iPSD", MySqlDbType.Int64, 1);
            iPSD.Value = psd;
            mysqldata.SelectCommand.Parameters.Add(iPSD);
            iPSD.Direction = ParameterDirection.Input;

            MySqlParameter res = new MySqlParameter("?Correct", MySqlDbType.Int32, 1);
            res.Value = null;
            mysqldata.SelectCommand.Parameters.Add(res);
            res.Direction = ParameterDirection.Output;

            try
            {
                mysqldata.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                mysqlcon.Close();
                return false;
            }
            
            mysqlcon.Close();
            if (res.Value == null) return false;
            return ((int)res.Value)!=0;
        }

        public bool InsertCourse(Course_info info)
        {

            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.InsertCommand = new MySqlCommand("InsertCourse", mysqlcon);
            mysqldata.InsertCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter[] mySqlParameter = new MySqlParameter[7];
            int indx = 0;
            mySqlParameter[indx++] = new MySqlParameter("?iTeacher_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.Teacher_Id;
            mySqlParameter[indx++] = new MySqlParameter("?icourse_name", MySqlDbType.VarChar, 24);
            mySqlParameter[indx - 1].Value = info.name;
            mySqlParameter[indx++] = new MySqlParameter("?iCredit", MySqlDbType.Int32, 1);
            mySqlParameter[indx - 1].Value = info.Credit;
            mySqlParameter[indx++] = new MySqlParameter("?iMax_capacity", MySqlDbType.Int32, 1);
            mySqlParameter[indx - 1].Value = info.MaxCap;
            mySqlParameter[indx++] = new MySqlParameter("?imajor_id", MySqlDbType.Int64, 1);
            if (info.maj_id == -1) mySqlParameter[indx - 1].Value = null;
            else mySqlParameter[indx - 1].Value = info.maj_id;
            
            mySqlParameter[indx++] = new MySqlParameter("?iClassroom_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.cls_id;

            mySqlParameter[indx++] = new MySqlParameter("?iClass_Time", MySqlDbType.Int64, 1);
            mySqlParameter[indx - 1].Value = info.Class_Time;
            for (int i = 0; i < indx; ++i)
            {
                mySqlParameter[i].Direction = ParameterDirection.Input;
                mysqldata.InsertCommand.Parameters.Add(mySqlParameter[i]);
            }
            bool ret = true;
            try
            {
                mysqldata.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("添加课程失败，可能是添加了课程名相同的课程");
                ret = false;
            }
            mysqlcon.Close();

            return ret;

        }

    }
}
