using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SP_ASPNET_1.Models;

namespace SP_ASPNET_1.ViewModels
{
    public class BlogSinglePostViewModel : IBlogViewModel
    {
        public BlogPost BlogPost { get; set; }
        public BlogPost RecentBlogPost { get; set; }
    }
}