using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CentaLine.Common
{
    /// <summary>
    /// 日志操作类
    /// </summary>
    public class LogUtility
    {
        private static void Write(string filePath, string fileName, string content)
        {
            try
            {                
                DateTime dateTime = new DateTime();
                fileName = fileName + "_" + dateTime.ToString("yyyyMMdd")+".txt";               
                FileUtility.CreateDirectory(filePath);
                filePath = Path.Combine(filePath, fileName);
                FileUtility.AppendText(filePath, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void WriteException(string filePath, Exception exception)
        {
            try
            {                
                WriteException(filePath,exception.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void WriteException(string filePath, string content)
        {
            try
            {
                string fileName = "Exception";
                Write(filePath,fileName,content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void WriteInfo(string filePath, string information)
        {
            try
            {
                string fileName = "Information";
                Write(filePath, fileName, information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
