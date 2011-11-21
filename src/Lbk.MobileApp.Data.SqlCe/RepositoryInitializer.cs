// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryInitializer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe
{
    #region using directives

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Lbk.MobileApp.Data.SqlCe.Initializers;

    #endregion

    public class RepositoryInitializer : IRepositoryInitializer
    {
        #region - Constants and Fields -

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region - Constructors and Destructors -

        public RepositoryInitializer(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this._unitOfWork = unitOfWork;

            Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

            Database.SetInitializer(new DropCreateIfModelChangesSqlCeInitializer<MobileAppDbContext>());
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
