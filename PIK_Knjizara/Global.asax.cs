﻿using PIK_Library.DAL;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PIK_Library.Dal;
using PIK_Knjizara.App_Start;

namespace PIK_Knjizara
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly IRepo _repo;

        public MvcApplication()
        {
            _repo = RepoFactory.GetRepo();
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["database"] = _repo;
        }

        protected void Application_Error()
        {
        }
    }
}
