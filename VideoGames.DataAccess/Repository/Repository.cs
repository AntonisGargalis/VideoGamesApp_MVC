﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VideoGames.DataAccess.Data;
using VideoGames.DataAccess.Repository.IRepository;

namespace VideoGames.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
            //_db.Categories == dbSet
            _db.Products.Include(u => u.Category).Include(u=>u.CategoryId);
        }
        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            if (tracked)
            {
                IQueryable<T> query = DbSet;
                query = query.Where(filter);
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties.Split(
                        new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
            }
            else
            {
                IQueryable<T> query = DbSet.AsNoTracking();
                query = query.Where(filter);
                if (!string.IsNullOrEmpty(includeProperties))
                {
                    foreach (var includeProp in includeProperties.Split(
                        new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }            
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProp in includeProperties.Split(
                    new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity); 
        }

        public void RemoveRang(IEnumerable<T> entity)
        {
            DbSet.RemoveRange(entity);
        }
    }
}
