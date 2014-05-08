using InvestNetwork.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace InvestNetwork.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
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
            {
                throw new ArgumentException("Cannot add a null entity.");
            }

            var entry = dataContext.Entry<TEntity>(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = dataContext.Set<TEntity>();
                TEntity attachedEntity = set.Local.SingleOrDefault(e => e.ID == entity.ID);  // You need to have access to key

                if (attachedEntity != null)
                {
                    var attachedEntry = dataContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }
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