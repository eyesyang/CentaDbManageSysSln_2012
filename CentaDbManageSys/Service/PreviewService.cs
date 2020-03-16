using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Windows.Forms;
using CentaLine.Common;

namespace CentaDbManageSys.Service
{
    public class PreviewService
    {       
        private string _BuildId;
        private int _Width;         

        public PreviewService()
        {

        }
        public bool GenerateImage(string buildId)
        {
            try
            {
                this._BuildId = buildId;
                if (!ReadLog())
                {
                    if (CalculateWidth() > 0)
                    {
                        Bitmap bitmap = GetBitmap();
                        SaveImg(bitmap);
                        WriteLog();
                        return true;
                    }
                    ClearLog();
                    return false;
                }                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        private int CalculateWidth()
        {
            int width = 20;
            int border = 2;
            ArchitectureService service = new ArchitectureService();
            int columnCount = service.GetColumnCountByBuild(this._BuildId);           
            this._Width = width * columnCount + border * (1 + columnCount);
            return columnCount;
        }     
        private Bitmap GetBitmap()
        {
            try
            {
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.ScrollBarsEnabled = false;                 
                webBrowser.Navigate(GetUrl());
                webBrowser.Size = new Size(20, 10);    
                while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }                
                int height = webBrowser.Document.Body.ScrollRectangle.Height;
                webBrowser.Size = new Size(_Width, height);    
                Bitmap bitmap = new Bitmap(_Width, height);
                Rectangle rectangle = new Rectangle(0, 0, _Width, height);
                webBrowser.DrawToBitmap(bitmap, rectangle);                
                return bitmap;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string GetUrl()
        {
            Uri uri= HttpContext.Current.Request.Url;
            string url = "http://" + uri.Host;
            url += uri.Port == 80 ? "" : ":" + uri.Port;
            url = Path.Combine(url, "template/unit-preview.aspx?id=" + this._BuildId + "&_rnd=" + DateTime.Now.ToString("yyyyMMddhhmmss"));            
            return url;
        }
        private void SaveImg(Bitmap bitmap)
        {
            try
            {
                string appPath = HttpContext.Current.Request.PhysicalApplicationPath;
                string folderName = AppSettings.PreviewImgFolder;
                string imgFolder = Path.Combine(appPath, folderName);
                if (!FileUtility.IsExistDirectory(imgFolder))
                {
                    FileUtility.CreateDirectory(imgFolder);
                }
                bitmap.Save(Path.Combine(imgFolder, this._BuildId + ".jpeg"), ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void RefreshLog(string buildId)
        {
            try
            {
                if (string.IsNullOrEmpty(buildId))
                {
                    return;
                }
                string appPath = HttpContext.Current.Request.PhysicalApplicationPath;
                string logFolder = Path.Combine(appPath, AppSettings.PreviewLogFolder);
                if (FileUtility.IsExistDirectory(logFolder))
                {
                    int intervalDay = AppSettings.IntervalDay;
                    string currentTxt = DateTime.Now.ToString("yyyyMMdd");
                    while (true)
                    {
                        string filePath = Path.Combine(logFolder, currentTxt + ".txt");
                        if (FileUtility.IsExistFile(filePath))
                        {
                            string fileContent = FileUtility.FileToString(filePath);
                            if (fileContent.IndexOf(buildId) >= 0)
                            {
                                fileContent= fileContent.Replace(buildId, string.Empty);
                                FileUtility.WriteText(filePath, fileContent);
                            }
                        }
                        currentTxt = DateTime.Now.AddDays(-intervalDay).ToString("yyyyMMdd");
                        intervalDay--;
                        if (intervalDay == 0)
                        {
                            break;
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ReadLog()
        {
            try
            {
                string appPath = HttpContext.Current.Request.PhysicalApplicationPath;
                string logFolder = Path.Combine(appPath, AppSettings.PreviewLogFolder);
                if (FileUtility.IsExistDirectory(logFolder))
                {
                    int intervalDay = AppSettings.IntervalDay;
                    string currentTxt = DateTime.Now.ToString("yyyyMMdd");
                    while (true)
                    {
                        string filePath = Path.Combine(logFolder, currentTxt + ".txt");
                        if (FileUtility.IsExistFile(filePath))
                        {
                            string fileContent = FileUtility.FileToString(filePath);
                            if (fileContent.IndexOf(this._BuildId) >= 0)
                            {
                                string imgPath = Path.Combine(appPath, AppSettings.PreviewImgFolder, this._BuildId + ".jpeg");
                                if (FileUtility.IsExistFile(imgPath))
                                {
                                    return true;
                                }
                            }
                        }
                        currentTxt = DateTime.Now.AddDays(-intervalDay).ToString("yyyyMMdd");
                        intervalDay--;
                        if (intervalDay == 0)
                        {
                            break;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        private void WriteLog()
        {
            try
            {                
                string logFolder = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, AppSettings.PreviewLogFolder);
                if (!FileUtility.IsExistDirectory(logFolder))
                {
                    FileUtility.CreateDirectory(logFolder);
                }
                string currentTxt = DateTime.Now.ToString("yyyyMMdd");
                string filePath = Path.Combine(logFolder, currentTxt + ".txt");
                string fileContent = string.Empty;
                if (FileUtility.IsExistFile(filePath))
                {
                    fileContent= FileUtility.FileToString(filePath);
                    if (string.IsNullOrEmpty(fileContent))
                    {
                        fileContent = this._BuildId;
                        FileUtility.AppendText(filePath, fileContent);
                    }
                    else if (fileContent.IndexOf(this._BuildId) < 0)
                    {
                        fileContent += AppSettings.FirstSplit + this._BuildId;
                        FileUtility.WriteText(filePath, fileContent);
                    }
                }
                else
                {
                    fileContent = this._BuildId;
                    FileUtility.WriteText(filePath, fileContent);
                }                
            }
            catch (Exception ex)
            {
            	throw ex;
            }
        }
        private void ClearLog()
        {
            try
            {
                Random rnd = new Random();
                int clear = rnd.Next(-1, 9);
                if (clear < 0)
                {
                    string logFolder = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, AppSettings.PreviewLogFolder);
                    if (FileUtility.IsExistDirectory(logFolder))
                    {
                        int intervalDay = AppSettings.IntervalDay * -1;
                        int end = ConvertUtility.ToInt(DateTime.Now.AddDays(intervalDay).ToString("yyyyMMdd"));
                        string[] fileNames = FileUtility.GetFileNames(logFolder);
                        foreach (var item in fileNames)
                        {
                            string filePath = Path.Combine(logFolder, item);
                            int fileName = ConvertUtility.ToInt(FileUtility.GetFileNameNoExtension(filePath));
                            if (fileName < end)
                            {
                                FileUtility.DeleteFile(filePath);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }   
}