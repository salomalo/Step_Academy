﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_Shop_bud_materEntities : DbContext
    {
        public DB_Shop_bud_materEntities()
            : base("name=DB_Shop_bud_materEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomersType> CustomersType { get; set; }
        public DbSet<InputOrderItem> InputOrderItem { get; set; }
        public DbSet<InputOrders> InputOrders { get; set; }
        public DbSet<Measures> Measures { get; set; }
        public DbSet<OutputOrderItem> OutputOrderItem { get; set; }
        public DbSet<OutputOrders> OutputOrders { get; set; }
        public DbSet<Packeges> Packeges { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<WarehouseItem> WarehouseItem { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }
    }
}