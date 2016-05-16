using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zhsqw.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Internal;
using Microsoft.AspNet.Mvc.Rendering;
using System.Data;

namespace zhsqw.Controllers
{
    public class wuyeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult test()
        {
            DataTable data = new DataTable();
            data.Columns.Add();
            data.Columns.Add();
            data.Rows.Add(new string[] { "一月", "265" });
            data.Rows.Add(new string[] { "二月", "565" });
            data.Rows.Add(new string[] { "三月", "123" });
            ViewBag.c = FusionChart.RenderHelper.RenderChartByDataXML(data, "asc", "0", "chart", "月份", "费用");
            return View();
        }
    }
}
