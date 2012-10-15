using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel;
 
namespace Lbk.MobileApp.Web.Helpers
{
    public static class ImageExtension
    {
        public static MvcHtmlString ImageActionLink(
            this HtmlHelper helper,
            string imageUrl,
            string altText,
            string actionName,
            string controllerName,
            object routeValues,
            object linkHtmlAttributes,
            object imgHtmlAttributes)
        {
            var linkAttributes = AnonymousObjectToKeyValue(linkHtmlAttributes);
            var imgAttributes = AnonymousObjectToKeyValue(imgHtmlAttributes);
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            imgBuilder.MergeAttributes(imgAttributes, true);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routeValues));
            linkBuilder.MergeAttributes(linkAttributes, true);
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }
 
        public static MvcHtmlString ImageActionLink(
            this HtmlHelper helper,
            string imageUrl,
            string altText,
            string actionName,
            object routeValues,
            object imgHtmlAttributes)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return null;
            }

            var imgAttributes = AnonymousObjectToKeyValue(imgHtmlAttributes);
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            imgBuilder.MergeAttributes(imgAttributes, true);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, routeValues));
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }
 
        public static MvcHtmlString ImageActionLink(
            this HtmlHelper helper,
            string imageUrl,
            string altText,
            string actionName,
            object routeValues)
        {
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, routeValues));
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }
 
        public static MvcHtmlString ImageActionLink(
            this HtmlHelper helper,
            string imageUrl,
            string altText,
            string actionName)
        {
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName));
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }

        public static MvcHtmlString Image(
            this HtmlHelper helper,
            string imageUrl,
            string altText,
             object imgHtmlAttributes)
        {
            var imgAttributes = AnonymousObjectToKeyValue(imgHtmlAttributes);
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            imgBuilder.MergeAttributes(imgAttributes, true);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }
 
        private static Dictionary<string, object> AnonymousObjectToKeyValue(object anonymousObject)
        {
            var dictionary = new Dictionary<string, object>();
            if (anonymousObject != null)
            {
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(anonymousObject))
                {
                    if (propertyDescriptor.Name == "style")
                    {
                        dictionary.Add("class", propertyDescriptor.GetValue(anonymousObject));
                    }else
                    {
                        dictionary.Add(propertyDescriptor.Name, propertyDescriptor.GetValue(anonymousObject));
                    }
                   
                }
            }
            return dictionary;
        }
    }
}