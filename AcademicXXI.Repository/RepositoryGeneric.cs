﻿using AcademicXXI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository
{
    public abstract class  RepositoryGeneric<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private AcademicXXIDataContext _dbContext;
        protected DbSet<TEntity> DbSet { get;private set; }

        public RepositoryGeneric(AcademicXXIDataContext dbContext)
        {
            this._dbContext = dbContext;
            this.DbSet = _dbContext.Set<TEntity>();
        }

        public abstract void Delete(int? idEntity);

        public void Add(TEntity entity)
        {
            
                DbSet.Add(entity);
            Save();
        }

        
        

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            
                return DbSet.Where(predicate).FirstOrDefault();
            
        }

        public IEnumerable<TEntity> GetAll()
        {
            
                return DbSet.ToList<TEntity>();
           
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Metodo encargado de guardar los cambios en el contexto EF
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}