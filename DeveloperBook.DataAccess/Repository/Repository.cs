using DeveloperBook.DataAccess.Repository.IRepository;
using DeveloperBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.Products.Include(u => u.Category).Include(u=>u.CoverType);
            this.dbSet = _db.Set<T>();

            //1.EXAMPLE - GET ALL CATEGORIES IN DATABASE
            //  FIRST THING: PROGRAM BE CONNECTEFD TO DATABASE (CONNEXTION string + 2 lines in program.cs)

            //var allCategories = db.Categories.ToList();
            //var obj = new Category()
            //{
            //    CreatedDateTime = DateTime.Now,
            //    Name = "safdsd"
            //};

            //db.Categories.Add(obj);
            //db.SaveChanges();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        //includeProp - "Category,CoverType"
        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (includeProperties != null)
            {
                foreach(var includeprop in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeprop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeprop);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
