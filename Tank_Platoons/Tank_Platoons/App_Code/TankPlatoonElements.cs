using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tank_Platoons.App_Code
{
    class TankPlatoonElements
    {
        public static string ROOT_ELEMENT = "tank_platoon";
        public static string ROOT_ELEMENT_XPATH = "/tank_platoon";
        public static string XML_VERSION = "1.0";
        public static string XML_ENCODING = "utf-8";
        public static string TPLATOON_NAME = "name";
        public static string TPLATOON_ID = "att_id_tp";
        public static string TPLATOON_WIN_RATE = "win_rate";
        public static string TPLATOON_NATION = "nation";
        public static string TPLATOON_RATING = "rating";
        public static string TPLATOON_TROPHEYS = "tropheys";
        public static string TPLATOON_TROPHEYS_XPATH = ROOT_ELEMENT_XPATH + "/tropheys";
        public static string TPLATOON_TROPHEY = "trophey";
        public static string TPLATOON_TROPHEY_ID = "att_id_trophey";
        public static string TPLATOON_YEAR = "year";
        public static string TPLATOON_PLACE = "place";
        public static string TPLATOON_LEAGUE = "league";
        public static string TPLATOON_LEAGUE_XPATH = TPLATOON_TROPHEYS_XPATH + "/league";
        public static string TPLATOON_LEAGUE_ID = "att_id_league";
        public static string TPLATOON_LEAGUE_NAME = "league_name";
        public static string TPLATOON_LEAGUE_TYPE = "l_type";
        public static string TPLATOON_LEAGUE_COUNTRY = "league_country";
        public static string TPLATOON_CREW = "crew";
        public static string TPLATOON_CREW_XPATH = ROOT_ELEMENT_XPATH + "/crew";
        public static string TPLATOON_MEMBER = "member";
        public static string TPLATOON_MEMBER_XPATH = TPLATOON_CREW_XPATH + "/member";
        public static string TPLATOON_MEMBER_ID = "att_id_member";
        public static string TPLATOON_MEMBER_PLATOON_POS = "att_platoon_pos";
        public static string TPLATOON_MEMBER_STRAT_POS = "strategic_position";
        public static string TPLATOON_MEMBER_GENDER = "gender";
        public static string TPLATOON_FIRST_NAME = "first_name";
        public static string TPLATOON_LAST_NAME = "last_name";
        public static string TPLATOON_AGE = "age";
        public static string TPLATOON_DATE_OF_BIRTH = "date_of_birth";
        public static string TPLATOON_DATE_OF_BIRTH_XPATH = TPLATOON_MEMBER_XPATH + "/date_of_birth";
        public static string TPLATOON_DAY = "day";
        public static string TPLATOON_MONTH = "month";
        public static string TPLATOON_BIRTH_YEAR = "birth_year";
        public static string TPLATOON_COUNTRY = "country";
        public static string TPLATOON_PERS_WIN_RATE = "personal_win_rate";
        public static string TPLATOON_PERS_WIN_RATE_COLOUR = "colour";
        public static string TPLATOON_NICKNAME = "nickname";
        public static string TPLATOON_TANK = "tank";
        public static string TPLATOON_TANK_XPATH = TPLATOON_MEMBER_XPATH + "/tank";
        public static string TPLATOON_TANK_ID = "att_id_tank";
        public static string TPLATOON_TANK_TYPE = "type";
        public static string TPLATOON_AMMO_TYPE = "ammo_type";
        public static string TPLATOON_GUN_PENETRATION = "gun_penetration";
        public static string TPLATOON_TOP_SPEED = "top_speed";
        public static string TPLATOON_IMAGE = "image";
        public static string TPLATOON_TIER = "tier";
        public static string TPLATOON_TANK_NAME = "tank_name";
        public static string TPLATOON_TANK_NATION = "tank_nation";

            
    }
}