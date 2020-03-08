using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMvvm
{
    class DBMng
    {
        public static bool Start = false;
        public static SQLiteConnection DB_CONNNECT = null;
        public static void Init()
        {
            try
            {
                DB_CONNNECT = new SQLiteConnection("Data Source=aa.db; Version=3");
                DB_CONNNECT.Open();
            }
            catch (Exception e)
            {
                DB_CONNNECT = null;
            }
        }

        public static SQLiteDataReader SELECT(string sql)
        {
            SQLiteDataReader sqlReader = null;
            try
            {
                if (DB_CONNNECT.State == ConnectionState.Closed)
                    DB_CONNNECT.Open();
                SQLiteCommand sqlCommand = new SQLiteCommand(sql, DB_CONNNECT);
                sqlReader = sqlCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                //SystemResource.WriteErrorMessage("SQL Select Error : " + sql);
                MessageBox.Show("SQL Select Error : " + sql);
            }
            finally
            {
                //SystemResource.DB_CONNNECT.Close();
            }
            return sqlReader;
        }

        public static SQLiteDataReader SELECT(string sql, string[] param)
        {
            SQLiteDataReader sqlReader = null;
            try
            {
                if (DB_CONNNECT.State == ConnectionState.Closed)
                    DB_CONNNECT.Open();
                SQLiteCommand sqlCommand = new SQLiteCommand(sql, DB_CONNNECT);
                for (int ind = 0; ind < param.Length; ind++)
                {
                    string paramStr = "@param" + ind;
                    sqlCommand.Parameters.AddWithValue(paramStr, param[ind]);
                }
                sqlReader = sqlCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                string parameter = "";
                for (int i = 0; i < param.Length; i++)
                {
                    parameter += string.Format(", {0}({1})", param[i], i);
                }
                //SystemResource.WriteErrorMessage("SQL Select Error : " + sql + parameter);
                MessageBox.Show("SQL Select Error : " + sql + parameter);
            }
            finally
            {
                //SystemResource.DB_CONNNECT.Close();
            }
            return sqlReader;
        }

        public static int EXCUTE(string sql)
        {
            int recordsAffected = 0;

            try
            {
                if (DB_CONNNECT.State == ConnectionState.Closed)
                    DB_CONNNECT.Open();
                SQLiteCommand sqlCommand = new SQLiteCommand(sql, DB_CONNNECT);
                recordsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //SystemResource.WriteErrorMessage("SQL Error : " + sql);
                MessageBox.Show("SQL Error : " + sql);
            }
            finally
            {
                //SystemResource.DB_CONNNECT.Close();
            }

            return recordsAffected;
        }

        public static int INSERT(string sql, string[] param)
        {
            int recordsAffected = 0;

            try
            {
                if (DB_CONNNECT.State == ConnectionState.Closed)
                    DB_CONNNECT.Open();
                SQLiteCommand sqlCommand = new SQLiteCommand(sql, DB_CONNNECT);

                if (param != null)
                {
                    for (int ind = 0; ind < param.Length; ind++)
                    {
                        string paramStr = "@param" + ind;
                        if (param[ind] == null)
                            sqlCommand.Parameters.AddWithValue(paramStr, DBNull.Value);
                        else
                            sqlCommand.Parameters.AddWithValue(paramStr, param[ind]);
                    }
                }
                recordsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string parameter = "";
                for (int i = 0; i < param.Length; i++)
                {
                    parameter += string.Format(", {0}({1})", param[i], i);
                }
                //SystemResource.WriteErrorMessage("SQL Error : " + sql + parameter + " - " + e.Message);
                MessageBox.Show("SQL Error : " + sql + parameter + " - " + e.Message);
            }
            finally
            {
                //SystemResource.DB_CONNNECT.Close();
            }

            return recordsAffected;
        }

        public static int INSERT(string sql, string[][] param)
        {
            int recordsAffected = 0;

            try
            {
                if (DB_CONNNECT.State == ConnectionState.Closed)
                    DB_CONNNECT.Open();
                SQLiteCommand sqlCommand = new SQLiteCommand(sql, DB_CONNNECT);
                //SqlCommand sqlCommand = new SqlCommand();
                //sqlCommand.Connection = SystemResource.DB_CONNNECTION;
                //sqlCommand.CommandText = sql;

                for (int ind = 0; ind < param.Length; ind++)
                {
                    for (int jnd = 0; jnd < param[ind].Length; jnd++)
                    {
                        string paramStr = "@param" + (ind * param[ind].Length + jnd);
                        if (param[ind][jnd] == null)
                            sqlCommand.Parameters.AddWithValue(paramStr, DBNull.Value);
                        else
                            sqlCommand.Parameters.AddWithValue(paramStr, param[ind][jnd]);
                    }
                }

                recordsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string parameter = "";
                for (int i = 0; i < param.Length; i++)
                {
                    for (int j = 0; j < param[i].Length; i++)
                    {
                        parameter += string.Format(", {0}({1},{2})", param[i][j], i, j);
                    }
                }
                //SystemResource.WriteErrorMessage("SQL Error : " + sql + parameter);

                MessageBox.Show("SQL Error : " + sql + parameter);
            }
            finally
            {
                //SystemResource.DB_CONNNECT.Close();
            }

            return recordsAffected;
        }

        public static int UPDATE(string sql, string[] param)
        {
            return INSERT(sql, param);
        }
    }
}
