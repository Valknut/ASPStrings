//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tank_Platoons
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tank_Platoons
    {
        public Tank_Platoons()
        {
            this.Players = new HashSet<Players>();
            this.Tropheys = new HashSet<Tropheys>();
        }
    
        public string id { get; set; }
        public string name { get; set; }
        public Nullable<double> win_rate { get; set; }
        public Nullable<int> rating { get; set; }
        public string nation { get; set; }
    
        public virtual ICollection<Players> Players { get; set; }
        public virtual ICollection<Tropheys> Tropheys { get; set; }
    }
}
