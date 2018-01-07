using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcWebGrid.Controllers;

namespace MvcWebGrid
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "AjaxGrid.", id = UrlParameter.Optional } // Parameter defaults
            //);
            // routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "DDlChangeGrid", id = UrlParameter.Optional } // Parameter defaults
            //);
            //   routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "FixedWidthGrid", id = UrlParameter.Optional } // Parameter defaults
            //);
            //  routes.MapRoute(
            //"Default", // Route name
            //"{controller}/{action}/{id}", // URL with parameters
            //new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // Parameter defaults
            //      routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "OldNewRecord", id = UrlParameter.Optional } // Parameter defaults
            //);


            //         routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "PopUp", id = UrlParameter.Optional } // Parameter defaults
            //);


            //routes.MapRoute(
            //          "Default", // Route name
            //          "{controller}/{action}/{id}", // URL with parameters
            //          new { controller = "Account", action = "index", id = UrlParameter.Optional } // Parameter defaults
            //      );

            //     routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "AdjustHeightFixedGrid", id = UrlParameter.Optional } // Parameter defaults
            //);

  //          routes.MapRoute(
  //    "Default", // Route name
  //    "{controller}/{action}/{id}", // URL with parameters
  //       new { controller = "Home", action = "ExportToExcel", id = UrlParameter.Optional } // Parameter defaults
  //);
  //          routes.MapRoute(
  //    "Default", // Route name
  //    "{controller}/{action}/{id}", // URL with parameters
  //       new { controller = "Home", action = "RadioButton", id = UrlParameter.Optional } // Parameter defaults
  //);


  //          routes.MapRoute(
  //    "Default", // Route name
  //    "{controller}/{action}/{id}", // URL with parameters
  //       new { controller = "Home", action = "ModalPopUp", id = UrlParameter.Optional } // Parameter defaults
  //);


  //          routes.MapRoute(
  //    "Default", // Route name
  //    "{controller}/{action}/{id}", // URL with parameters
  //       new { controller = "Home", action = "ScrollDataTableGrid", id = UrlParameter.Optional } // Parameter defaults
  //);


  //          routes.MapRoute(
  //    "Default", // Route name
  //    "{controller}/{action}/{id}", // URL with parameters
  //       new { controller = "DataTableGrid", action = "index", id = UrlParameter.Optional } // Parameter defaults
  //);




            //routes.MapRoute(
            //     "Default", // Route name
            //     "{controller}/{action}/{id}", // URL with parameters
            //        new { controller = "Home", action = "NewAccordian", id = UrlParameter.Optional } // Parameter defaults
            // );
            //routes.MapRoute(
            //     "Default", // Route name
            //     "{controller}/{action}/{id}", // URL with parameters
            //        new { controller = "Home", action = "JsonGrid", id = UrlParameter.Optional } // Parameter defaults
            // );
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                   new { controller = "Home", action = "MergedCellGrid", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            //Session["user"] = null;
        }
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            // Let's write a message to show this got fired---
            //Response.Write("SessionID: " + Session.SessionID.ToString() + "User key: " + (string)Session["user"]);
            //if (HttpContext.Current.Session != null)
            //{
            //    if (Session["user"] != null) // e.g. this is after an initial logon
            //    {
            //        string sKey = (string)Session["user"];
            //        // Accessing the Cache Item extends the Sliding Expiration automatically
            //        string sUser = (string)HttpContext.Current.Cache[sKey];

            //    }
            //}
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            //if (Application["activeVisitors"] != null)
            //{
            //    Application.Lock();
            //    int visitorCount = (int)Application["activeVisitors"];
            //    Application["activeVisitors"] = visitorCount++;
            //    Application.UnLock();
            //}
            //HttpContext.Current.Session["user"] = null;

        }
        protected void Application_Error(object sender, EventArgs e)
        {
            //var httpContext = ((MvcApplication)sender).Context;

            //var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            //var currentController = " ";
            //var currentAction = " ";

            //if (currentRouteData != null)
            //{
            //    if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
            //    {
            //        currentController = currentRouteData.Values["controller"].ToString();
            //    }

            //    if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
            //    {
            //        currentAction = currentRouteData.Values["action"].ToString();
            //    }
            //}

            //var ex = Server.GetLastError();

            //var controller = new BaseController();
            //var routeData = new RouteData();
            //var action = "Index";

            //if (ex is HttpException)
            //{
            //    var httpEx = ex as HttpException;

            //    switch (httpEx.GetHttpCode())
            //    {
            //        case 404:
            //            action = "NotFound";
            //            break;

            //        // others if any

            //        default:
            //            action = "Index";
            //            break;
            //    }
            //}

            //httpContext.ClearError();
            //httpContext.Response.Clear();
            //httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
            //httpContext.Response.TrySkipIisCustomErrors = true;
            //routeData.Values["controller"] = "Error";
            //routeData.Values["action"] = action;

            //controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
            //((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        } 
    }
}