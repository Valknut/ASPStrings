using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            if(Page.IsValid)
            {
                XMLCreatorLINQ creator = new XMLCreatorLINQ();
                

                            
            }
        }

    }
}