using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestTwo.Controllers
{
    public class GenreController : Controller
    {
        private ViewModels.RepoGenre repoGenre = new ViewModels.RepoGenre();
        private ViewModels.RepoMovie repoMovie = new ViewModels.RepoMovie();
        private ViewModels.RepoDirector repoDirector = new ViewModels.RepoDirector();

        //
        // GET: /Genre/
        public ActionResult Index()
        {
            return View(repoGenre.getListOfGenreBase());
        }

        //
        // GET: /Genre/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                // calls our custom error message with custom error object
                var errors = new ViewModels.VM_Error();
                errors.ErrorMessages["ExceptionMessage"] = "No id specified";
                return View("Error", errors);
            }

            return View(repoGenre.getGenreFull(id));
        }

        //
        // GET: /Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Genre/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
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
        // POST: /Genre/Edit/5
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
        // GET: /Genre/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Genre/Delete/5
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
