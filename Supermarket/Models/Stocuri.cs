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
    
    public partial class Stocuri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stocuri()
        {
            this.Oferte = new HashSet<Oferte>();
        }
    
        public int id_stoc { get; set; }
        public int cantitate { get; set; }
        public string unitate_masura { get; set; }
        public System.DateTime data_aprovizionare { get; set; }
        public Nullable<System.DateTime> data_expirare { get; set; }
        public double pret_achizitie { get; set; }
        public double pret_vanzare { get; set; }
        public int id_produs { get; set; }
        public bool is_active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oferte> Oferte { get; set; }
        public virtual Produse Produse { get; set; }
    }
}
