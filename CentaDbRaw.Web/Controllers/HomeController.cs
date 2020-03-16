using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CentaDbRaw.Web.Services;
using CentaDbRaw.Web.Models;
using CentaLine.Common;

namespace CentaDbRaw.Web.Controllers
{
    public class JsonFilter : ActionFilterAttribute
    {
        public string Param { get; set; }
        public Type JsonDataType { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.ContentType.Contains("application/json"))
            {
                string inputContent;
                using (var sr = new StreamReader(filterContext.HttpContext.Request.InputStream))
                {
                    inputContent = sr.ReadToEnd();
                }
                var jss = new JavaScriptSerializer();
                var result = jss.Deserialize(inputContent, JsonDataType);
                filterContext.ActionParameters[Param] = result;
            }
        }
    }

    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }

        public JsonResult JsonData(int page = 1, int rows = 40)
        {
            var service = new BuildService();
            int recordCount;
            var models = service.GetList(page, rows, out recordCount);
            return Json(new { total = recordCount, rows = models });
        }
        public JsonResult Filter(CentaBuildType model)
        {
            int page = ConvertUtility.ToInt(Request["page"], 1);
            int rows = ConvertUtility.ToInt(Request["rows"], 40);
            var service = new BuildService();
            int recordCount;
            var models = service.Filter(model, page, rows, out recordCount);
            return Json(new {total = recordCount, rows = models});
        }

        [HttpPost]
        public JsonResult Update(CentaBuildType model)
        {
            var service = new BuildService();
            var rs = service.Update(model);
            return Json(new
                            {
                                rs = rs
                            });
        }
        [HttpPost]
        public JsonResult AddNew(CentaBuildType model)
        {
            var service = new BuildService();
            var id = service.AddNew(model);
            var rs = id > 0;
            return Json(new
                            {
                                rs = rs,
                                id = id
                            });
        }

        [HttpPost]
        [JsonFilter(Param = "id", JsonDataType = typeof(List<int>))]
        public JsonResult Delete(List<int> id)
        {
            var service = new BuildService();
            var o = Request.Form["id"];
            int effected = id.Count(service.Delete);
            var rs = effected > 0;
            return Json(new
                            {
                                rs = rs
                            });
        }
    }
}
