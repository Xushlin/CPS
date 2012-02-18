using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPackTool.Service;

namespace HtmlAgilityPack.Tool.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShowService _showService;

        public HomeController(IShowService showService)
        {
            _showService = showService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            int totalCount = 0;
            var model = _showService.GetPage(1, ref totalCount);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
