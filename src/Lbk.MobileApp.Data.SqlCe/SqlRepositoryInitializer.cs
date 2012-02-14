// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlRepositoryInitializer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe
{
    #region using directives

    using System;
    using System.Data.Entity;

    using Lbk.MobileApp.Data.SqlCe.Initializers;

    #endregion

    public class SqlRepositoryInitializer : IRepositoryInitializer
    {
        #region - Constants and Fields -

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region - Constructors and Destructors -

        public SqlRepositoryInitializer(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this._unitOfWork = unitOfWork;

            Database.SetInitializer(new CreateIfNotExistsAndMigrateSqlInitializer<MobileAppDbContext>());
        }

        #endregion

        #region - Properties -

        protected MobileAppDbContext Context
        {
            get
            {
                return (MobileAppDbContext)this._unitOfWork;
            }
        }

        #endregion

        #region - Implemented Interfaces -

        #region IRepositoryInitializer

        public void Initialize()
        {
            ////this.Context.Set<Answer>().ToList().Count();
        }

        #endregion

        #endregion
    }
}
