using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tank_Platoons.App_Code
{
    public class XMLCreatorLINQ
    {
        private XDocument doc;

        public void CreateTankPlatoonXMLDocument(String path, string dtd, Tank_Platoons store)
        {
            XDocumentType type = new XDocumentType("tank_platoon", null, dtd, null);
            doc = new XDocument(type);

            XElement root = new XElement(TankPlatoonElements.ROOT_ELEMENT);
            root.SetAttributeValue(TankPlatoonElements.TPLATOON_ID, store.id);
            root.Add(new XElement(TankPlatoonElements.TPLATOON_NAME,store.name));
            root.Add(new XElement(TankPlatoonElements.TPLATOON_NATION,store.nation));
            root.Add(new XElement(TankPlatoonElements.TPLATOON_RATING,store.rating));
            root.Add(new XElement(TankPlatoonElements.TPLATOON_PERS_WIN_RATE),store.win_rate);
            XElement elem = new XElement(TankPlatoonElements.TPLATOON_TROPHEYS);
            XElement trophey = null;
            foreach(var item in store.Tropheys)
            {
                trophey = new XElement(TankPlatoonElements.TPLATOON_TROPHEY);
                trophey.SetAttributeValue(TankPlatoonElements.TPLATOON_TROPHEY_ID, item.id);
                trophey.Add(new XElement(TankPlatoonElements.TPLATOON_YEAR, item.year));
                trophey.Add(new XElement(TankPlatoonElements.TPLATOON_PLACE, item.place));
                trophey.Add(new XElement(TankPlatoonElements.TPLATOON_LEAGUE));
                trophey.SetAttributeValue(TankPlatoonElements.TPLATOON_LEAGUE_ID, item.Leagues.id);
                trophey.Element(TankPlatoonElements.TPLATOON_LEAGUE)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_LEAGUE_NAME, item.Leagues.league_name));
                trophey.Element(TankPlatoonElements.TPLATOON_LEAGUE_NAME)
                    .SetAttributeValue(TankPlatoonElements.TPLATOON_LEAGUE_TYPE, item.Leagues.league_type);
                trophey.Element(TankPlatoonElements.TPLATOON_LEAGUE)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_LEAGUE_COUNTRY, item.Leagues.league_country));
                elem.Add(trophey);
            }
            root.Add(elem);
            elem = new XElement(TankPlatoonElements.TPLATOON_CREW);
            XElement player = null;
            foreach(var item in store.Players)
            {
                player = new XElement(TankPlatoonElements.TPLATOON_MEMBER);
                player.SetAttributeValue(TankPlatoonElements.TPLATOON_MEMBER_ID, item.id);
                player.SetAttributeValue(TankPlatoonElements.TPLATOON_MEMBER_GENDER, item.gender);
                player.SetAttributeValue(TankPlatoonElements.TPLATOON_MEMBER_PLATOON_POS, item.platoon_position);
                player.SetAttributeValue(TankPlatoonElements.TPLATOON_MEMBER_STRAT_POS, item.g_strat_pos);
                player.Add(new XElement(TankPlatoonElements.TPLATOON_FIRST_NAME, item.first_name));
                player.Add(new XElement(TankPlatoonElements.TPLATOON_LAST_NAME, item.last_name));
                player.Add(new XElement(TankPlatoonElements.TPLATOON_AGE, item.age));
                player.Add(new XElement(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH));
                 player.Element(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_BIRTH_YEAR, item.birth_year));                   
                player.Element(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_DAY, item.day));
                player.Element(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_MONTH, item.month));
                player.Add(new XElement(TankPlatoonElements.TPLATOON_COUNTRY, item.country));
                player.Add(new XElement(TankPlatoonElements.TPLATOON_PERS_WIN_RATE, item.personal_win_rate));
                player.Element(TankPlatoonElements.TPLATOON_PERS_WIN_RATE)
                    .SetAttributeValue(TankPlatoonElements.TPLATOON_PERS_WIN_RATE_COLOUR, item.colour);
                player.Add(new XElement(TankPlatoonElements.TPLATOON_NICKNAME, item.nickname));
                player.Add(new XElement(TankPlatoonElements.TPLATOON_TANK));
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .SetAttributeValue(TankPlatoonElements.TPLATOON_TANK_ID, item.Tanks.id);
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .SetAttributeValue(TankPlatoonElements.TPLATOON_TANK_TYPE, item.Tanks.type);
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .SetAttributeValue(TankPlatoonElements.TPLATOON_AMMO_TYPE, item.Tanks.Guns.ammo_type);
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_TIER, item.Tanks.tier));
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_TANK_NAME, item.Tanks.tank_name));
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_TANK_NATION, item.Tanks.tank_nation));
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_IMAGE, item.Tanks.image));
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_GUN_PENETRATION, item.Tanks.Guns.gun_penetration));
                player.Element(TankPlatoonElements.TPLATOON_TANK)
                    .Add(new XElement(TankPlatoonElements.TPLATOON_TOP_SPEED, item.Tanks.top_speed));
                elem.Add(player);

            }

            root.Add(elem);
            doc.Add(root);
            doc.Save(path);


        }
    }
}