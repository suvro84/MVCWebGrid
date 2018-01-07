using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using MvcWebGrid.Models;
//using System.Web.Caching;
using MvcWebGrid.Models.Data;
using System.Runtime.Caching;
using System.Xml;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Web.UI.WebControls;




using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Web.UI.WebControls;
using MvcGridApp;

namespace MvcWebGrid.Controllers
{
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }
        public ICacheProvider Cacheobj { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }
            if (Cacheobj == null) { Cacheobj = new DefaultCacheProvider(); }
            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            string filepath = Server.MapPath("XML/RolePrev.xml");

            User objUser = new User();

            XDocument xdocument = XDocument.Load(filepath);
           
            XNamespace nm = XNamespace.Get("http://schemas.microsoft.com");
            List<string> prev = xdocument.Descendants(nm + "Previleges")
                                   .Select(x => x.Value)
                                   .ToList();
            objUser.Previleges = new List<string>();
            foreach (string str in prev)
            {
                objUser.Previleges.Add(str);
            }
            //var results = from Previleges in xdocument.Descendants(nm + "Previleges")
            //              select new User
            //              {
            //                  Previleges.Add(Previleges.Value)

            //              };

            var query = from c in xdocument.Root.Descendants(nm + "Previleges")
                        select c;

            var books = (from book in xdocument.Descendants("RoleUser")
                         select new User
                         {
                             Role = book.Element("Role").Value,
                             //Previleges = book.Element("Previleges").Value.ToString()

                         }).ToList();
            //List<User> lstBook = new List<User>();
            //User objUser = null;

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(filepath);
            objUser.Role = xdoc.GetElementsByTagName("Role")[0].InnerText;
            objUser.Previleges = new List<string>();
            XmlNodeList list = xdoc.GetElementsByTagName("Previleges");
            for (int i = 0; i < list.Count; i++)
            {

                XmlElement Previleges = (XmlElement)xdoc.GetElementsByTagName("Previleges")[i];

                objUser.Previleges.Add(Previleges.InnerText);

            }
            //  string strXML=xdoc.InnerXml;
            // User usobj = DeSerializeAnObject(strXML, typeof(User)) as User;



            //Session["User"] = objUser;
            HttpCookie _userInfoCookies = new HttpCookie("UserInfo");

            String strUser = SerializeAnObject(objUser);
            _userInfoCookies["User"] = strUser;

            Response.Cookies.Add(_userInfoCookies);
            _userInfoCookies = Request.Cookies["UserInfo"];
            if (_userInfoCookies != null)
            {
                User us = DeSerializeAnObject(_userInfoCookies["User"].ToString(), typeof(User)) as User;
                //  objUser = (User)_userInfoCookies["User"];

            }
            return View();
        }

        /// ---- DeSerializeAnObject ------------------------------
        /// <summary>
        /// DeSerialize an object
        /// </summary>
        ///XmlOfAnObject">The XML string
        ///ObjectType">The type of object
        /// A deserialized object...must be cast to correct type

        public static Object DeSerializeAnObject(string XmlOfAnObject, Type ObjectType)
        {
            StringReader StrReader = new StringReader(XmlOfAnObject);
            XmlSerializer Xml_Serializer = new XmlSerializer(ObjectType);
            XmlTextReader XmlReader = new XmlTextReader(StrReader);
            try
            {
                Object AnObject = Xml_Serializer.Deserialize(XmlReader);
                return AnObject;
            }
            finally
            {
                XmlReader.Close();
                StrReader.Close();
            }
        }


        // ---- SerializeAnObject -----------------------------
        /// <summary>
        /// Serializes an object to an XML string
        /// </summary>
        ///AnObject">The Object to serialize
        /// <returns>XML string</returns>

        public static string SerializeAnObject(object AnObject)
        {
            XmlSerializer Xml_Serializer = new XmlSerializer(AnObject.GetType());
            StringWriter Writer = new StringWriter();

            Xml_Serializer.Serialize(Writer, AnObject);
            return Writer.ToString();
        }
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            //if (ModelState.IsValid)
            //{
            //    if (MembershipService.ValidateUser(model.UserName, model.Password))
            //    {
            //        FormsService.SignIn(model.UserName, model.RememberMe);
            //        if (Url.IsLocalUrl(returnUrl))
            //        {
            //            return Redirect(returnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "The user name or password provided is incorrect.");
            //    }
            //}


            // this could be a new "illegal" logon, so we need to check
            // if these credentials are already in the Cache

            string sKey = model.UserName + model.Password;

            //string sUser = Convert.ToString(Cacheobj[sKey]);


            HttpCookie _userInfoCookies = new HttpCookie("UserInfo");
            _userInfoCookies["UserName"] = model.UserName;
            _userInfoCookies["Key"] = sKey;
            Response.Cookies.Add(_userInfoCookies);
            // string sUser = Cacheobj.Get(sKey);
            string sUser = (string)HttpContext.Cache[sKey];






            if (sUser == null || sUser == String.Empty)
            {
                // No Cache item, so sesion is either expired or user is new sign-on
                // Set the cache item and Session hit-test for this user---
                TimeSpan SessTimeOut = new TimeSpan(0, 0, Session.Timeout, 0, 0);
                //Cache.Insert(sKey, sKey, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);
                Cacheobj.Set("sKey", model, 30);
                //Session["user"] = model.UserName + model.Password;
                return RedirectToAction("Index", "Home");
                // Let them in - redirect to main page, etc.
                // Label1.Text = "<Marquee><h1>Welcome!</h1></marquee>";
                //return View(model);
            }
            else
            {
                // cache item exists, so too bad...				
                // Label1.Text = "<Marquee><h1><font color=red>ILLEGAL LOGIN ATTEMPT!!!</font></h1></marquee>";
                ModelState.AddModelError("", "ILLEGAL LOGIN ATTEMPT!!!");
                return RedirectToAction("Index", "Home");
                //return;
            }


            // If we got this far, something failed, redisplay form
            //return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();
            HttpCookie _userInfoCookies = Request.Cookies["UserInfo"];
            if (_userInfoCookies != null)
            {
                string UserName = _userInfoCookies["UserName"].ToString();

            }
            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewBag.PasswordLength = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            CarModels cm = new CarModels();
            List<Cars> model = cm.getAllCars();

            //GridView gv = new GridView();
            //gv.DataSource = model;
            //gv.DataBind();
            //Session["Cars"] = gv;

            return View(model);
        }

        public ActionResult Download()
        {
            CarModels cm = new CarModels();
            List<Cars> model = cm.getAllCars();

            GridView gv = new GridView();
            gv.DataSource = model;
            gv.DataBind();
            return new DownloadFileActionResult(gv, "Cars.xls");
            
            //if (Session["Cars"] != null)
            //{
            //    return new DownloadFileActionResult(gv, "Cars.xls");
            //}
            //else
            //{
            //    return new JavaScriptResult();
            //}
        }

    }
}
