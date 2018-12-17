
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SP_ASPNET_1.BusinessLogic;
using SP_ASPNET_1.DbFiles.Repositories;
using SP_ASPNET_1.Models;

public class BlogPostSchoolRepositoryDecorator : IRepository<BlogPost>
{
    private readonly SchoolRepository<BlogPost> _schoolRepository;
    public BlogPostSchoolRepositoryDecorator(SchoolRepository<BlogPost> blogPostSchoolRepository)
    {
        this._schoolRepository = blogPostSchoolRepository;
    }

    public IQueryable<BlogPost> Entities { get; }
    public void Remove(BlogPost entity)
    {
        this._schoolRepository.Remove(entity);
    }

    public void Insert(BlogPost entity)
    {
        this._schoolRepository.Insert(entity);
    }

    public void Update(BlogPost entityToUpdate)
    {
        this._schoolRepository.Update(entityToUpdate);
    }

    public BlogPost GetByID(object ID)
    {
        //TODO: Dirty
        return (new BlogPost[] {this._schoolRepository.GetByID(ID)}).IncludeImagePrefix(Constants.BLOGPOST_IMAGE_PREFIF)
            .FirstOrDefault();
    }

    public Task<IEnumerable<BlogPost>> GetAsync(Expression<Func<BlogPost, bool>> filter = null, Func<IQueryable<BlogPost>, IOrderedQueryable<BlogPost>> orderBy = null, string includeProperties = "")
    {
        //TODO: Dirty
        return new Task<IEnumerable<BlogPost>>(() =>
        {
            return (this._schoolRepository.GetAsync(filter, orderBy, includeProperties)).Result
                .IncludeImagePrefix(Constants.BLOGPOST_IMAGE_PREFIF);
        });
    }

    public IEnumerable<BlogPost> Get(Expression<Func<BlogPost, bool>> filter = null, Func<IQueryable<BlogPost>, IOrderedQueryable<BlogPost>> orderBy = null, string includeProperties = "")
    {
        return this._schoolRepository.Get(filter, orderBy, includeProperties)
            .IncludeImagePrefix(Constants.BLOGPOST_IMAGE_PREFIF);
    }
}