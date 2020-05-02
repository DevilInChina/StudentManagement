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
namespace StudentManagement.DataBase
{
    public class StaticDataBase
    {
        private string dataBaseConnectorString = null;
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
        public MySqlParameterCollection getInfoFromId(long studentID)
        {

            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();
            
            mysqldata.SelectCommand = new MySqlCommand("GetStudentInfoFromID", mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter id_para = new MySqlParameter("?idn", MySqlDbType.Int64, 1);//mysql的存储过程参数是以?打头的！！！！
            id_para.Value = studentID;
            mysqldata.SelectCommand.Parameters.Add(id_para);
            id_para.Direction = ParameterDirection.Input;
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            MySqlParameter[] mySqlParameter = new MySqlParameter[10];
            int indx = 0;
            mySqlParameter[indx++] = new MySqlParameter("?iname", MySqlDbType.VarChar, 24);
            mySqlParameter[indx++] = new MySqlParameter("?igender", MySqlDbType.VarChar, 8);
            mySqlParameter[indx++] = new MySqlParameter("?inational", MySqlDbType.VarChar, 8);
            mySqlParameter[indx++] = new MySqlParameter("?iacademic_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?imajor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iminor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iclass_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iPSD", MySqlDbType.VarChar, 24);
            mySqlParameter[indx++] = new MySqlParameter("?ibirthday", MySqlDbType.Date, 1);
            mySqlParameter[indx++] = new MySqlParameter("?igraduate", MySqlDbType.VarChar, 8);

            MySqlParameterCollection res = mysqldata.SelectCommand.Parameters;
            
            for (int i = 0; i < indx; ++i)
            {
                mySqlParameter[i].Direction = ParameterDirection.Output;
                mysqldata.SelectCommand.Parameters.Add(mySqlParameter[i]);
            }

            try
            {
                //mysqldata.Fill(dataset, "Student");
                mysqldata.SelectCommand.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            mysqlcon.Close();
            return res;
        }

        public DataTable getAcadamy()
        {
            DataTable s = new DataTable();
            mysqlcon.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("select * from academy_information;", mysqlcon);
            mySqlCommand.CommandType = CommandType.Text;
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            try
            {
                mySqlDataAdapter.Fill(s);
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            mysqlcon.Close();
            return s;
        }

        public long getAcadamyID(String AcaName)
        {
            mysqlcon.Open();
            MySqlDataAdapter mysqldata = new MySqlDataAdapter();

            mysqldata.SelectCommand = new MySqlCommand("GetAcademyID", mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter name_para = new MySqlParameter("?iAcademy_name", MySqlDbType.VarChar, 24);
            name_para.Value = AcaName;
            mysqldata.SelectCommand.Parameters.Add(name_para);
            name_para.Direction = ParameterDirection.Input;

            MySqlParameter id_para = new MySqlParameter("?iAcademy_id", MySqlDbType.Int64, 1);
            id_para.Value = -1;
            mysqldata.SelectCommand.Parameters.Add(id_para);
            id_para.Direction = ParameterDirection.Output;

            try
            {
                mysqldata.SelectCommand.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("不存在该学院");
                mysqlcon.Close();
                return -1;
            }


            
            return (long)id_para.Value;
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
    }
}
