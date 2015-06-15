using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tank_Platoons.App_Code
{
    public class XMLProcessorLINQ
    {
        private Tank_Platoons tank_platoon;
        private XElement xTank_platoon;

        public void LoadFile(String file)
        {
            xTank_platoon = XElement.Load(file);
        }

        private void InitTPlatoon()
        {
            IEnumerable<XAttribute> attributes = from node in xTank_platoon.Attributes()
                                                 select node;
            string id = null;
            foreach (var item in attributes)
            {
                if (item.Name == TankPlatoonElements.TPLATOON_ID) id = item.Value;
            }
            this.tank_platoon = new Tank_Platoons();
            this.tank_platoon.id = id;
        }

        private void SetTPlatoonProperties()
        {
            IEnumerable<XElement> propertiesElements = from node in xTank_platoon.Elements(TankPlatoonElements.ROOT_ELEMENT)
                                                       select node;
            foreach (var item in propertiesElements)
            {
                switch(item.Name.ToString())
                {
                    case "name":
                        tank_platoon.name = item.Value;
                        break;
                    case "nation":
                        tank_platoon.nation = item.Value;
                        break;
                    case "rating":
                        tank_platoon.rating = item.Value;
                        break;
                    case "win_rate":
                        tank_platoon.win_rate = item.Value;
                        break;
                }
            }
        }

        private void SetTropheys()
        {
            IEnumerable<XElement> tropheys = from node in xTank_platoon.Element(TankPlatoonElements.TPLATOON_TROPHEYS)
                                             .Elements(TankPlatoonElements.TPLATOON_TROPHEY)
                                             select node;
            Tropheys trophey = null;
            foreach(var item in tropheys)
            {
                trophey = new Tropheys();
                trophey.id = item.Attribute(TankPlatoonElements.TPLATOON_TROPHEY_ID).Value;
                trophey.year = item.Element(TankPlatoonElements.TPLATOON_YEAR).Value;
                trophey.place = item.Element(TankPlatoonElements.TPLATOON_PLACE).Value;
                trophey.Leagues = new Leagues();
                trophey.Leagues.id = item.Element(TankPlatoonElements.TPLATOON_LEAGUE)
                    .Attribute(TankPlatoonElements.TPLATOON_LEAGUE_ID).Value;
                trophey.Leagues.league_type = item.Element(TankPlatoonElements.TPLATOON_LEAGUE)
                    .Element(TankPlatoonElements.TPLATOON_LEAGUE_NAME).Attribute(TankPlatoonElements.TPLATOON_LEAGUE_TYPE).Value;
                trophey.Leagues.league_name = item.Element(TankPlatoonElements.TPLATOON_LEAGUE)
                    .Element(TankPlatoonElements.TPLATOON_LEAGUE_NAME).Value;
                trophey.Leagues.league_country = item.Element(TankPlatoonElements.TPLATOON_LEAGUE)
                    .Element(TankPlatoonElements.TPLATOON_LEAGUE_COUNTRY).Value;

                tank_platoon.Tropheys.Add(trophey);
            }
        }

        private void SetPlayers()
        {
            IEnumerable<XElement> players = from node in xTank_platoon.Element(TankPlatoonElements.TPLATOON_CREW)
                                                .Elements(TankPlatoonElements.TPLATOON_MEMBER)
                                            select node;
            Players player = null;
            foreach(var item in players)
            {
                player = new Players();
                player.id = item.Attribute(TankPlatoonElements.TPLATOON_MEMBER_ID).Value;
                player.gender = item.Attribute(TankPlatoonElements.TPLATOON_MEMBER_GENDER).Value;
                player.g_strat_pos = item.Attribute(TankPlatoonElements.TPLATOON_MEMBER_STRAT_POS).Value;
                player.platoon_position = item.Attribute(TankPlatoonElements.TPLATOON_MEMBER_PLATOON_POS).Value;
                player.first_name = item.Element(TankPlatoonElements.TPLATOON_FIRST_NAME).Value;
                player.last_name = item.Element(TankPlatoonElements.TPLATOON_LAST_NAME).Value;
                player.nickname = item.Element(TankPlatoonElements.TPLATOON_NICKNAME).Value;
                player.age = item.Element(TankPlatoonElements.TPLATOON_AGE).Value;
                player.country = item.Element(TankPlatoonElements.TPLATOON_COUNTRY).Value;
                player.day = item.Element(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH
                    .Element(TankPlatoonElements.TPLATOON_DAY).Value);
                player.month = item.Element(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH)
                    .Element(TankPlatoonElements.TPLATOON_MONTH).Value;
                player.birth_year = item.Element(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH)
                    .Element(TankPlatoonElements.TPLATOON_BIRTH_YEAR).Value;
                player.personal_win_rate = item.Element(TankPlatoonElements.TPLATOON_PERS_WIN_RATE).Value;
                player.Tanks = new Tanks();
                player.Tanks.id = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Attribute(TankPlatoonElements.TPLATOON_TANK_ID).Value;
                player.Tanks.type = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Attribute(TankPlatoonElements.TPLATOON_TANK_TYPE).Value;
                player.Tanks.Guns = new Guns();
                player.Tanks.Guns.ammo_type = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Attribute(TankPlatoonElements.TPLATOON_AMMO_TYPE).Value;
                player.Tanks.Guns.gun_penetration = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Element(TankPlatoonElements.TPLATOON_GUN_PENETRATION).Value;
                player.Tanks.top_speed = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Element(TankPlatoonElements.TPLATOON_TOP_SPEED).Value;
                player.Tanks.tank_name = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Element(TankPlatoonElements.TPLATOON_TANK_NAME).Value;
                player.Tanks.tank_nation = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Element(TankPlatoonElements.TPLATOON_TANK_NATION).Value;
                player.Tanks.tier = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Element(TankPlatoonElements.TPLATOON_TIER).Value;
                player.Tanks.image = item.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Element(TankPlatoonElements.TPLATOON_IMAGE).Value;

                tank_platoon.Players.Add(player);
            }

        }

        public Tank_Platoons GetTankPlatoon()
        {
            InitTPlatoon();
            SetTPlatoonProperties();
            SetTropheys();
            SetPlayers();
            if (tank_platoon != null)
                return this.tank_platoon;
            else
                throw new XMLTPlatoonProcessorException("the tank platoon is null");
        }
    


    }
}