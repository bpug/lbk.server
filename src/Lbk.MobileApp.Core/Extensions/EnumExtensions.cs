// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public static class EnumExtensions
    {
        public static IDictionary<int, string> EnumToDictionaryWithDisplayName(this Type type)
        {
            if (!type.IsEnum)
            {
                throw new InvalidCastException(
                    "The EnumToDictionary() extension method can only be used on types of enum. All other types will throw this exception.");
            }

            var dictionary = Enum.GetValues(type).Cast<int>().ToDictionary(a => a, a => GetDisplayName(type, a));

            return dictionary;
        }

        public static IEnumerable<Enum> GetFlags(this Enum value)
        {
            var values = Enum.GetValues(value.GetType()).Cast<Enum>();
            return GetFlags(value, values.ToArray());
        }

        public static IEnumerable<Enum> GetIndividualFlags(this Enum value)
        {
            var values = GetFlagValues(value.GetType());
            return GetFlags(value, values.ToArray());
        }

        private static string GetDisplayName(Type type, int value)
        {
            string name = Enum.GetName(type, value);
            if (!string.IsNullOrWhiteSpace(name))
            {
                var field = type.GetField(name);
                if (field != null)
                {
                    var attr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                    if (attr != null)
                    {
                        return attr.GetName();
                    }
                }
            }

            return string.Empty;
        }

        private static IEnumerable<Enum> GetFlagValues(Type enumType)
        {
            ulong flag = 0x1;
            foreach (var value in Enum.GetValues(enumType).Cast<Enum>())
            {
                ulong bits = Convert.ToUInt64(value);
                if (bits == 0L)
                {
                    ////yield return value;
                    continue; // skip the zero value
                }

                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits)
                {
                    yield return value;
                }
            }
        }

        private static IEnumerable<Enum> GetFlags(Enum value, Enum[] values)
        {
            ulong bits = Convert.ToUInt64(value);
            var results = new List<Enum>();
            for (int i = values.Length - 1; i >= 0; i--)
            {
                ulong mask = Convert.ToUInt64(values[i]);
                if (i == 0 && mask == 0L)
                {
                    break;
                }

                if ((bits & mask) == mask)
                {
                    results.Add(values[i]);
                    bits -= mask;
                }
            }

            if (bits != 0L)
            {
                return Enumerable.Empty<Enum>();
            }

            if (Convert.ToUInt64(value) != 0L)
            {
                return results.Reverse<Enum>();
            }

            if (bits == Convert.ToUInt64(value) && values.Length > 0 && Convert.ToUInt64(values[0]) == 0L)
            {
                return values.Take(1);
            }

            return Enumerable.Empty<Enum>();
        }
    }
}