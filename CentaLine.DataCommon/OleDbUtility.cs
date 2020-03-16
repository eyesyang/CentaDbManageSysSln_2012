using System;
using System.Data;
using System.Data.OleDb;

namespace CentaLine.DataCommon
{
    /// <summary>
    /// 数据库操作类(OleDb)
    /// </summary>
    public class OleDbUtility
    {
        public static DataSet GetDataSet(string sql, string connectionString)
        {
            try
            {
                return GetDataSet(sql,connectionString,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetDataSet(string sql, string connectionString, params OleDbParameter[] oleDbParameters)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if(oleDbParameters!=null && oleDbParameters.Length>0)
                {
                    foreach(var item in oleDbParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                DataSet dataSet = new DataSet();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public static DataTable GetDataTable(string sql, string connectionString)
        {

            try
            {
                return GetDataTable(sql, connectionString,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDataTable(string sql, string connectionString, params OleDbParameter[] oleDbParamters)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if(oleDbParamters!=null && oleDbParamters.Length>0)
                {
                    foreach(var item in oleDbParamters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                DataTable table = new DataTable();
                OleDbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader != null && reader.HasRows)
                {
                    table.Load(reader);
                }
                reader.Close();
                reader.Dispose();
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }


        public static DataRow GetDataRow(string sql, string connectionString)
        {
            try
            {
                return GetDataRow(sql, connectionString, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataRow GetDataRow(string sql, string connectionString, params OleDbParameter[] oleDbParameters)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if(oleDbParameters!=null && oleDbParameters.Length>0)
                {
                    foreach(var item in oleDbParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                DataTable table = new DataTable();
                OleDbDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader != null && reader.HasRows)
                {
                    table.Load(reader);
                    return table.Rows[0];
                }
                reader.Close();
                reader.Dispose();
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        public static int ExecuteNonQuery(string sql, string connectionString)
        {
            try
            {
                return ExecuteNonQuery(sql, connectionString,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int ExecuteNonQuery(string sql, string connectionString, params OleDbParameter[] oleDbParameters)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if(oleDbParameters!=null && oleDbParameters.Length>0)
                {
                    foreach(var item in oleDbParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public static T ExecuteScalar<T>(string sql, string connectionString)
        {
            try
            {
                return ExecuteScalar<T>(sql,connectionString,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T ExecuteScalar<T>(string sql, string connectionString, params OleDbParameter[] oleDbParameters)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if(oleDbParameters!=null && oleDbParameters.Length>0)
                {
                    foreach(var item in oleDbParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                object obj = command.ExecuteScalar();
                if (obj == null)
                {
                    return default(T);
                }
                return (T)obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
    }
}
