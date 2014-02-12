using InvestNetwork.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace InvestNetwork.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        private IDataContext dataContext;

        private IDbSet<TEntity> Entities
        {
            get { return this.dataContext.Set<TEntity>(); }
        }

        public Repository(InvestNetworkEntities context)
        {
            this.dataContext = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            //Entities.Find(entity_ => entity_
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dataContext != null)
                {
                    this.dataContext.Dispose();
                    this.dataContext = null;
                }
            }
        }

        public void Save()
        {
            this.dataContext.SaveChanges();
        }
    }
}