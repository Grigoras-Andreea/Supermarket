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
    
    public partial class Produs_Bon
    {
        public int id_produs { get; set; }
        public int id_bon { get; set; }
        public int cantitate { get; set; }
        public double total { get; set; }
    
        public virtual Bonuri Bonuri { get; set; }
        public virtual Produse Produse { get; set; }
    }
}