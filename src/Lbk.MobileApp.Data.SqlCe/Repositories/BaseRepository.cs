// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Repositories
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Core.Extensions;
    using Lbk.MobileApp.Data.Core.Extensions;
    using Lbk.MobileApp.Data.Core.Specification;

    #endregion

    public class BaseRepository
    {
        #region - Constructors and Destructors -

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this.UnitOfWork = unitOfWork;
        }

        #endregion

        #region - Properties -

        protected MobileAppDbContext Context
        {
            get
            {
                return (MobileAppDbContext)this.UnitOfWork;
            }
        }

        protected IUnitOfWork UnitOfWork { get; set; }

        #endregion

        #region - Methods -

        protected virtual int Count<TEntity>(ISpecification<TEntity> specification) where TEntity : class
        {
            if (specification == null)
            {
                throw new ArgumentNullException("specification");
            }

            return this.GetDbSet<TEntity>().Where(specification.SatisfiedBy()).Count();
        }

        protected virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return this.Context.Set<TEntity>();
        }

        protected virtual PagedDataList<TEntity> GetPagedDataListElements<TEntity>(
            int pageIndex, int pageSize, string orderBy, bool ascending, ISpecification<TEntity> specification)
            where TEntity : class
        {
            if (pageIndex < 0)
            {
                throw new ArgumentException("pageIndex");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentException("pageSize");
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                throw new ArgumentNullException("orderBy");
            }

            if (specification == null)
            {
                throw new ArgumentNullException("specification");
            }

            var set = this.GetDbSet<TEntity>();
            var totalCount = set.Where(specification.SatisfiedBy()).Count();

            return ascending
                       ? set.Where(specification.SatisfiedBy()).OrderBy(orderBy).Skip(pageIndex * pageSize).Take(
                           pageSize).ToPagedDataList(pageIndex, pageSize, totalCount)
                       : set.Where(specification.SatisfiedBy()).OrderByDescending(orderBy).Skip(pageIndex * pageSize).
                             Take(pageSize).ToPagedDataList(pageIndex, pageSize, totalCount);
        }

        protected virtual PagedDataList<TEntity> GetPagedDataListElements<TEntity, TProperty>(
            int pageIndex, 
            int pageSize, 
            string orderBy, 
            bool ascending, 
            ISpecification<TEntity> specification, 
            params Expression<Func<TEntity, TProperty>>[] paths) where TEntity : class
        {
            if (pageIndex < 0)
            {
                throw new ArgumentException("pageIndex");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentException("pageSize");
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                throw new ArgumentNullException("orderBy");
            }

            if (specification == null)
            {
                throw new ArgumentNullException("specification");
            }

            var set = this.GetDbSet<TEntity>().Includes(paths);

            var totalCount = set.Where(specification.SatisfiedBy()).Count();

            return ascending
                       ? set.Where(specification.SatisfiedBy()).OrderBy(orderBy).Skip(pageIndex * pageSize).Take(
                           pageSize).ToPagedDataList(pageIndex, pageSize, totalCount)
                       : set.Where(specification.SatisfiedBy()).OrderByDescending(orderBy).Skip(pageIndex * pageSize).
                             Take(pageSize).ToPagedDataList(pageIndex, pageSize, totalCount);
        }

        protected virtual IEnumerable<TEntity> GetPagedElements<TEntity>(
            int pageIndex, int pageSize, string orderBy, bool ascending, ISpecification<TEntity> specification)
            where TEntity : class
        {
            if (pageIndex < 0)
            {
                throw new ArgumentException("pageIndex");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentException("pageSize");
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                throw new ArgumentNullException("orderBy");
            }

            if (specification == null)
            {
                throw new ArgumentNullException("specification");
            }

            return ascending
                       ? this.GetDbSet<TEntity>().Where(specification.SatisfiedBy()).OrderBy(orderBy).Skip(
                           pageIndex * pageSize).Take(pageSize).ToList()
                       : this.GetDbSet<TEntity>().Where(specification.SatisfiedBy()).OrderByDescending(orderBy).Skip(
                           pageIndex * pageSize).Take(pageSize).ToList();
        }

        protected virtual void SetEntityState(object entity, EntityState entityState)
        {
            this.Context.Entry(entity).State = entityState;
        }

        #endregion
    }
}
