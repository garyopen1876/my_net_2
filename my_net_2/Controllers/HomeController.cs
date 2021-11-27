using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using my_net_2.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

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
            /*連線資料庫*/
            MySqlConnection con = new MySqlConnection("server=localhost; Port=3306;User Id=root;Password=DaiTomoko1412;Database=my_net_first;charset=utf8;");
            /*儲存的陣列*/
            List<Hero> list = new List<Hero>();
            if (con.State != ConnectionState.Open)
                con.Open();
            /*指令*/
            string sql = "select * From hero";
            MySqlCommand com = new MySqlCommand(sql,con);

            using (MySqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Hero hero = new Hero();
                    hero.hero_name = dr["hero_name"].ToString();
                    hero.hero_hp = Convert.ToInt32(dr["hero_hp"].ToString());
                    hero.hero_base_attack = Convert.ToInt32(dr["hero_base_attack"].ToString());
                    list.Add(hero);
                }
            }


            /*關閉資料庫使用*/
            if (con.State != ConnectionState.Closed)
                con.Close();

            /*回傳陣列*/
            ViewBag.List = list;

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