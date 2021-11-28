using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using my_net_2.Models;
using Microsoft.Extensions.Configuration;

namespace my_net_2.Controllers
{
    public class BattleController : Controller
    {
        private readonly IConfiguration _config;//這很像ASP.net的WebConfigurationManager
        //在建構式使用相依性注入建立IConfiguration
        public BattleController(IConfiguration config)
        {
            this._config = config;
        }

        public ActionResult Battle_Template()
        {
            List<String> box_word = new List<String>();
            if (2>1)
            {
                /* 先連接資料庫 */
                MySqlConnection con = new MySqlConnection(this._config.GetConnectionString("DatabaseContext"));

                if (con.State != ConnectionState.Open)
                    con.Open();

                Hero hero = new Hero();
                string hero_call = "select * From hero where hero_name = '狗勇者'";
                MySqlCommand com_hero = new MySqlCommand(hero_call, con);
                
                using(MySqlDataReader dr = com_hero.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        hero.hero_name = dr["hero_name"].ToString();
                        hero.hero_hp = Convert.ToInt32(dr["hero_hp"].ToString());
                        hero.hero_base_attack = Convert.ToInt32(dr["hero_base_attack"].ToString());
                    }
                }


                Weapon weapon = new Weapon();
                string weapon_call = "select * From weapon where weapon_name = '小刀'";
                MySqlCommand com_weapon = new MySqlCommand(weapon_call, con);
                using (MySqlDataReader dr = com_weapon.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        weapon.weapon_name = dr["weapon_name"].ToString();
                        weapon.weapon_attack = Convert.ToInt32(dr["weapon_attack"].ToString());
                        weapon.weapon_own = dr["weapon_own"].ToString();
                    }
                }

                Monster monster = new Monster();
                string monster_call = "select * From monster where monster_name='小怪'";
                MySqlCommand com_monster = new MySqlCommand(monster_call, con);
                using (MySqlDataReader dr = com_monster.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        monster.monster_name = dr["monster_name"].ToString();
                        monster.monster_hp = Convert.ToInt32(dr["monster_hp"].ToString());
                        monster.monster_attack = Convert.ToInt32(dr["monster_attack"].ToString());
                    }
                }



                int all_attack_point = hero.hero_base_attack + weapon.weapon_attack;

                while (hero.hero_hp > 0 && monster.monster_hp > 0)
                {
                    
                    monster.monster_hp -= (hero.hero_base_attack + weapon.weapon_attack);
                    box_word.Add(hero.hero_name + " 使用 " + weapon.weapon_name + " 給予 " + monster.monster_name + " " + all_attack_point + " 點傷害    " + monster.monster_name + "血量剩餘" + monster.monster_hp);
                    hero.hero_hp -= monster.monster_attack;
                    box_word.Add(monster.monster_name + " 給予 " + hero.hero_name + " " + monster.monster_attack + " 點傷害   " + hero.hero_name + "血量剩餘" + hero.hero_hp);

                }

                if (con.State != ConnectionState.Closed)
                    con.Close();
            }

            ViewBag.List = box_word;
            return View();
        }
    }
}