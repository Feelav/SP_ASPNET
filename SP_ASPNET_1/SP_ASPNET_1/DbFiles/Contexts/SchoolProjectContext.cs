using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SP_ASPNET_1.Models;

namespace SP_ASPNET_1.DbFiles.Contexts
{
    public class SchoolProjectContext: DbContext
    {
        public SchoolProjectContext() : base("name=SchoolProjectDB")
        {
            
        }
            
        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
    }
}