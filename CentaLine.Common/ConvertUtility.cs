using System;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace CentaLine.Common
{
    /// <summary>
    /// 数据类型转换类
    /// </summary>
    public abstract class ConvertUtility
    {
        public static string Trim(object input)
        {
            try
            {
                if(input==null)
                {
                    return string.Empty;
                }
                return input.ToString().Trim();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string Trim(object input, string defaultValue)
        {
            if(input==null)
            {
                return defaultValue;
            }
            else
            {
                string rs = input.ToString().Trim();
                if (string.IsNullOrEmpty(rs))
                {
                    return defaultValue;
                }
                return rs;
            }
        }

        public static int ToInt(object input)
        {
            return ToInt(input,0);
        }
        public static int ToInt(object input, int defaultValue)
        {
            try
            {
                if(input==null)
                {
                    return defaultValue;
                }                
                return Convert.ToInt32(input);
                
            }
            catch
            {
                return defaultValue;
            }
        }

        public static decimal ToDecimal(object input)
        {
            return ToDecimal(input,0.00m);
        }
        public static decimal ToDecimal(object input, decimal defaultValue)
        {
            try
            {
                if(input==null)
                {
                    return defaultValue;
                }
                return Convert.ToDecimal(input);
            }
            catch
            {
                return defaultValue;
            }
        }
        public static float ToFloat(object input)
        {
            return ToFloat(input,0);
        }
        public static float ToFloat(object input, float defaultValue)
        {
            try
            {
                if (input == null)
                {
                    return defaultValue;
                }
                return Convert.ToSingle(input);
            }
            catch
            {
                return defaultValue;
            }
        }
        public static double ToDouble(object input)
        {
            return ToDouble(input,0);
        }
        public static double ToDouble(object input, double defaultValue)
        {
            try
            {
                if(input==null)
                {
                    return defaultValue;
                }
                return Convert.ToDouble(input);
            }
            catch
            {
                return defaultValue;
            }
        }
        public static int ToASCIICode(string input)
        {
            try
            {

                System.Text.ASCIIEncoding encode = new System.Text.ASCIIEncoding();
                int rs = (int)encode.GetBytes(input)[0];
                return rs;
            }
            catch
            {
                return -1;
            }
        }
        public static bool ToBoolean(object input)
        {
            return ToBoolean(input,false);
        }
        public static bool ToBoolean(object input,bool defaultValue)
        {
            try
            {
                if(input==null)
                {
                    return defaultValue;
                }
                string str = Trim(input);
                if(str.Equals("y", StringComparison.OrdinalIgnoreCase) || str.Equals("yes",StringComparison.OrdinalIgnoreCase) || str.Equals("true", StringComparison.OrdinalIgnoreCase) || str.Equals("on",StringComparison.OrdinalIgnoreCase) || str.Equals("1", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return defaultValue;
            }
        }
        public static DateTime ToDateTime(object input)
        {
            return ToDateTime(input,new DateTime(2000,1,1));
        }
        public static DateTime ToDateTime(object input,DateTime defaultValue)
        {
            try
            {
                if(input==null)
                {
                    return defaultValue;
                }
                return Convert.ToDateTime(input);
            }
            catch
            {
                return defaultValue;
            }
        }
        public static long ToInt64(object input)
        {
            return ToInt64(input,0);
        }
        public static long ToInt64(object input, long defaultValue)
        {
            try
            {
                if(input==null)
                {
                    return defaultValue;
                }
                return Convert.ToInt64(input);
            }
            catch
            {
                return defaultValue;
            }
        }
        public static string ToChinese(string text,bool Is2Simple)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return string.Empty;
                }
                if (string.IsNullOrEmpty(text.Trim()))
                {
                    return string.Empty;
                }
                string ctext = string.Empty;
                if (Is2Simple == false)
                {
                    ctext = ChineseConverter.Convert(text, ChineseConversionDirection.SimplifiedToTraditional);
                }
                else
                {
                    ctext = ChineseConverter.Convert(text, ChineseConversionDirection.TraditionalToSimplified);
                }
                return ctext;
            }
            catch
            {
                return string.Empty;
            }
        }
        public static IList<T> Table2Model<T>(DataTable table) where T : class
        {
            try
            {
                List<T> rs = new List<T>(); 
                if (table != null && table.Rows.Count > 0)
                {                    
                    Type type = typeof(T);
                    if (type.Name.Equals("string", StringComparison.OrdinalIgnoreCase))
                    {                        
                        foreach (DataRow row in table.Rows)
                        {
                            rs.Add((T)row[0]);
                        }
                    }
                    else
                    {
                        ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(DataRow) });
                        foreach (DataRow row in table.Rows)
                        {
                            rs.Add((T)constructor.Invoke(new DataRow[] { row }));
                        }
                    }
                }
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T Row2Model<T>(DataRow row) where T : class
        {
            try
            {
                Type type = typeof(T);
                ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(DataRow) });
                return (T)constructor.Invoke(new DataRow[] { row });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }

    
}
