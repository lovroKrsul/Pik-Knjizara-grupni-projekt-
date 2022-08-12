using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class BookVM
    {
        public Book NewBook { get; set; }
        public Book OldBook { get; set; }
    }
}