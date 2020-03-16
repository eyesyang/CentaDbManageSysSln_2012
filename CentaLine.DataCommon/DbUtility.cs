using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CentaLine.DataCommon
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public abstract class DbUtility
    {

        public static string ParseSql(string sql)
        {
            try
            {
                sql = sql.Replace("\'", "\''");
                return sql;
            }
            catch (Exception ex)
            {
            	throw ex;
            }

        }        

        #region GetDataSet
        /// <summary>
        /// get DataSet by sql and  ConnectionString
        /// </summary>
        /// <param name="sql">string</param>
        /// <param name="connectionString">string</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string sql, string connectionString)
        {
            return GetDataSet(sql,connectionString,null);
        }
        public static DataSet GetDataSet(string sql, string connectionString, params SqlParameter[] sqlParameters)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                if(connection.State!=ConnectionState.Open)
                {
                    connection.Open();
                }

                if(sqlParameters!=null && sqlParameters.Length>0)
                {
                    foreach(var item in sqlParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(connection.State!=ConnectionState.Closed)
                {
                    connection.Close();
                }
                
            }
        }

        public static DataSet GetDataSetByProc(string procName, string connectionString)
        {
            return GetDataSetByProc(procName,connectionString,null);
        }
        public static DataSet GetDataSetByProc(string procName, string connectionString, params SqlParameter[] sqlParameters)        
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procName;

                if(connection.State!=ConnectionState.Open)
                {
                    connection.Open();
                }

                if (sqlParameters != null && sqlParameters.Length > 0)
                {
                    foreach (var item in sqlParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                DataSet dataSet = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(connection.State!=ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        #endregion

        #region GetDataTable
        public static DataTable GetDataTable(string sql, string connectionString)
        {
            return GetDataTable(sql, connectionString, null);
        }

        public static DataTable GetDataTable(string sql, string connectionString, params SqlParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if(sqlParameters!=null && sqlParameters.Length>0)
                {
                    foreach(var item in sqlParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable table = new DataTable();
                if (reader != null && reader.HasRows)
                {
                    table.Load(reader);
                    return table;
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

        public static DataTable GetDataTableByProc(string procName, string connectionString)
        {
            return GetDataTableByProc(procName,connectionString,null);
        }

        public static DataTable GetDataTableByProc(string procName, string connectionString, out int recordCount, params SqlParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = procName;
                command.CommandType = CommandType.StoredProcedure;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if (sqlParameters != null && sqlParameters.Length > 0)
                {
                    foreach (var item in sqlParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                DataTable table = new DataTable();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
               
                if (reader != null && reader.HasRows)
                {
                    table.Load(reader);
                }

                reader.Close();
                reader.Dispose();

                recordCount = Convert.ToInt32(command.Parameters["@recordCount"].Value ?? 0);
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

        public static DataTable GetDataTableByProc(string procName, string connectionString, params SqlParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = procName;
                command.CommandType = CommandType.StoredProcedure;
                
                if(connection.State!=ConnectionState.Open)
                {
                    connection.Open();
                }

                if(sqlParameters!=null && sqlParameters.Length>0)
                {
                    foreach(var item in sqlParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                DataTable table = new DataTable();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if(reader!=null && reader.HasRows)
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
                if(connection.State!=ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public static IList<DataTable> GetDataTableList(string sql, string connectionString)
        {
            return GetDataTableList(sql, connectionString,null);
        }
        public static IList<DataTable> GetDataTableList(string sql, string connectionString, params SqlParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                command.Connection = connection;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if (sqlParameters != null && sqlParameters.Length > 0)
                {
                    foreach (var item in sqlParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                List<DataTable> tableList = new List<DataTable>();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                do
                {
                    
                    DataTable schemaTable = reader.GetSchemaTable();                    
                    DataTable table = new DataTable();
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = row["ColumnName"].ToString();
                        column.DataType = (Type)row["DataType"];
                        table.Columns.Add(column);
                    }
                    while (reader.Read())
                    {                       
                        DataRow dataRow= table.NewRow();
                        foreach(DataRow row in schemaTable.Rows)
                        {
                            dataRow[row["ColumnName"].ToString()] = reader[row["ColumnName"].ToString()];
                        }
                        table.Rows.Add(dataRow);
                    }
                    tableList.Add(table);
                }
                while (reader.NextResult());

                reader.Close();
                reader.Dispose();
                return tableList;
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
        public static IList<DataTable> GetDataTableListByProc(string procName, string connectionString)
        {
            return GetDataTableList(procName,connectionString,null);
        }
        public static IList<DataTable> GetDataTableListByProc(string procName, string connectionString, params SqlParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = procName;
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if (sqlParameters != null && sqlParameters.Length > 0)
                {
                    foreach (var item in sqlParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                List<DataTable> tableList = new List<DataTable>();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                do
                {

                    DataTable schemaTable = reader.GetSchemaTable();
                    DataTable table = new DataTable();
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = row["ColumnName"].ToString();
                        column.DataType = (Type)row["DataType"];
                        table.Columns.Add(column);
                    }
                    while (reader.Read())
                    {
                        DataRow dataRow = table.NewRow();
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            dataRow[row["ColumnName"].ToString()] = reader[row["ColumnName"].ToString()];
                        }
                        table.Rows.Add(dataRow);
                    }
                    tableList.Add(table);
                }
                while (reader.NextResult());

                reader.Close();
                reader.Dispose();
                return tableList;      
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

        #endregion

        #region GetDataRow
        public static DataRow GetDataRow(string sql, string connectionString)
        {
            DataTable table = GetDataTable(sql,connectionString);
            if(table!=null && table.Rows.Count>0)
            {
                return table.Rows[0];
            }
            return null;
        }
        public static DataRow GetDataRow(string sql, string connectionString, params SqlParameter[] sqlParameters)
        {
            DataTable table = GetDataTable(sql, connectionString,sqlParameters);
            if (table != null && table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }
        public static DataRow GetDataRowByProc(string procName, string connectionString)
        {
            DataTable table = GetDataTableByProc(procName, connectionString);
            if (table != null && table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }
        public static DataRow GetDataRowByProc(string procName, string connectionString, params SqlParameter[] sqlParameters)
        {
            DataTable table = GetDataTableByProc(procName, connectionString, sqlParameters);
            if (table != null && table.Rows.Count > 0)
            {
                return table.Rows[0];
            }
            return null;
        }

        #endregion

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(string sql, string connectionString)
        {
            return ExecuteNonQuery(sql,connectionString,null);
        }
        public static int ExecuteNonQuery(string sql, string connectionString, params SqlParameter[] sqlparameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                
                if(connection.State!=ConnectionState.Open)
                {
                    connection.Open();
                }

                if(sqlparameters!=null && sqlparameters.Length>0)
                {
                    foreach(var item in sqlparameters)
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
                if(connection.State!=ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }
        public static int ExecuteNonQueryByProc(string procName, string connectionString)
        {
            return ExecuteNonQueryByProc(procName, connectionString, null);
        }
        public static int ExecuteNonQueryByProc(string procName, string connectionString, params SqlParameter[] sqlparameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procName;
                command.CommandTimeout = 1000 * 1000;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if (sqlparameters != null && sqlparameters.Length > 0)
                {
                    foreach (var item in sqlparameters)
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
        #endregion

        #region ExecuteScalar
        public static T ExecuteScalar<T>(string sql, string connectionString)
        {
            return ExecuteScalar<T>(sql, connectionString, null);
        }
        public static T ExecuteScalar<T>(string sql, string connectionString, params SqlParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if (sqlParameters != null && sqlParameters.Length > 0)
                {
                    foreach (var item in sqlParameters)
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
        public static T ExecuteScalarByProc<T>(string procName, string connectionString)
        {
            return ExecuteScalarByProc<T>(procName,connectionString,null);
        }
        public static T ExecuteScalarByProc<T>(string procName, string connectionString, params SqlParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procName;

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                if (sqlParameters != null && sqlParameters.Length > 0)
                {
                    foreach (var item in sqlParameters)
                    {
                        command.Parameters.Add(item);
                    }
                }

                object obj = command.ExecuteScalar();
                if(obj==null)
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
        #endregion
    }
}
