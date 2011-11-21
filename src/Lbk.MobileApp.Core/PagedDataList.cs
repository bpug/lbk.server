// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedDataList.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Core
{
    #region using directives

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Lbk.MobileApp.Core.Contracts;

    #endregion

    [Serializable]
    public class PagedDataList<T> : IPagedDataList<T>
    {
        #region - Constants and Fields -

        private List<T> _items;

        #endregion

        #region - Constructors and Destructors -

        public PagedDataList(IEnumerable<T> source, int index, int pageSize, int? totalCount = null)
            : this(source.AsQueryable(), index, pageSize, totalCount)
        {
        }

        public PagedDataList(IQueryable<T> source, int index, int pageSize, int? totalCount = null)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Value can not be below 0.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize", "Value can not be less than 1.");
            }

            if (source == null)
            {
                source = new List<T>().AsQueryable();
            }

            var realTotalCount = source.Count();

            this.PageSize = pageSize;
            this.PageIndex = index;
            this.TotalItemCount = totalCount.HasValue ? totalCount.Value : realTotalCount;
            this.PageCount = this.TotalItemCount > 0
                                 ? (int)Math.Ceiling(this.TotalItemCount / (double)this.PageSize)
                                 : 0;

            this.HasPreviousPage = this.PageIndex > 0;
            this.HasNextPage = this.PageIndex < (this.PageCount - 1);
            this.IsFirstPage = this.PageIndex <= 0;
            this.IsLastPage = this.PageIndex >= (this.PageCount - 1);

            if (this.TotalItemCount <= 0)
            {
                return;
            }

            var realTotalPages = (int)Math.Ceiling(realTotalCount / (double)this.PageSize);

            if (realTotalCount < this.TotalItemCount && realTotalPages <= this.PageIndex)
            {
                this.AddRange(source.Skip((realTotalPages - 1) * this.PageSize).Take(this.PageSize));
            }
            else
            {
                this.AddRange(source.Skip(this.PageIndex * this.PageSize).Take(this.PageSize));
            }
        }

        public PagedDataList()
        {
        }

        #endregion

        #region - Properties -

        public int Count
        {
            get
            {
                return this.Items.Count;
            }
        }

        public bool HasNextPage { get; private set; }

        public bool HasPreviousPage { get; private set; }

        public bool IsFirstPage { get; private set; }

        public bool IsLastPage { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public List<T> Items
        {
            get
            {
                return this._items ?? (this._items = new List<T>());
            }

            set
            {
                this._items = value;
            }
        }

        public int PageCount { get; private set; }

        public int PageIndex { get; private set; }

        public int PageNumber
        {
            get
            {
                return this.PageIndex + 1;
            }
        }

        public int PageSize { get; private set; }

        public int TotalItemCount { get; private set; }

        #endregion

        #region - Indexers -

        public T this[int index]
        {
            get
            {
                return this.Items[index];
            }

            set
            {
                this.Items[index] = value;
            }
        }

        #endregion

        #region - Public Methods -

        public void AddRange(IEnumerable<T> collection)
        {
            this.Items.AddRange(collection);
        }

        public int IndexOf(T item)
        {
            return this.Items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.Items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.Items.RemoveAt(index);
        }

        #endregion

        #region - Implemented Interfaces -

        #region ICollection<T>

        public void Add(T item)
        {
            this.Items.Add(item);
        }

        public void Clear()
        {
            this.Items.Clear();
        }

        public bool Contains(T item)
        {
            return this.Items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.Items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return this.Items.Remove(item);
        }

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region IEnumerable<T>

        public IEnumerator<T> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        #endregion

        #endregion
    }
}
