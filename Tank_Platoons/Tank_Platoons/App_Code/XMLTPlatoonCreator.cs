using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Schema;

namespace Tank_Platoons.App_Code
{
    public class XMLTPlatoonCreator
    {
        private XmlDocument xml = new XmlDocument();
        private string path;
        private string dtdFile;

        private void _AddAttribute(XmlNode XMLNode, string attrName, string attrValue)
        {
            XmlAttribute attr = xml.CreateAttribute(attrName);
            attr.Value = attrValue;
            XMLNode.Attributes.Append(attr);
        }

        private void _AddAttribute(string xPath, string attrName, string attrValue)
        {
            XmlAttribute attr = xml.CreateAttribute(attrName);
            attr.Value = attrValue;
            xml.SelectSingleNode(xPath).Attributes.Append(attr);
        }

        private void _AddNode(XmlNode XMLNode, string childName, string innerText)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, childName, null);
            node.InnerText = innerText;
            XMLNode.AppendChild(node);
        }

        private void _AddNode(string xPath, string childName, string innerText)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, childName, null);
            node.InnerText = innerText;
            xml.SelectSingleNode(xPath).AppendChild(node);
        }

        private XmlNode _AddNodeAndReturnIt(XmlNode XMLNode, string childName, string innerText)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, childName, null);
            node.InnerText = innerText;
            XMLNode.AppendChild(node);
            return node;
        }

        private XmlNode _AddNodeAndReturnIt(string xPath, string childName, string innerText)
        {
            XmlNode node = xml.CreateNode(XmlNodeType.Element, childName, null);
            node.InnerText = innerText;
            xml.SelectSingleNode(xPath).AppendChild(node);
            return node;
        }

        private void _CreateRootElem(string id)
        {
            XmlNode node = xml.CreateElement(TankPlatoonElements.ROOT_ELEMENT);
            _AddAttribute(node, TankPlatoonElements.TPLATOON_ID, id);
            xml.AppendChild(node);
            xml.Save(this.path);
        }

        private void _AddDTD(string systemId)
        {
            if (!Regex.IsMatch(systemId, @"^\w+\.dtd$"))
            {
                throw new DTDException("Both the DTD and the XML files must be in the same" +
                    "directory and the parameter \"systemId\" must match the pattern <file_name>.dtd");
            }
            else
            {
                xml.Load(this.path);
                XmlElement root = xml.DocumentElement;
                XmlDeclaration xmlDecl = xml.CreateXmlDeclaration(TankPlatoonElements.XML_VERSION, TankPlatoonElements.XML_ENCODING, null);
                XmlDocumentType docType = xml.CreateDocumentType(TankPlatoonElements.ROOT_ELEMENT, null, systemId, null);
                xml.InsertBefore(xmlDecl, root);
                xml.InsertBefore(docType, root);
            }
        }

        private void _AddPlatoonProperties(string name, string nation, string rating, string win_rate)
        {
            _AddNode(TankPlatoonElements.ROOT_ELEMENT_XPATH, TankPlatoonElements.TPLATOON_NAME, name);
            _AddNode(TankPlatoonElements.ROOT_ELEMENT_XPATH, TankPlatoonElements.TPLATOON_NATION, nation);
            _AddNode(TankPlatoonElements.ROOT_ELEMENT_XPATH, TankPlatoonElements.TPLATOON_RATING, rating);
            _AddNode(TankPlatoonElements.ROOT_ELEMENT_XPATH, TankPlatoonElements.TPLATOON_WIN_RATE, win_rate);
        }

        private void _AddTropheys(List<Tropheys> tropheys)
        {
            _AddNode(TankPlatoonElements.ROOT_ELEMENT_XPATH, TankPlatoonElements.TPLATOON_TROPHEYS, null);
            foreach(Tropheys trophey in tropheys)
            {
                XmlNode node = _AddNodeAndReturnIt(TankPlatoonElements.TPLATOON_TROPHEYS_XPATH,TankPlatoonElements.TPLATOON_TROPHEY,null);
                _AddAttribute(node, TankPlatoonElements.TPLATOON_TROPHEY_ID, trophey.id);
                _AddNode(node, TankPlatoonElements.TPLATOON_PLACE, trophey.place.ToString());
                _AddNode(node, TankPlatoonElements.TPLATOON_YEAR, trophey.year.ToString());
                node = _AddNodeAndReturnIt(TankPlatoonElements.TPLATOON_LEAGUE_XPATH, TankPlatoonElements.TPLATOON_LEAGUE, null);
                Leagues league = trophey.Leagues;
                _AddAttribute(node, TankPlatoonElements.TPLATOON_LEAGUE_TYPE, league.league_type);
                _AddNode(node, TankPlatoonElements.TPLATOON_LEAGUE_ID, league.id);
                _AddNode(node, TankPlatoonElements.TPLATOON_LEAGUE_NAME, league.league_name);
                _AddNode(node, TankPlatoonElements.TPLATOON_LEAGUE_COUNTRY, league.league_country);
                

            }
        }

        private void _AddPlayers(List<Players> players)
        {
            _AddNode(TankPlatoonElements.ROOT_ELEMENT_XPATH, TankPlatoonElements.TPLATOON_CREW, null);
            foreach(Players player in players)
            {
                XmlNode node = _AddNodeAndReturnIt(TankPlatoonElements.TPLATOON_CREW_XPATH, TankPlatoonElements.TPLATOON_MEMBER, null);
                _AddAttribute(node, TankPlatoonElements.TPLATOON_MEMBER_ID, player.id);
                _AddAttribute(node, TankPlatoonElements.TPLATOON_MEMBER_PLATOON_POS, player.platoon_position);
                _AddAttribute(node, TankPlatoonElements.TPLATOON_MEMBER_STRAT_POS, player.g_strat_pos);
                _AddAttribute(node, TankPlatoonElements.TPLATOON_MEMBER_GENDER, player.gender);
                _AddNode(node, TankPlatoonElements.TPLATOON_FIRST_NAME, player.first_name);
                _AddNode(node, TankPlatoonElements.TPLATOON_LAST_NAME, player.last_name);
                _AddNode(node, TankPlatoonElements.TPLATOON_AGE, player.age.ToString());
                _AddNode(node, TankPlatoonElements.TPLATOON_DATE_OF_BIRTH, null);
                _AddNode(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH_XPATH, TankPlatoonElements.TPLATOON_DAY, player.day.ToString());
                _AddNode(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH_XPATH, TankPlatoonElements.TPLATOON_MONTH, player.month.ToString());
                _AddNode(TankPlatoonElements.TPLATOON_DATE_OF_BIRTH_XPATH, TankPlatoonElements.TPLATOON_BIRTH_YEAR, player.birth_year.ToString());
                node = _AddNodeAndReturnIt(TankPlatoonElements.TPLATOON_TANK_XPATH, TankPlatoonElements.TPLATOON_TANK,null);
                Tanks tank = player.Tanks;
                _AddTank(tank,node);



            }
        }

        private void _AddTank(Tanks tank,XmlNode node)
        {
            _AddAttribute(node, TankPlatoonElements.TPLATOON_TANK_ID, tank.id);
            _AddAttribute(node, TankPlatoonElements.TPLATOON_TANK_TYPE, tank.type);
            _AddAttribute(node, TankPlatoonElements.TPLATOON_AMMO_TYPE, tank.Guns.ammo_type);
            _AddNode(node, TankPlatoonElements.TPLATOON_TANK_NAME, tank.tank_name);
            _AddNode(node, TankPlatoonElements.TPLATOON_TANK_NATION, tank.tank_nation);
            _AddNode(node, TankPlatoonElements.TPLATOON_TIER, tank.tier.ToString());
            _AddNode(node, TankPlatoonElements.TPLATOON_IMAGE, tank.image);
            _AddNode(node, TankPlatoonElements.TPLATOON_GUN_PENETRATION, tank.Guns.gun_penetration.ToString());
            _AddNode(node, TankPlatoonElements.TPLATOON_TOP_SPEED, tank.top_speed.ToString());
        }

        private void _Save()
        {
            this.xml.Save(this.path);
        }

        public bool CreateTPlatoonXMLDocument(string path, string systemId, Tank_Platoons tank_platoon)
        {
            this.path = path;
            this.dtdFile = systemId;
            if (tank_platoon == null)
                throw new XMLTPlatoonCreatorException("The parameter \"tank_platoon\" can not be null");
            try
            {
                _CreateRootElem(tank_platoon.id);
                _AddDTD(this.dtdFile);
                _AddPlatoonProperties(tank_platoon.name, tank_platoon.nation, tank_platoon.rating.ToString(), tank_platoon.win_rate.ToString());
                _AddTropheys(tank_platoon.Tropheys.ToList());
                _AddPlayers(tank_platoon.Players.ToList());
                _Save();
            }
            catch(Exception e)
            {
                throw new XMLTPlatoonCreatorException(e.Message);
            }
            return true;
        }

    }
}