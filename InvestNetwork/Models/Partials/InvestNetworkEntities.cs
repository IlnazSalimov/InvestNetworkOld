using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using InvestNetwork.Core;

namespace InvestNetwork.Models
{
    public partial class InvestNetworkEntities: IDataContext
    {
        public new System.Data.Entity.IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        DbEntityEntry<TEntity> IDataContext.Entry<TEntity>(TEntity entity)
        {
            return this.Entry(entity);
        }
    }
}