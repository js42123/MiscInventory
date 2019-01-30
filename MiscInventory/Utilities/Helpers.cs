using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AHPSystem.Helpers
{

    public static class RazorViewToString
    {
        public static string RenderViewToString(this Controller controller, string viewName, object model)
        {
            using (var writer = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                controller.ViewData.Model = model;
                var viewCxt = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, writer);
                viewCxt.View.Render(viewCxt, writer);
                return writer.ToString();
            }
        }
    }

    //Some Common functions. Only project-specific.
    public class ReturnArgs
    {
        public ReturnArgs()
        {
        }

        public int Status { get; set; }
        public string ViewString { get; set; }
    }
}