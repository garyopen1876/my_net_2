using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using my_net_2.Models;

namespace my_net_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "一個不是在製造bug，就是在製造更多bug的工程師";

            return View();
        }

        public ActionResult Hero()
        {
            ViewBag.Message = "英雄一覽";

            return View();
        }

        public ActionResult Weapon()
        {
            ViewBag.Message = "武器一覽";

            return View();
        }

        public ActionResult Monster()
        {
            ViewBag.Message = "怪物一覽";

            return View();
        }
    }
}