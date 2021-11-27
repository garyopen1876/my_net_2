using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace my_net_2.Controllers
{
    public class BattleController : Controller
    {   

        public ActionResult Battle_Template()
        {

            return View();
        }
    }
}