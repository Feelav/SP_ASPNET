using SP_ASPNET_1.DbFiles.UnitsOfWork;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SP_ASPNET_1.DbFiles.Operations
{
    public class BlogPostOperations
    {
        private BlogUnitOfWork _unitOfWork = new BlogUnitOfWork();

        public async Task<BlogIndexViewModel> GetBlogIndexViewModelAsync()
        {
            List<BlogPost> blogPosts = (await _unitOfWork.BlogPostSchoolRepository.GetAsync(null, b => b.OrderByDescending(d => d.DateTime), "Author")).ToList();

            return new BlogIndexViewModel()
            {
                BlogPosts = blogPosts.GetRange(1, blogPosts.Count - 1),
                RecentBlogPost = blogPosts.Take(1).FirstOrDefault()
            };
        }

        public BlogPost GetBlogPostByIdD(int id)
        {
            return _unitOfWork.BlogPostSchoolRepository.GetByID(id);
        }

        public BlogPost GetLatestBlogPost()
        {
            return _unitOfWork.BlogPostSchoolRepository.GetAsync(null,
                    x => x.OrderBy(entity => entity.DateTime))
                .Result
                .FirstOrDefault();
        }

        internal void Create(BlogPost blogPost)
        {
            //this._unitOfWork.BlogPostSchoolRepository.
        }
    }
}