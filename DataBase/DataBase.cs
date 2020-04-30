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
    class StaticDataBase
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
            DataSet dataset = new DataSet();
            mysqldata.SelectCommand = new MySqlCommand("GetStudentInfoFromID", mysqlcon);
            mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
            MySqlParameter id_para = new MySqlParameter("?idn", MySqlDbType.Int64, 1);//mysql的存储过程参数是以?打头的！！！！
            id_para.Value = studentID;
            mysqldata.SelectCommand.Parameters.Add(id_para);
            id_para.Direction = ParameterDirection.Input;
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


            MySqlParameter[] mySqlParameter = new MySqlParameter[10];
            int indx = 0;
            mySqlParameter[indx++] = new MySqlParameter("?iname", MySqlDbType.VarChar, 12);
            mySqlParameter[indx++] = new MySqlParameter("?igender", MySqlDbType.VarChar, 1);
            mySqlParameter[indx++] = new MySqlParameter("?inational", MySqlDbType.VarChar, 12);
            mySqlParameter[indx++] = new MySqlParameter("?iacademic_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?imajor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iminor_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iclass_id", MySqlDbType.Int64, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iPSD", MySqlDbType.VarChar, 12);
            mySqlParameter[indx++] = new MySqlParameter("?ibirthday", MySqlDbType.Date, 1);
            mySqlParameter[indx++] = new MySqlParameter("?iguraduate", MySqlDbType.VarChar, 12);

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

                MessageBox.Show(mySqlParameter[0].Value.ToString());
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return res;
        }
    }
}
