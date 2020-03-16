using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace CentaLine.Common
{
    /// <summary>
    /// 序列化，反序列化类
    /// </summary>
    public class SerializeUtility
    {
        //to do...
        public static string XmlSerializerToString(object input)
        {
            try
            {
                StreamReader reader = new StreamReader(XmlSerializer(input));                
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public static Stream XmlSerializer(object input)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                System.Xml.Serialization.XmlSerializer formatter = new XmlSerializer(input.GetType());
                formatter.Serialize(stream, input);
                return stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T XmlDeserializer<T>(Stream stream)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer formatter = new XmlSerializer(typeof(T));
                object obj = formatter.Deserialize(stream);
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
        }

        public static string BinarySerializerToString(object input)
        {
            try
            {
                StreamReader reader = new StreamReader(BinarySerializer(input));
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }

        public static Stream BinarySerializer(object input)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                BinaryFormatter formatter= new BinaryFormatter();
                formatter.Serialize(stream, input);
                return stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T BinaryDeserializer<T>(Stream stream)
        {
            try
            { 
                BinaryFormatter formatter = new BinaryFormatter();
                object obj= formatter.Deserialize(stream);
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
        }

        public static string SoapSerializerToString(object input)
        {
            try
            {
                StreamReader reader = new StreamReader(SoapSerializer(input));
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        public static Stream SoapSerializer(object input)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                SoapFormatter formatter = new SoapFormatter();
                formatter.Serialize(stream,input);
                return stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static T SoapDeserializer<T>(Stream stream)
        {
            try
            {
                SoapFormatter formatter = new SoapFormatter();
                object obj= formatter.Deserialize(stream);

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
        }
    }
}
