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
            //var asdf = db.Categories.ToList();

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

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entitiy)
        {
            dbSet.RemoveRange(entitiy);
        }
    }
}
