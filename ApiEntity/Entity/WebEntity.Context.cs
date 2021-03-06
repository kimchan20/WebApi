﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiEntity.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class serverEntity : DbContext
    {
        public serverEntity()
            : base("name=serverEntity")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<category_items> category_items { get; set; }
        public virtual DbSet<product_items> product_items { get; set; }
        public virtual DbSet<user_info> user_info { get; set; }
    
        public virtual ObjectResult<getUsertoEdit_Result1> getUsertoEdit(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUsertoEdit_Result1>("getUsertoEdit", idParameter);
        }
    
        public virtual ObjectResult<SelectUser_Result1> SelectUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectUser_Result1>("SelectUser");
        }
    
        public virtual int insertProductItems(string prod_id, string cat_id, string prod_name, string prod_desc)
        {
            var prod_idParameter = prod_id != null ?
                new ObjectParameter("prod_id", prod_id) :
                new ObjectParameter("prod_id", typeof(string));
    
            var cat_idParameter = cat_id != null ?
                new ObjectParameter("cat_id", cat_id) :
                new ObjectParameter("cat_id", typeof(string));
    
            var prod_nameParameter = prod_name != null ?
                new ObjectParameter("prod_name", prod_name) :
                new ObjectParameter("prod_name", typeof(string));
    
            var prod_descParameter = prod_desc != null ?
                new ObjectParameter("prod_desc", prod_desc) :
                new ObjectParameter("prod_desc", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertProductItems", prod_idParameter, cat_idParameter, prod_nameParameter, prod_descParameter);
        }
    
        public virtual int insertUserInfo(string userid, string username, string password, string role)
        {
            var useridParameter = userid != null ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var roleParameter = role != null ?
                new ObjectParameter("role", role) :
                new ObjectParameter("role", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertUserInfo", useridParameter, usernameParameter, passwordParameter, roleParameter);
        }
    }
}
