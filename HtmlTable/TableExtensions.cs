using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace HtmlTable
{
    public static class TableExtensions
    {
        public static MvcHtmlString Table<T>(this HtmlHelper htmlHelper, IEnumerable<T> rows)
        {
            return TableHelper(htmlHelper, rows);
        }

        private static MvcHtmlString TableHelper<T>(this HtmlHelper htmlHelper, IEnumerable<T> rows)
        {
            if (rows == null)
            {
                return MvcHtmlString.Empty;
            }

            var modelGenericTypeProperties = typeof(T)
                .GetProperties();
            var tableHeadings = GetTableHeadings(modelGenericTypeProperties).ToList();

            var table = new TagBuilder("table");
            var theadingCollection = tableHeadings
                .Select(th => th)
                .ToList();
            var thead = GetTHead(theadingCollection.Select(th => th.DisplayName ?? string.Empty));
            var tbody = GetTBody(theadingCollection.Select(th => th.PropertyName), rows);

            table.InnerHtml += thead.InnerHtml;
            table.InnerHtml += tbody.InnerHtml;

            return new MvcHtmlString(table.ToString(TagRenderMode.Normal));
        }

        private static TagBuilder GetTBody(IEnumerable<string> propertyNames, IEnumerable rows)
        {
            var tbody = new TagBuilder("tbody");
            foreach (var row in rows)
            {
                var tr = new TagBuilder("tr");
                foreach (var propertyName in propertyNames)
                {
                    var td = new TagBuilder("td");
                    var propertyType = row.GetType();
                    var propertyValue = propertyType
                                            .GetProperty(propertyName)
                                            ?.GetValue(row, null)
                                            ?.ToString()
                                        ?? string.Empty;
                    td.SetInnerText(propertyValue);
                    tr.InnerHtml += td.ToString(TagRenderMode.Normal);
                }

                tbody.InnerHtml += tr.ToString(TagRenderMode.Normal);
            }

            return tbody;
        }

        private static IEnumerable<(string PropertyName, string DisplayName)> GetTableHeadings(
            PropertyInfo[] properties)
        {
            foreach (var propertyInfo in properties)
            {
                var tableHeading = propertyInfo
                    .GetCustomAttributes(typeof(DisplayAttribute), true)
                    .Cast<DisplayAttribute>()
                    .SingleOrDefault();
                yield return (propertyInfo.Name, tableHeading?.Name);
            }
        }

        private static TagBuilder GetTHead(IEnumerable<string> tableHeadings)
        {
            var thead = new TagBuilder("thead");
            var tr = new TagBuilder("tr");
            foreach (var tableHeading in tableHeadings)
            {
                var th = new TagBuilder("th");
                th.SetInnerText(tableHeading);
                tr.InnerHtml += th.ToString(TagRenderMode.Normal);
            }

            thead.SetInnerText(tr.InnerHtml);

            return thead;
        }
    }
}