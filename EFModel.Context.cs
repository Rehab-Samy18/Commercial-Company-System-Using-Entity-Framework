﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EF_FinalProjectEntities : DbContext
    {
        public EF_FinalProjectEntities()
            : base("name=EF_FinalProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Exchange_Permission> Exchange_Permission { get; set; }
        public virtual DbSet<Exchange_Quantity> Exchange_Quantity { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product_Measure> Product_Measure { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply_Permission> Supply_Permission { get; set; }
        public virtual DbSet<Supply_Quantity> Supply_Quantity { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<SelectSupplyPermission_Result> SelectSupplyPermission()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectSupplyPermission_Result>("SelectSupplyPermission");
        }
    
        public virtual ObjectResult<SelectWarehouse_Result> SelectWarehouse()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectWarehouse_Result>("SelectWarehouse");
        }
    
        public virtual ObjectResult<SelectClient_Result> SelectClient()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectClient_Result>("SelectClient");
        }
    
        public virtual ObjectResult<SelectProduct_Result> SelectProduct()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectProduct_Result>("SelectProduct");
        }
    
        public virtual ObjectResult<SelectSupplier_Result> SelectSupplier()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectSupplier_Result>("SelectSupplier");
        }
    
        public virtual ObjectResult<SelectExchangePermission_Result> SelectExchangePermission()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectExchangePermission_Result>("SelectExchangePermission");
        }
    
        public virtual int TransactionProc(Nullable<int> pid, string pname, string fromwh, string towh, Nullable<int> sid, Nullable<int> pq, Nullable<System.DateTime> pdate, Nullable<int> expdur)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var pnameParameter = pname != null ?
                new ObjectParameter("pname", pname) :
                new ObjectParameter("pname", typeof(string));
    
            var fromwhParameter = fromwh != null ?
                new ObjectParameter("fromwh", fromwh) :
                new ObjectParameter("fromwh", typeof(string));
    
            var towhParameter = towh != null ?
                new ObjectParameter("towh", towh) :
                new ObjectParameter("towh", typeof(string));
    
            var sidParameter = sid.HasValue ?
                new ObjectParameter("sid", sid) :
                new ObjectParameter("sid", typeof(int));
    
            var pqParameter = pq.HasValue ?
                new ObjectParameter("pq", pq) :
                new ObjectParameter("pq", typeof(int));
    
            var pdateParameter = pdate.HasValue ?
                new ObjectParameter("pdate", pdate) :
                new ObjectParameter("pdate", typeof(System.DateTime));
    
            var expdurParameter = expdur.HasValue ?
                new ObjectParameter("expdur", expdur) :
                new ObjectParameter("expdur", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TransactionProc", pidParameter, pnameParameter, fromwhParameter, towhParameter, sidParameter, pqParameter, pdateParameter, expdurParameter);
        }
    
        public virtual int TransactionProc1(Nullable<int> pid, string fromwh, string towh, Nullable<int> sid, Nullable<int> pq, Nullable<System.DateTime> pdate, Nullable<int> expdur)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var fromwhParameter = fromwh != null ?
                new ObjectParameter("fromwh", fromwh) :
                new ObjectParameter("fromwh", typeof(string));
    
            var towhParameter = towh != null ?
                new ObjectParameter("towh", towh) :
                new ObjectParameter("towh", typeof(string));
    
            var sidParameter = sid.HasValue ?
                new ObjectParameter("sid", sid) :
                new ObjectParameter("sid", typeof(int));
    
            var pqParameter = pq.HasValue ?
                new ObjectParameter("pq", pq) :
                new ObjectParameter("pq", typeof(int));
    
            var pdateParameter = pdate.HasValue ?
                new ObjectParameter("pdate", pdate) :
                new ObjectParameter("pdate", typeof(System.DateTime));
    
            var expdurParameter = expdur.HasValue ?
                new ObjectParameter("expdur", expdur) :
                new ObjectParameter("expdur", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("TransactionProc1", pidParameter, fromwhParameter, towhParameter, sidParameter, pqParameter, pdateParameter, expdurParameter);
        }
    
        public virtual ObjectResult<DisplayTransaction_Result> DisplayTransaction()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DisplayTransaction_Result>("DisplayTransaction");
        }
    }
}
