//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wardrobe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Occassion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Occassion()
        {
            this.ClothingDetails = new HashSet<ClothingDetail>();
        }
    
        public int OccassionsID { get; set; }
        public string Occassions { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClothingDetail> ClothingDetails { get; set; }
    }
}
