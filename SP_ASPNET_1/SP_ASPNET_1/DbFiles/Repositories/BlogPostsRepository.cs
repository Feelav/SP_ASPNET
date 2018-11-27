using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.Data.Entity;
using SP_ASPNET_1.DbFiles.Contexts;
using SP_ASPNET_1.Models;

namespace SP_ASPNET_1.DbFiles.Repositories
{
    public class BlogPostsRepository : SchoolRepository<BlogPost>
    {
        public BlogPostsRepository(SchoolProjectContext context) : base(context)
        {
        }

        public IEnumerable<BlogPost> GetAll()
        {
            //return this._context.BlogPosts.Include(x => x.Author).ToList();
            return this.Get(null, null, "Author");
        }
    }
}