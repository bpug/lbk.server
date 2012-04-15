// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Web.Extensions.ModelBinder;
    using Lbk.MobileApp.Web.Unity;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    #endregion

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        #region - Constants and Fields -

        private static IUnityContainer _Container;

        #endregion

        #region - Public Methods -

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.([iI][cC][oO]|[gG][iI][fF])(/.*)?" });
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", 
                // Route name
                "{controller}/{action}/{id}", 
                // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );
        }

        public override void Init()
        {
            this.EndRequest += this.EndRequestHandler;

            base.Init();
        }

        #endregion

        #region - Methods -

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ////ModelBinders.Binders.Add(typeof(DateTime), new MyDateTimeModelBinder());

            InitializeDependencyInjectionContainer();
            //InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            var repositoryInitializer = ServiceLocator.Current.GetInstance<IRepositoryInitializer>();
            repositoryInitializer.Initialize();
        }

        private static void InitializeDependencyInjectionContainer()
        {
            _Container = new UnityContainerFactory().CreateConfiguredContainer();
            var serviceLocator = new UnityServiceLocator(_Container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            DependencyResolver.SetResolver(new UnityDependencyResolver(_Container));
        }

        private void EndRequestHandler(object sender, EventArgs e)
        {
            // This is a workaround since subscribing to HttpContext.Current.ApplicationInstance.EndRequest 
            // from HttpContext.Current.ApplicationInstance.BeginRequest does not work. 
            IEnumerable<UnityHttpContextPerRequestLifetimeManager> perRequestManagers =
                _Container.Registrations.Select(r => r.LifetimeManager).OfType
                    <UnityHttpContextPerRequestLifetimeManager>().ToArray();

            foreach (var manager in perRequestManagers)
            {
                manager.Dispose();
            }
        }

        #endregion
    }
}
