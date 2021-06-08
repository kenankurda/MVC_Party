using Microsoft.AspNetCore.Mvc;
using MVC_Party.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Party.Controllers
{
    public class VisitorsController : Controller
    {
        private static List<int> list = new List<int>();
        public IActionResult Index()
        {
            TempData["IsFamily"] = 0;
            TempData["MinAge"] = 0;
            TempData["MaxAge"] = 0;
            TempData["TotalVisitors"] = 0;

            return View();
        }
        public IActionResult Summary()
        {
            var max = list.Max();
            TempData["MaxAge"] = max;

            var min = list.Min();
            TempData["MinAge"] = min;

            var total = list.Count();
            TempData["TotalVisitors"] = total;

            return View("Summary");
        }
        [HttpPost]
        public IActionResult Index(Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                int isFamily = int.Parse(TempData.Peek("IsFamily").ToString());

                if (visitor.IsFamily)
                {
                    isFamily++;
                    TempData["IsFamily"] = isFamily;
                }

                list.Add(visitor.Age);
            }
            return View();
        }
    }
}
