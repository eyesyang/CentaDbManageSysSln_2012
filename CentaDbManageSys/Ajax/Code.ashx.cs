using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using CentaLine.Common;
using System.IO;
using CentaDbManageSys.BLL;

namespace CentaDbManageSys.Ajax
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Code : IRequiresSessionState, IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                VerifyCode verifyCode = new VerifyCode();
                MemberService memberService = new MemberService();
                memberService.WriteVerifyCode(verifyCode.Text);
                MemoryStream ms = new MemoryStream();
                verifyCode.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                context.Response.ClearContent();
                context.Response.ContentType = "image/Gif";
                context.Response.BinaryWrite(ms.ToArray());
                context.Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
