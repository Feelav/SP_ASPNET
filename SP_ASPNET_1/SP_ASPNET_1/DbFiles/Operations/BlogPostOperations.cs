using SP_ASPNET_1.DbFiles.UnitsOfWork;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;
using SP_ASPNET_1.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SP_ASPNET_1.DbFiles.Operations
{
    public class BlogPostOperations
    {
        private SchoolUnitOfWork _unitOfWork = new SchoolUnitOfWork();

        public async Task<BlogIndexViewModel> GetBlogIndexViewModelAsync()
        {
            List<BlogPost> blogPosts = (await _unitOfWork.BlogPostSchoolRepository.GetAsync(null, b => b.OrderByDescending(d => d.DateTime), "Author")).ToList();

            return new BlogIndexViewModel()
            {
                BlogPosts = blogPosts.GetRange(1, blogPosts.Count - 1),
                RecentBlogPost = blogPosts.Take(1).FirstOrDefault()
            };
        }

        public BlogIndexViewModel GetBlogIndexViewModel()
        {
            List<BlogPost> blogPosts = _unitOfWork.BlogPostSchoolRepository
                .Get(null, b => b.OrderByDescending(d => d.DateTime), "Author").ToList();

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
            return _unitOfWork.BlogPostSchoolRepository.Get(null,
                    x => x.OrderByDescending(entity => entity.DateTime))
                .FirstOrDefault();
        }


        public BlogPost GetRandomBlogPost()
        {
            List<BlogPost> posts = _unitOfWork.BlogPostSchoolRepository.Get(null,
                    x => x.OrderByDescending(entity => entity.DateTime))
                .ToList();
            Random rnd = new Random();
            return posts[rnd.Next(posts.Count)];
        }

        internal void Create(BlogPost blogPost)
        {
            try
            {
                this._unitOfWork.BlogPostSchoolRepository.Insert(blogPost);
                this._unitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                BlogPost post = this.GetBlogPostByIdD(id);
                this._unitOfWork.BlogPostSchoolRepository.Remove(post);
                this._unitOfWork.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}