//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeriesAngularDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Temporadas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Temporadas()
        {
            this.Capitulos = new HashSet<Capitulos>();
        }
    
        public int idserie { get; set; }
        public int nseason { get; set; }
        public Nullable<int> chapters { get; set; }
        public Nullable<int> year { get; set; }
        public int idseanson { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Capitulos> Capitulos { get; set; }
        public virtual Series Series { get; set; }
    }
}
