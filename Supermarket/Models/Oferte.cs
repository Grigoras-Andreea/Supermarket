//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Supermarket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Oferte
    {
        public int id_oferta { get; set; }
        public int id_stoc { get; set; }
        public string motiv { get; set; }
        public int procent_reducere { get; set; }
        public System.DateTime data_incepere { get; set; }
        public System.DateTime data_sfarsire { get; set; }
        public bool is_active { get; set; }
    
        public virtual Stocuri Stocuri { get; set; }
    }
}
