﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
namespace MvcWebGrid.Utility
{

    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RadioButtonForEnum<TModel, TProperty>(
     this HtmlHelper<TModel> htmlHelper,
     Expression<Func<TModel, TProperty>> expression
 )
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var names = Enum.GetNames(metaData.ModelType);
            var sb = new StringBuilder();
            foreach (var name in names)
            {
                var id = string.Format(
                    "{0}_{1}_{2}",
                    htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                    metaData.PropertyName,
                    name
                );

                var radio = htmlHelper.RadioButtonFor(expression, name, new { id = id }).ToHtmlString();
                sb.AppendFormat(
                    "<label for=\"{0}\">{1}</label> {2}",
                    id,
                    HttpUtility.HtmlEncode(name),
                    radio
                );
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }

}