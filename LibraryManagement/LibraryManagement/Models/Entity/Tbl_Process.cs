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
    
    public partial class Tbl_Process
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Process()
        {
            this.Tbl_Punishment = new HashSet<Tbl_Punishment>();
        }
    
        public int ProcessID { get; set; }
        public Nullable<int> Book { get; set; }
        public Nullable<int> Member { get; set; }
        public Nullable<byte> Personel { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<System.DateTime> BroughDate { get; set; }
        public Nullable<bool> TransactionStatus { get; set; }
    
        public virtual Tbl_Book Tbl_Book { get; set; }
        public virtual Tbl_Member Tbl_Member { get; set; }
        public virtual Tbl_Personel Tbl_Personel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Punishment> Tbl_Punishment { get; set; }
    }
}
