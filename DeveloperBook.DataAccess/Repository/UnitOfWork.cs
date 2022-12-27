﻿using DeveloperBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperBook.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;
		public UnitOfWork(ApplicationDbContext db) 
		{
			_db = db;
			Category = new CategoryRepository(_db);
			CoverType= new CoverTypeRepository(_db);
		}
		public ICategoryRepository Category { get; private set; }

		public ICoverTypeRepository CoverType { get; private set; }

		//ICategoryRepository IUnitOfWork.CoverType => throw new NotImplementedException();

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
