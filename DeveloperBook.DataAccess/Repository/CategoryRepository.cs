using DeveloperBook.DataAccess.Repository.IRepository;
using DeveloperBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperBook.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private ApplicationDbContext _db;
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

        public void Add(CoverType obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Category obj)
		{
			_db.Categories.Update(obj);
		}

        public void Update(CoverType obj)
        {
            throw new NotImplementedException();
        }
    }
}
