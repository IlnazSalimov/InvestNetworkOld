﻿using InvestNetwork.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace InvestNetwork.Models
{
    /// <summary>
    /// Базовый класс для всех классов модели приложения, предоставляющие основные методы действий для них
    /// </summary>
    /// <param name="TEntity">Класс, являющийся типом модели, к которому будет запрошен доступ</param>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Экземпляр класса InvestNetworkEntities, предоставляет доступ к хранилищу данных
        /// </summary>
        private IDataContext dataContext;

        /// <summary>
        /// Экземпляр класса InvestNetworkEntities, предоставляет доступ к хранилищу данных
        /// </summary>
        /// <param name="TEntity">Класс, являющийся типом модели, к которому будет запрошен доступ</param>
        /// <returns>Объект IDbSet, представляющий собой набор записей заданного типа</returns>
        private IDbSet<TEntity> Entities
        {
            get { return this.dataContext.Set<TEntity>(); }
        }

        /// <summary>  
        /// Инициализирует новый экземпляр Repository с внедрением зависемостей к хранилищу данных.
        /// </summary>  
        /// <param name="context">Экземпляр класса InvestNetworkEntities, предоставляющий доступ к хранилищу данных приложения.</param>
        /// <returns>Новый экземпляр ProjectController.</returns>
        public Repository(IDataContext context)
        {
            this.dataContext = context;
        }

        /// <summary>  
        /// Метод отвечающий за предоставление набора записей заданного типа.</summary>
        /// <returns>Экземпляр IQueryable, набор записей.</returns>
        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        /// <summary>  
        /// Метод отвечающий за предоставление объекта с заданным идентификатором и типом.</summary>
        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        /// <summary>  
        /// Метод отвечающий за вставку данного объекта.</summary>
        public int Insert(TEntity entity)
        {
            Entities.Add(entity);
            return dataContext.Entry<TEntity>(entity).Entity.ID;
        }

        /// <summary>  
        /// Метод отвечающий за обновление данного объекта.</summary>
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

        /// <summary>  
        /// Метод отвечающий за удаление данного объекта.</summary>
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

        /// <summary>  
        /// Сохраняет изменения в базу данных.</summary>
        public void SaveChanges()
        {
            //try
            //{
            this.dataContext.SaveChanges();
            /*}
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }*/
        }
    }
}