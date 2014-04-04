using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestTwo.Controllers
{
    public class DirectorController : Controller
    {

        private ViewModels.RepoDirector repo = new ViewModels.RepoDirector();
        //
        // GET: /Director/
        public ActionResult Index()
        {
            return View(repo.getListOfDirectorBase());
        }

        //
        // GET: /Director/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // calls our custom error message with custom error object
                var errors = new ViewModels.VM_Error();
                errors.ErrorMessages["ExceptionMessage"] = "No id specified";
                return View("Error", errors);
            }

            return View(repo.getDirectorFull(id));
        }

        //
        // GET: /Director/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Director/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Director/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Director/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Director/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Director/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
	  }
}