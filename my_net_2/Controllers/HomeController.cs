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

        private readonly IConfiguration _config;//這很像ASP.net的WebConfigurationManager
        //在建構式使用相依性注入建立IConfiguration
        public HomeController(IConfiguration config)
        {
            this._config = config;
        }

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
            MySqlConnection con = new MySqlConnection(this._config.GetConnectionString("DatabaseContext"));
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

            MySqlConnection con = new MySqlConnection(this._config.GetConnectionString("DatabaseContext"));
            List<Weapon> weapon_list = new List<Weapon>();

            if (con.State != ConnectionState.Open)
                con.Open();
            MySqlCommand com = new MySqlCommand("select * From weapon", con);
            using(MySqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Weapon weapon = new Weapon();
                    weapon.weapon_name = dr["weapon_name"].ToString();
                    weapon.weapon_attack = Convert.ToInt32(dr["weapon_attack"].ToString());
                    weapon.weapon_own = dr["weapon_own"].ToString();
                    weapon_list.Add(weapon);
                }
            }
            if (con.State != ConnectionState.Closed)
                con.Close();

            ViewBag.List = weapon_list;

            return View();
        }

        public ActionResult Monster()
        {
            MySqlConnection con = new MySqlConnection(this._config.GetConnectionString("DatabaseContext"));

            if (con.State != ConnectionState.Open)
                con.Open();
            MySqlCommand com = new MySqlCommand("select * From monster", con);

            List<Monster> monster_list = new List<Monster>();

            using (MySqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    Monster monster = new Monster();
                    monster.monster_name = dr["monster_name"].ToString();
                    monster.monster_hp = Convert.ToInt32(dr["monster_hp"].ToString());
                    monster.monster_attack = Convert.ToInt32(dr["monster_attack"].ToString());
                    monster_list.Add(monster);
                }
            }
            if (con.State != ConnectionState.Closed)
                con.Close();

            ViewBag.List = monster_list;

            return View();
        }
    }
}