// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedListCookieHandler.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Handler
{
    #region using directives

    using System.Web;
    using System.Web.Mvc;

    using Lbk.MobileApp.Web.Extensions;

    #endregion

    public static class PagedListCookieHandler
    {
        #region - Constants and Fields -

        private const int DefaultPageSize = 10;

        #endregion

        #region - Public Methods -

        public static void ClearTempData(this Controller controller, string keyName = null)
        {
            if (controller == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(keyName))
            {
                controller.TempData.Clear();
            }
            else
            {
                if (controller.TempData.ContainsKey(keyName))
                {
                    controller.TempData.Remove(keyName);
                }
            }
        }

        public static T GetItemFromTempData<T>(
            this Controller controller, 
            T item, 
            T defaultValue = null, 
            T nullValue = null, 
            string keyPrefix = null, 
            string keyName = null, 
            bool removeValue = false) where T : class
        {
            if (controller == null)
            {
                return defaultValue;
            }

            string tempKeyName;
            if (!string.IsNullOrEmpty(keyPrefix))
            {
                tempKeyName = string.Concat(keyPrefix, keyName ?? typeof(T).Name);
            }
            else
            {
                tempKeyName = keyName ?? typeof(T).Name;
            }

            if (removeValue)
            {
                controller.ClearTempData(tempKeyName);
                return defaultValue;
            }

            if (item == null || item.Equals(nullValue))
            {
                object savedItem;
                if (controller.TempData.TryGetValue(tempKeyName, out savedItem))
                {
                    item = (T)savedItem;
                }
                else
                {
                    item = defaultValue;
                    if (defaultValue != null)
                    {
                        controller.TempData[tempKeyName] = item;
                    }
                }
            }
            else
            {
                controller.TempData[tempKeyName] = item;
            }

            controller.TempData.Keep();
            return item;
        }

        public static int GetPageSizeFromCookieOrDefault(
            this Controller controller, int pageSize, int defaultPageSize = DefaultPageSize)
        {
            if (controller == null)
            {
                return defaultPageSize;
            }

            if (pageSize == 0)
            {
                var savedPageSizeCookie = controller.Request.Cookies["PageSize"];
                if (savedPageSizeCookie != null && !string.IsNullOrEmpty(savedPageSizeCookie.Value))
                {
                    pageSize = int.Parse(savedPageSizeCookie.Value);
                }
                else
                {
                    pageSize = DefaultPageSize;
                    controller.Response.Cookies.Add(new HttpCookie("PageSize", DefaultPageSize.ToString()));
                }
            }
            else
            {
                var savedPageSizeCookie = controller.Request.Cookies["PageSize"];
                if (savedPageSizeCookie != null && !string.IsNullOrEmpty(savedPageSizeCookie.Value))
                {
                    savedPageSizeCookie.Value = pageSize.ToString();
                    controller.Response.Cookies.Set(savedPageSizeCookie);
                }
                else
                {
                    controller.Response.Cookies.Add(new HttpCookie("PageSize", pageSize.ToString()));
                }
            }

            return pageSize;
        }

        public static T GetSearchItemFormCookieOrDefault<T>(this Controller controller, T searchItem) where T : class
        {
            if (controller == null)
            {
                return null;
            }

            var keyName = string.Concat("SearchItem_", typeof(T).Name);
            if (searchItem == null)
            {
                var savedSearchItemCookie = controller.Request.Cookies[keyName];
                if (savedSearchItemCookie != null && !string.IsNullOrEmpty(savedSearchItemCookie.Value))
                {
                    searchItem = savedSearchItemCookie.Value.DeserializeFromJavaScript<T>();
                }
            }
            else
            {
                var savedSearchItemCookie = controller.Request.Cookies[keyName];
                if (savedSearchItemCookie != null && !string.IsNullOrEmpty(savedSearchItemCookie.Value))
                {
                    savedSearchItemCookie.Value = searchItem.SerializeToJavascript();
                    controller.Response.Cookies.Set(savedSearchItemCookie);
                }
                else
                {
                    controller.Response.Cookies.Add(new HttpCookie(keyName, searchItem.SerializeToJavascript()));
                }
            }

            return searchItem;
        }

        #endregion
    }
}
