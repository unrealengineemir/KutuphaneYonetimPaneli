//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Contact
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Buyer { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}
