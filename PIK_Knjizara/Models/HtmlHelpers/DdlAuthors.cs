using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIK_Knjizara.Models.HtmlHelpers
{
    public static class DdlAuthors
    {
        public static MvcHtmlString DDLAuthors(this HtmlHelper html, List<Author> authors)
        {
            TagBuilder selectTag = new TagBuilder("select");
            selectTag.MergeAttribute("id", "ID");
            selectTag.MergeAttribute("name", "ID");
            selectTag.AddCssClass("form-control");

            foreach (Author author in authors)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", author.ID.ToString());
                optionTag.SetInnerText(author.ToString());
                selectTag.InnerHtml += optionTag.ToString();
            }

            return new MvcHtmlString(selectTag.ToString());
        }
    }
}