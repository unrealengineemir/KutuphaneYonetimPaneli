﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LibraryDBEntities1 : DbContext
    {
        public LibraryDBEntities1()
            : base("name=LibraryDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_About> Tbl_About { get; set; }
        public virtual DbSet<Tbl_Announcement> Tbl_Announcement { get; set; }
        public virtual DbSet<Tbl_Book> Tbl_Book { get; set; }
        public virtual DbSet<Tbl_Category> Tbl_Category { get; set; }
        public virtual DbSet<Tbl_Contact> Tbl_Contact { get; set; }
        public virtual DbSet<Tbl_Member> Tbl_Member { get; set; }
        public virtual DbSet<Tbl_Message> Tbl_Message { get; set; }
        public virtual DbSet<Tbl_Personel> Tbl_Personel { get; set; }
        public virtual DbSet<Tbl_Process> Tbl_Process { get; set; }
        public virtual DbSet<Tbl_Punishment> Tbl_Punishment { get; set; }
        public virtual DbSet<Tbl_Writer> Tbl_Writer { get; set; }
    
        public virtual ObjectResult<string> BOOKWRİTER()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("BOOKWRİTER");
        }
    
        public virtual ObjectResult<string> MAXBOOK()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MAXBOOK");
        }
    
        public virtual ObjectResult<string> MAXMEMBER()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MAXMEMBER");
        }
    
        public virtual ObjectResult<string> MAXPERSONEL()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("MAXPERSONEL");
        }
    
        public virtual ObjectResult<string> PROFILEBOOK()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("PROFILEBOOK");
        }
    
        public virtual ObjectResult<string> PublishinHouse()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("PublishinHouse");
        }
    
        public virtual ObjectResult<Nullable<int>> TODAY()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("TODAY");
        }
    
        public virtual ObjectResult<Nullable<int>> TODAYBOOKS()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("TODAYBOOKS");
        }
    
        public virtual ObjectResult<Nullable<int>> TODAYBOOKS1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("TODAYBOOKS1");
        }
    }
}
