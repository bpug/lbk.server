// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEnumerableExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public static class IEnumerableExtensions
    {
        public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot<TSource, TFirstKey, TSecondKey, TValue>(
            this IEnumerable<TSource> source, 
            Func<TSource, TFirstKey> firstKeySelector, 
            Func<TSource, TSecondKey> secondKeySelector, 
            Func<IEnumerable<TSource>, TValue> aggregate)
        {
            var retVal = new Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>();

            var l = source.ToLookup(firstKeySelector);
            foreach (var item in l)
            {
                var dict = new Dictionary<TSecondKey, TValue>();
                retVal.Add(item.Key, dict);
                var subdict = item.ToLookup(secondKeySelector);
                foreach (var subitem in subdict)
                {
                    dict.Add(subitem.Key, aggregate(subitem));
                }
            }

            return retVal;
        }

        public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot2<TSource, TFirstKey, TSecondKey, TValue>(
            this IEnumerable<TSource> source, 
            Func<TSource, TFirstKey> firstKeySelector, 
            Func<TSource, TSecondKey> secondKeySelector, 
            Func<IEnumerable<TSource>, TValue> aggregate)
        {
            return source.GroupBy(firstKeySelector).Select(
                x => new
                    {
                        X = x.Key, 
                        Y = source.GroupBy(secondKeySelector).Select(
                            z => new
                                {
                                    Z = z.Key, 
                                    V =
                                     aggregate(
                                         from item in source
                                         where
                                             firstKeySelector(item).Equals(x.Key)
                                             && secondKeySelector(item).Equals(z.Key)
                                         select item)
                                }).ToDictionary(e => e.Z, o => o.V)
                    }).ToDictionary(e => e.X, o => o.Y);
        }
    }
}