using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Schema;
using Tank_Platoons.App_Code;

namespace Tank_Platoons.App_Code
{
    public class XMLTPlatoonProcessor
    {
        private Tank_Platoons tank_platoon;
        private XmlDocument xml = new XmlDocument();
        private XmlNode node;
        private string path;

        private string _GetNodeValue(XmlNode fromNode, string xPath)
        {
            return fromNode.SelectSingleNode(xPath).InnerText;
        }

        private string _GetAttributeValue(XmlNode fromNode, string xPath, string attribute)
        {
            return fromNode.SelectSingleNode(xPath).Attributes[attribute].Value;
        }

        private void _LoadXML(string path)
        {
            this.xml.Load(path);
        }

        private void _InitTankPlatoon()
        {
            node = xml.SelectSingleNode(TankPlatoonElements.ROOT_ELEMENT_XPATH);
            string id = node.Attributes[TankPlatoonElements.TPLATOON_ID].Value;
            this.tank_platoon = new Tank_Platoons();
            tank_platoon.id = id;
        }

        private void _GetPlatoonProperties()
        {
            tank_platoon.id = _GetAttributeValue(node, TankPlatoonElements.ROOT_ELEMENT_XPATH,TankPlatoonElements.TPLATOON_ID);
            tank_platoon.name = _GetNodeValue(node, TankPlatoonElements.ROOT_ELEMENT_XPATH + "/" + TankPlatoonElements.TPLATOON_NAME);
            tank_platoon.nation = _GetNodeValue(node, TankPlatoonElements.ROOT_ELEMENT_XPATH + "/" + TankPlatoonElements.TPLATOON_NATION);
            tank_platoon.rating = _GetNodeValue(node, TankPlatoonElements.ROOT_ELEMENT_XPATH + "/" + TankPlatoonElements.TPLATOON_RATING);
            tank_platoon.win_rate = _GetNodeValue(node, TankPlatoonElements.ROOT_ELEMENT_XPATH + "/" + TankPlatoonElements.TPLATOON_WIN_RATE);
        }

        private Tropheys _GetTrophey(XmlNode n)
        {
            Tropheys trophey = new Tropheys();
            trophey.id = n.Attributes[TankPlatoonElements.TPLATOON_TROPHEY_ID].Value;
            XmlNodeList nodes = n.ChildNodes;
            foreach(XmlNode node in nodes)
            {
                switch(node.Name.ToString())
                {
                    case "year":
                        trophey.year = node.InnerText;
                        break;
                    case "place":
                        trophey.place = node.InnerText;
                        break;
                    case "league":
                        XmlNode leaguenode = xml.SelectSingleNode(TankPlatoonElements.TPLATOON_LEAGUE_XPATH);
                        trophey.Leagues = new Leagues();
                        trophey.Leagues.id = _GetAttributeValue(leaguenode, TankPlatoonElements.TPLATOON_LEAGUE_XPATH, TankPlatoonElements.TPLATOON_LEAGUE_ID);
                        trophey.Leagues.league_type = _GetAttributeValue(leaguenode, TankPlatoonElements.TPLATOON_LEAGUE_XPATH, TankPlatoonElements.TPLATOON_LEAGUE_TYPE);
                        trophey.Leagues.league_country = _GetNodeValue(leaguenode, TankPlatoonElements.TPLATOON_LEAGUE_XPATH + "/" + TankPlatoonElements.TPLATOON_LEAGUE_COUNTRY);
                        trophey.Leagues.league_name = _GetNodeValue(leaguenode, TankPlatoonElements.TPLATOON_LEAGUE_XPATH + "/" + TankPlatoonElements.TPLATOON_LEAGUE_NAME);
                        break;

                }
            }
            return trophey;
        }

        private void _GetTropheys()
        {
            XmlNodeList tropheyNodes = xml.GetElementsByTagName(TankPlatoonElements.TPLATOON_TROPHEY);
            foreach(XmlNode node in tropheyNodes)
            {
                tank_platoon.Tropheys.Add(this._GetTrophey(node));
            }
        }

        private Players _GetPlayer(XmlNode n)
        {
            Players player = new Players();
            player.id = n.Attributes[TankPlatoonElements.TPLATOON_MEMBER_ID].Value;
            player.gender = n.Attributes[TankPlatoonElements.TPLATOON_MEMBER_GENDER].Value;
            player.g_strat_pos = n.Attributes[TankPlatoonElements.TPLATOON_MEMBER_STRAT_POS].Value;
            player.platoon_position = n.Attributes[TankPlatoonElements.TPLATOON_MEMBER_PLATOON_POS].Value;
            XmlNodeList nodes = n.ChildNodes;
            foreach(XmlNode node in nodes)
            {
                switch(n.Name.ToString())
                {
                    case "first_name":
                        player.first_name = node.InnerText;
                        break;
                    case "last_name":
                        player.last_name = node.InnerText;
                        break;
                    case "nickname":
                        player.nickname = node.InnerText;
                        break;
                    case "age":
                        player.age = node.InnerText;
                        break;
                    case "date_of_birth":
                        XmlNode date_node = xml.SelectSingleNode(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH_XPATH);
                        player.day = _GetNodeValue(date_node, TankPlatoonElements.TPLATOON_DATE_OF_BIRTH_XPATH + "/" + TankPlatoonElements.TPLATOON_DAY);
                        player.month = _GetNodeValue(date_node,TankPlatoonElements.TPLATOON_DATE_OF_BIRTH_XPATH+"/"+TankPlatoonElements.TPLATOON_MONTH);
                        player.birth_year = _GetNodeValue(date_node,TankPlatoonElements.TPLATOON_DATE_OF_BIRTH_XPATH+"/"+TankPlatoonElements.TPLATOON_BIRTH_YEAR);
                        break;
                    case "country":
                        player.country = node.InnerText;
                        break;
                    case "tank":
                        XmlNode tank_node = xml.SelectSingleNode(TankPlatoonElements.TPLATOON_TANK_XPATH);
                        player.Tanks = new Tanks();
                        player.Tanks.id = _GetAttributeValue(tank_node,TankPlatoonElements.TPLATOON_TANK_XPATH, TankPlatoonElements.TPLATOON_TANK_ID);
                        player.Tanks.type = _GetAttributeValue(tank_node, TankPlatoonElements.TPLATOON_TANK_XPATH, TankPlatoonElements.TPLATOON_TANK_TYPE);
                        player.Tanks.Guns = new Guns();
                        player.Tanks.Guns.id = "g" + player.Tanks.id;
                        player.Tanks.Guns.ammo_type = _GetAttributeValue(tank_node, TankPlatoonElements.TPLATOON_TANK_XPATH, TankPlatoonElements.TPLATOON_AMMO_TYPE);
                        player.Tanks.Guns.gun_penetration = _GetNodeValue(tank_node, TankPlatoonElements.TPLATOON_TANK_XPATH + "/" + TankPlatoonElements.TPLATOON_GUN_PENETRATION);
                        player.Tanks.tank_name = _GetNodeValue(tank_node, TankPlatoonElements.TPLATOON_TANK_XPATH + "/" + TankPlatoonElements.TPLATOON_TANK_NAME);
                        player.Tanks.tank_nation = _GetNodeValue(tank_node, TankPlatoonElements.TPLATOON_TANK_XPATH + "/" + TankPlatoonElements.TPLATOON_TANK_NATION);
                        player.Tanks.tier = _GetNodeValue(tank_node, TankPlatoonElements.TPLATOON_TANK_XPATH + "/" + TankPlatoonElements.TPLATOON_TIER);
                        player.Tanks.image = _GetNodeValue(tank_node, TankPlatoonElements.TPLATOON_TANK_XPATH + "/" + TankPlatoonElements.TPLATOON_IMAGE);
                        player.Tanks.top_speed = _GetNodeValue(tank_node, TankPlatoonElements.TPLATOON_TANK_XPATH + "/" + TankPlatoonElements.TPLATOON_TOP_SPEED);
                        break;
                    case "personal_win_rate":
                        player.personal_win_rate = node.InnerText;
                        break;
                }
            }
            return player;
        }

        private void _GetPlayers()
        {
            XmlNodeList playerNodes = xml.GetElementsByTagName(TankPlatoonElements.TPLATOON_MEMBER);
            foreach(XmlNode node in playerNodes)
            {
                tank_platoon.Players.Add(this._GetPlayer(node));
            }
        }

        public bool LoadTankPlatoonFromXML(string path)
        {
            try
            {
                XMLValidator val = new XMLValidator();
                val.Validate(path);
                
                this.path = path;

                _LoadXML(path);
                _InitTankPlatoon();
                _GetPlatoonProperties();
                _GetTropheys();
                _GetPlayers();
            }
            catch (Exception e)
            {
                throw new XMLTPlatoonProcessorException(e.Message);
            }

            return true;
        }

        public Tank_Platoons Tank_Platoon
        {
            get
            {
                if (tank_platoon != null)
                    return this.tank_platoon;
                else throw new XMLTPlatoonProcessorException("You must first call the \"LoadTankPlatoonFromXML(string path)\"" +
                " or \"LoadTankPlatoonFromXMLUsingReader(string path)\" method for your XMLTankPlatoonProcessor object!");
            }
        }

        public bool LoadTankPlatoonFromXMLUsingReader(string path)
        {
            this.path = path;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.DTD;
            settings.DtdProcessing = DtdProcessing.Parse;

            Tank_Platoons tp = null;
            Tropheys trophey = null;
            Players player = null;

            try
            {
                XmlReader reader = XmlReader.Create(path, settings);
                while(reader.Read())
                {
                    if(reader.IsStartElement())
                        switch(reader.Name)
                        {
                            case "tank_platoon":
                                string id = reader.GetAttribute(TankPlatoonElements.TPLATOON_ID);
                                tp = new Tank_Platoons();
                                tp.id = id;
                                break;
                            case "name":
                                tp.name = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "nation":
                                tp.nation = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "rating":
                                string rt = (string)reader.ReadElementContentAs(typeof(string), null);
                                tp.rating = rt;
                                break;
                            case "trophey":
                                trophey = new Tropheys();
                                trophey.id = reader.GetAttribute(TankPlatoonElements.TPLATOON_TROPHEY_ID);
                                break;
                            case "year":
                                trophey.year = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "place":
                                trophey.place = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "league":
                                trophey.Leagues = new Leagues();
                                trophey.Leagues.id = reader.GetAttribute(TankPlatoonElements.TPLATOON_LEAGUE_ID);
                                break;
                            case "league_name":
                                trophey.Leagues.league_type = reader.GetAttribute(TankPlatoonElements.TPLATOON_LEAGUE_TYPE);
                                trophey.Leagues.league_name = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "league_country":
                                trophey.Leagues.league_country = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "member":
                                player = new Players();
                                player.id = reader.GetAttribute(TankPlatoonElements.TPLATOON_MEMBER_ID);
                                player.g_strat_pos = reader.GetAttribute(TankPlatoonElements.TPLATOON_MEMBER_STRAT_POS);
                                player.gender = reader.GetAttribute(TankPlatoonElements.TPLATOON_MEMBER_GENDER);
                                player.platoon_position = reader.GetAttribute(TankPlatoonElements.TPLATOON_MEMBER_PLATOON_POS);
                                break;
                            case "first_name":
                                player.first_name = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "last_name":
                                player.last_name = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "nickname":
                                player.nickname = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "age":
                                player.age = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "day":
                                player.day = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "month":
                                player.month = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "birth_year":
                                player.birth_year = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "country":
                                player.country = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "tank":
                                player.Tanks = new Tanks();
                                player.Tanks.id = reader.GetAttribute(TankPlatoonElements.TPLATOON_TANK_ID);
                                player.Tanks.type = reader.GetAttribute(TankPlatoonElements.TPLATOON_TANK_TYPE);
                                player.Tanks.Guns = new Guns();
                                player.Tanks.Guns.ammo_type = reader.GetAttribute(TankPlatoonElements.TPLATOON_AMMO_TYPE);
                                break;
                            case "tier":
                                player.Tanks.tier = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "tank_name":
                                player.Tanks.tank_name = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "tank_nation":
                                player.Tanks.tank_nation = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "image":
                                player.Tanks.image = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "gun_penetration":
                                player.Tanks.Guns.gun_penetration = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "top_speed":
                                player.Tanks.top_speed = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;
                            case "personal_win_rate":
                                player.personal_win_rate = (string)reader.ReadElementContentAs(typeof(string), null);
                                break;

                        }
                }
                reader.Close();
            }
            catch(Exception e)
            {
                throw new XMLTPlatoonProcessorException(e.Message);
            }
            this.tank_platoon = tp;
            return true;

        }

    }
}