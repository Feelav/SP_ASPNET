using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SP_ASPNET_1.DbFiles.UnitsOfWork;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.DbFiles.Operations;
using SP_ASPNET_1.ViewModels;
using System.Threading.Tasks;
using System.Web.Routing;

namespace SP_ASPNET_1.Controllers
{
    [RoutePrefix("Blog")]
    public class BlogPostController : AsyncController
    {
        private readonly BlogPostOperations _blogPostOperations = new BlogPostOperations();

        [Route("")]
        [HttpGet]
        public async void  IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment();

            BlogIndexViewModel result = await this._blogPostOperations.GetBlogIndexViewModelAsync();

            AsyncManager.Parameters["blogPostViewModel"] = result;
            AsyncManager.OutstandingOperations.Decrement();
        }

        public ActionResult IndexCompleted(BlogIndexViewModel blogPostViewModel)
        {
            return View(blogPostViewModel);
        }

        [Route("Detail/{id:int?}")]
        [HttpGet]
        public ActionResult SinglePost(int? id)
        {
            BlogPost blogPost;

            if (id == null)
            {
                blogPost = this._blogPostOperations.GetLatestBlogPost();
            }
            else
            {
                blogPost = this._blogPostOperations.GetBlogPostByIdD((int)id);
            }

            return View(blogPost);
        }
        [Route("Detail/{id:int}")]
        [HttpGet]
        public ActionResult Detail(int id)
        {
            BlogPost blogPost = this._blogPostOperations.GetBlogPostByIdD(id);

            return View(blogPost);
        }


        [Route("Create")]
        [HttpPost]
        public ActionResult Create(BlogPost blogPost)
        {
            try
            {
                this._blogPostOperations.Create(blogPost);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Edit/{id:int}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [Route("Edit/{id:int}")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("delete/{id:int}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [Route("edit/{id:int}")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
