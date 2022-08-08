using PIK_Library.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIK_Library.DAL
{
    public static class RepoFactory
    {
        public static IRepo GetRepo() => new DBRepo();
    }
}
