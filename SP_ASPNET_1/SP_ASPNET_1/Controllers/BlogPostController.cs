using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SP_ASPNET_1.DbFiles.UnitsOfWork;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;

namespace SP_ASPNET_1.Controllers
{
    [RoutePrefix("Blog")]
    public class BlogPostController : Controller
    {
        private BlogUnitOfWork _unitOfWork = new BlogUnitOfWork();

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            BlogIndexViewModel viewModel = new BlogIndexViewModel()
            {
                BlogPosts = _unitOfWork.BlogPostSchoolRepository.Get(null, null, "Author")
            };

            return View(viewModel);
        }

        //[Route("Detail/{int:id}")]
        [HttpGet]
        public ActionResult Detail()
        {
            BlogPost blogPost = _unitOfWork.BlogPostSchoolRepository.Get(null,
                x => x.OrderBy( entity => entity.DateTime))
                .FirstOrDefault();

            return View(blogPost);
        }
        //[Route("Detail/{int:id}")]
        [HttpGet]
        public ActionResult Detail(int id)
        {
            BlogPost blogPost = _unitOfWork.BlogPostSchoolRepository.GetByID(id);

            return View(blogPost);
        }


        [Route("Create")]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //[Route("Edit/{int:id}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //[Route("Edit/{int:id}")]
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

        //[Route("delete/{int:id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //[Route("edit/{int:id}")]
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
