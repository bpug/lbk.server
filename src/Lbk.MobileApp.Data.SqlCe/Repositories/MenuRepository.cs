// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Repositories
{
    #region using directives

    using System.Data;
    using System.Linq;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Data.Core;
    using Lbk.MobileApp.Data.SqlCe.Repositories.Specifications;
    using Lbk.MobileApp.Model;

    #endregion

    public class MenuRepository : BaseRepository, IMenuRepository
    {
        #region - Constructors and Destructors -

        public MenuRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region IMenuRepository

        public void Create(Menu menu)
        {
            this.GetDbSet<Menu>().Add(menu);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long menuId)
        {
            var entity = this.GetDbSet<Menu>().Where(x => x.Id == menuId).Single();
            this.GetDbSet<Menu>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Menu GetMenu(long menuId)
        {
            return this.GetDbSet<Menu>().Include("Foods").Where(x => x.Id == menuId).Single();
        }

        public PagedDataList<Menu> GetMenus(PagedDataInput<Menu> pagedDataInput)
        {
            var specification = new MenuPagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public void Update(Menu menu)
        {
            var entity = this.GetDbSet<Menu>().Where(x => x.Id == menu.Id).Single();

            entity.Date = menu.Date;
            entity.Description = menu.Description;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
