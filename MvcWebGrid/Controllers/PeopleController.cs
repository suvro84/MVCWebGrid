using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebGridDemo.Models;
using MvcWebGrid.Models;

namespace MvcWebGrid.Controllers
{
    public class PeopleController : Controller
    {
        private readonly employeeEntities _db = new employeeEntities();
        public ActionResult Index()
        {
            var data = new ModelServices().GetPeople();
            return View(data);
        }

        public ActionResult JqueryValidation()
        {
            
            return View();
        }
        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            //ViewBag.Message = "Welcome Blog Post Page";
            //var v = ViewData.Model = _db.People.ToList();

            //return View(_db.People);
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //_db.People.AddObject(person);
                    //_db.SaveChanges();

                    return RedirectToAction("index", "People");


                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
