using SP_ASPNET_1.DbFiles.Operations;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;
using System.Web.Mvc;
using System.Web.Routing;
using SP_ASPNET_1.BusinessLogic;

namespace SP_ASPNET_1.Controllers
{
    [RoutePrefix("Blog")]
    public class BlogPostController : Controller
    {
        private readonly BlogPostOperations _blogPostOperations = new BlogPostOperations();

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            //return this.View();
            BlogIndexViewModel result = this._blogPostOperations.GetBlogIndexViewModel();
            ViewBag.Title = "Blog";
            return this.View(result);
        }


        [Route("Detail/{id:int?}")]
        [HttpGet]
        public ActionResult SinglePost(int? id)
        {
            ViewBag.Title = "single post";

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

        [Route("Detail/Random")]
        [HttpGet]
        public ActionResult RandomPost()
        {
            ViewBag.Title = "single post";

            BlogPost blogPost;

            blogPost = this._blogPostOperations.GetRandomBlogPost();

            return View(blogPost);
        }

        [Route("LatestPost")]
        [HttpGet]
        public ActionResult LatestPost()
        {

            BlogPost blogPost;

            blogPost = this._blogPostOperations.GetLatestBlogPost();

            return this.PartialView("~/Views/BlogPost/_BlogPostRecentPartialView.cshtml", blogPost);
        }

        //[Route("Detail/{id:int}")]
        //[HttpGet]
        //public ActionResult Detail(int id)
        //{
        //    BlogPost blogPost = this._blogPostOperations.GetBlogPostByIdD(id);

        //    return View(blogPost);
        //}


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

        [Route("Edit/{id:int?}")]
        [HttpGet]
        public ActionResult EditBlogPost(int id)
        {
            BlogPost blogPost;

            blogPost = this._blogPostOperations.GetBlogPostByIdD((int)id);

            return View(blogPost);
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

        [Route("Delete/{id:int}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                this._blogPostOperations.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return this.HttpNotFound();
            }
        }

        //[Route("edit/{id:int}")]
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
