using System;
using System.Data;
using System.Web;

namespace CentaLine.DataCommon
{
    /// <summary>
    /// xml操作类 
    /// </summary>
    public class XmlUtility
    {

        //public static void AppendChild()
        //{ }
        //public static void DeleteChild()
        //{ }
        //public static void FindChild()
        //{ }
        //public static void UpdateChild()
        //{ }

        #region GetDataSetByXml
        /// 
        /// 读取xml直接返回DataSet 
        /// 
        /// xml文件相对路径 
        /// 
        public static DataSet GetDataSetByXml(string xmlPath)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(xmlPath));
                if (ds.Tables.Count > 0)
                {
                    return ds;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region GetDataViewByXml
        /// 
        /// 读取Xml返回一个经排序或筛选后的DataView 
        /// 
        /// 
        /// 筛选条件,如："name = ＇kgdiwss＇" 
        /// 排序条件,如："Id desc" 
        /// 
        public static DataView GetDataViewByXml(string xmlPath, string where, string sort)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(xmlPath));
                DataView dv = new DataView(ds.Tables[0]);
                if (sort != null)
                {
                    dv.Sort = sort;
                }
                if (where != null)
                {
                    dv.RowFilter = where;
                }
                return dv;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion


        #region WriteXmlByDataSet
        /// 
        /// 向Xml文件插入一行数据 
        /// 
        /// xml文件相对路径 
        /// 要插入行的列名数组,如：string[] Columns = {"name","IsMarried"}; 
        /// 要插入行每列的值数组,如：string[] ColumnValue={"明天去要饭","false"}; 
        /// 成功返回true,否则返回false 
        public static bool WriteXmlByDataSet(string xmlPath, string[] columns, string[] columnValue)
        {
            try
            {
                //根据传入的XML路径得到.XSD的路径,两个文件放在同一个目录下 
                string xsdPath = xmlPath.Substring(0, xmlPath.IndexOf(".")) + ".xsd";

                DataSet ds = new DataSet();
                //读xml架构,关系到列的数据类型 
                ds.ReadXmlSchema(GetXmlFullPath(xsdPath));
                ds.ReadXml(GetXmlFullPath(xmlPath));
                DataTable dt = ds.Tables[0];
                //在原来的表格基础上创建新行 
                DataRow newRow = dt.NewRow();

                //循环给一行中的各个列赋值 
                for (int i = 0; i < columns.Length; i++)
                {
                    newRow[columns[i]] = columnValue[i];
                }
                dt.Rows.Add(newRow);
                dt.AcceptChanges();
                ds.AcceptChanges();

                ds.WriteXml(GetXmlFullPath(xmlPath));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion


        #region UpdateXmlRow
        /// 
        /// 更行符合条件的一条Xml记录 
        /// 
        /// XML文件路径 
        /// 列名数组 
        /// 列值数组 
        /// 条件列名 
        /// 条件列值 
        /// 
        public static bool UpdateXmlRow(string xmlPath, string[] columns, string[] columnValue, string whereColumnName, string whereColumnValue)
        {
            try
            {
                string xsdPath = xmlPath.Substring(0, xmlPath.IndexOf(".")) + ".xsd";

                DataSet ds = new DataSet();
                //读xml架构,关系到列的数据类型 
                ds.ReadXmlSchema(GetXmlFullPath(xsdPath));
                ds.ReadXml(GetXmlFullPath(xmlPath));

                //先判断行数 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //如果当前记录为符合Where条件的记录 
                        if (ds.Tables[0].Rows[i][whereColumnName].ToString().Trim().Equals(whereColumnValue))
                        {
                            //循环给找到行的各列赋新值 
                            for (int j = 0; j < columns.Length; j++)
                            {
                                ds.Tables[0].Rows[i][columns[j]] = columnValue[j];
                            }
                            //更新DataSet 
                            ds.AcceptChanges();
                            //重新写入XML文件 
                            ds.WriteXml(GetXmlFullPath(xmlPath));
                            return true;
                        }
                    }

                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion


        #region DeleteXmlRowByIndex
        /// 
        /// 通过删除DataSet中iDeleteRow这一行,然后重写Xml以实现删除指定行 
        /// 
        /// 
        /// 要删除的行在DataSet中的Index值 
        public static bool DeleteXmlRowByIndex(string xmlPath, int deleteRow)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(xmlPath));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //删除符号条件的行 
                    ds.Tables[0].Rows[deleteRow].Delete();
                }
                ds.WriteXml(GetXmlFullPath(xmlPath));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion


        #region DeleteXmlRows
        /// 
        /// 删除strColumn列中值为ColumnValue的行 
        /// 
        /// xml相对路径 
        /// 列名 
        /// strColumn列中值为ColumnValue的行均会被删除 
        /// 
        public static bool DeleteXmlRows(string xmlPath, string column, string[] columnValue)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(xmlPath));

                //先判断行数 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //判断行多还是删除的值多,多的for循环放在里面 
                    if (columnValue.Length > ds.Tables[0].Rows.Count)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < columnValue.Length; j++)
                            {
                                if (ds.Tables[0].Rows[i][column].ToString().Trim().Equals(columnValue[j]))
                                {
                                    ds.Tables[0].Rows[i].Delete();
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < columnValue.Length; j++)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[i][column].ToString().Trim().Equals(columnValue[j]))
                                {
                                    ds.Tables[0].Rows[i].Delete();
                                }
                            }
                        }
                    }
                    ds.WriteXml(GetXmlFullPath(xmlPath));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion


        #region DeleteXmlAllRows
        /// 
        /// 删除所有行 
        /// 
        /// XML路径 
        /// 
        public static bool DeleteXmlAllRows(string xmlPath)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(GetXmlFullPath(xmlPath));
                //如果记录条数大于0 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //移除所有记录 
                    ds.Tables[0].Rows.Clear();
                }
                //重新写入,这时XML文件中就只剩根节点了 
                ds.WriteXml(GetXmlFullPath(xmlPath));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion


        #region GetXmlFullPath
        /// 
        /// 返回完整路径 
        /// 
        /// Xml的路径 
        /// 
        public static string GetXmlFullPath(string path)
        {
            if (path.IndexOf(":") > 0)
            {
                return path;
            }
            else
            {
                return HttpContext.Current.Request.ApplicationPath + path;                
            }
        }
        #endregion
    }
}