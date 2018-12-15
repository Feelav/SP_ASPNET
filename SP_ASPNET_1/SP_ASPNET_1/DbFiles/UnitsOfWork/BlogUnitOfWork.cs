using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SP_ASPNET_1.DbFiles.Contexts;
using SP_ASPNET_1.DbFiles.Repositories;
using SP_ASPNET_1.Models;

namespace SP_ASPNET_1.DbFiles.UnitsOfWork
{
    public class BlogUnitOfWork : IDisposable
    {
        private readonly SchoolProjectContext _context = new SchoolProjectContext();

        private SchoolRepository<Author> _authorSchoolRepository;
        private SchoolRepository<BlogPost> _blogPostSchoolRepository;
        private SchoolRepository<ProductLine> _productLineSchoolRepository;
        private SchoolRepository<ProductItem> _productItemSchoolRepository;

        public SchoolRepository<BlogPost> BlogPostSchoolRepository
        {
            get
            {
                if (this._blogPostSchoolRepository == null)
                {
                    this._blogPostSchoolRepository = new SchoolRepository<BlogPost>(this._context);
                }
                return _blogPostSchoolRepository;
            }
        }

        public SchoolRepository<Author> AuthorSchoolRepository
        {
            get
            {
                if (this._authorSchoolRepository == null)
                {
                    this._authorSchoolRepository = new SchoolRepository<Author>(this._context);
                }
                return _authorSchoolRepository;
            }
        }

        public SchoolRepository<ProductLine> ProductLineSchoolRepository
        {
            get
            {
                if (this._productLineSchoolRepository == null)
                {
                    this._productLineSchoolRepository = new SchoolRepository<ProductLine>(this._context);
                }
                return _productLineSchoolRepository;
            }
        }

        public SchoolRepository<ProductItem> ProductItemSchoolRepository
        {
            get
            {
                if (this._productItemSchoolRepository == null)
                {
                    this._productItemSchoolRepository = new SchoolRepository<ProductItem>(this._context);
                }
                return _productItemSchoolRepository;
            }
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}