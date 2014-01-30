// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumDropDownList.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Helpers.HtmlHelpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using Lbk.MobileApp.Core.Extensions;

    public static class EnumDropDownList
    {
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum>> expression,
            TEnum availableItems,
            bool includeNoneOption = false,
            string noneName = "None",
            object htmlAttributes = null)
        {
            return htmlHelper.EnumDropDownListFor(
                expression, _ => availableItems, includeNoneOption, noneName, htmlAttributes);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum>> expression,
            Expression<Func<TModel, TEnum>> availableItemsExpression = null,
            bool includeNoneOption = false,
            string noneName = "None",
            object htmlAttributes = null)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var enumType = GetNonNullableModelType(metadata);
            var orderedItems = new List<OrderableSelectListItem>();

            ICollection<Enum> availableValues = null;
            if (availableItemsExpression != null)
            {
                var availableItems = availableItemsExpression.Compile()(htmlHelper.ViewData.Model);
                availableValues = availableItems.ConvertTo<Enum>()
                                                .GetIndividualFlags()
                                                .ToList();
            }

            foreach (var field in enumType.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public))
            {
                bool includeNone = field.Name.EndsWith(noneName, StringComparison.OrdinalIgnoreCase)
                                   && !includeNoneOption;

                bool notAvailable = availableValues != null
                                    && !availableValues.Contains((Enum)Enum.Parse(typeof(TEnum), field.Name, true));
                if (notAvailable || includeNone)
                {
                    continue;
                }

                string text = field.Name;
                string value = field.Name;
                bool selected = field.GetValue(null)
                                     .Equals(metadata.Model);
                int? order = null;

                var attr = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;
                if (attr != null)
                {
                    text = attr.GetName();
                    order = attr.GetOrder();
                }

                orderedItems.Add(
                    new OrderableSelectListItem
                    {
                        Order = order.GetValueOrDefault(100),
                        Text = text,
                        Value = value,
                        Selected = selected
                    });
            }

            var items = orderedItems.OrderBy(x => x.Order)
                                    .Select(
                                        orderableSelectListItem => new SelectListItem
                                        {
                                            Text = orderableSelectListItem.Text,
                                            Value = orderableSelectListItem.Value,
                                            Selected = orderableSelectListItem.Selected
                                        })
                                    .ToList();

            if (metadata.IsNullableValueType)
            {
                items.Insert(
                    0,
                    new SelectListItem
                    {
                        Text = string.Empty,
                        Value = string.Empty
                    });
            }

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }

        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            var realModelType = modelMetadata.ModelType;
            var underlyingType = Nullable.GetUnderlyingType(realModelType);

            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }

            return realModelType;
        }

        private class OrderableSelectListItem : SelectListItem
        {
            public int Order { get; set; }
        }
    }
}