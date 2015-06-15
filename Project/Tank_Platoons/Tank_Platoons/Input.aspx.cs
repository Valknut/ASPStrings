using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.Entity.Validation;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Tank_Platoons.App_Code;
using System.IO;


namespace Tank_Platoons
{
    public partial class Input : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                XMLCreatorLINQ creator = new XMLCreatorLINQ();
                TPlatoon2Entities1 context = new TPlatoon2Entities1();
                Tank_Platoons tp = new Tank_Platoons();
                tp.id = inptid.Text;
                tp.name = inptname.Text;
                tp.nation = inptnation.Text;
                tp.rating = inptrating.Text;
                tp.win_rate = inptwr8.Text;

                Tropheys trophey = new Tropheys();
                trophey.id = inptTropheyID.Text;
                trophey.place = inptTropheyPlace.Text;
                trophey.year = inptTropheyYear.Text;
                trophey.Leagues = new Leagues();
                trophey.Leagues.id = inptLeagueID.Text;
                trophey.Leagues.league_country = inptLeagueCountry.Text;
                trophey.Leagues.league_name = inptLeagueName.Text;
                trophey.Leagues.league_type = inptLeagueType.Text;
                tp.Tropheys.Add(trophey);

                Players player = new Players();
                player.id = inptMemberID.Text;
                player.first_name = inptMemberName.Text;
                player.last_name = inptMemberLastName.Text;
                player.gender = inptMemberGender.Text;
                player.g_strat_pos = inptMemberStratPos.Text;
                player.age = inptMemberAge.Text;
                player.birth_year = inptMemberYear.Text;
                string green = "Зелен";
                player.colour = green;
                player.country = inptMemberCountry.Text;
                player.day = inptMemberDay.Text;
                player.month = inptMemberMonth.Text;
                player.nickname = inptMemberNickname.Text;
                player.personal_win_rate = inptMemberwr8.Text;
                player.platoon_position = inptMemberPlatPos.Text;
                Tanks tank = new Tanks();
               // tank.Tanks = new Tanks();
                tank.id = inptTankId.Text;
                tank.tank_name = inptTankName.Text;
                tank.tank_nation = inptTankNation.Text;
               // tank.Guns = new Guns();
                Guns gun = new Guns();
                gun.id = "g" + tank.id;
                gun.gun_penetration = inptGunPen.Text;
                gun.ammo_type = inptAmmoType.Text;
                tank.image = inptImage.Text;
                tank.tier = inptTankTier.Text;
                tank.top_speed = inptTopSpeed.Text;
                tank.type = inptTankType.Text;
                tank.Guns = gun;
                player.Tanks = tank;
                tp.Players.Add(player);
                


               // tp.Players.Add(player);

                creator.CreateTankPlatoonXMLDocument(Server.MapPath("~/App_Data/" + tp.id + ".xml"),
                    "TPlatoon.dtd", tp);
                  // context.Tank_Platoons.Add(tp);
                  // context.SaveChanges();
               try
                {
                    context.Tank_Platoons.Add(tp);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }  


            }
        }

    }
}