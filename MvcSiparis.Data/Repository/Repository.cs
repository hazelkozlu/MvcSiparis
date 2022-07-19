﻿using Microsoft.EntityFrameworkCore;
using MvcSiparis.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcSiparis.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();  
        }
        public void Add(T entity)
        {
           _dbSet.Add(entity);  
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);  
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                //x=>x.id==1;
                query = query.Where(filter);    
            }
            //Product,Order
            if(includeProperties != null)
            {
                foreach(var item in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);    
                }
            }
            return query.ToList();
        }

        public T GetFirtsOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                //x=>x.id==1;
                query = query.Where(filter);
            }
            //Product,Order
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }

        public void RemoveRange(IEnumerable<T> entites)
        {
            _dbSet.RemoveRange(entites);    
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);  
        }
    }
}
