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
    
    public partial class Comentario
    {
        public int idcomment { get; set; }
        public int iduser { get; set; }
        public int idserie { get; set; }
        public string comment { get; set; }
        public Nullable<System.DateTime> commentdate { get; set; }
    
        public virtual Serie Serie { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}