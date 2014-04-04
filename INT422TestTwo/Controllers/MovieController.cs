using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestTwo.Controllers
{
    public class MovieController : Controller
    {
        private ViewModels.RepoGenre repoGenre = new ViewModels.RepoGenre();
        private ViewModels.RepoMovie repoMovie = new ViewModels.RepoMovie();
        private ViewModels.RepoDirector repoDirector = new ViewModels.RepoDirector();
        private ViewModels.VM_Error vme = new ViewModels.VM_Error();
        
        // IMP: MUST be static otherwise the Razor view fails when shuttling between Movie/Create POST and GET
        static ViewModels.MovieCreateForHttpGet movieToCreate = new ViewModels.MovieCreateForHttpGet();

        //
        // GET: /Movie/
        public ActionResult Index()
        {
            return View(repoMovie.getListOfMovieBase());
        }

        //
        // GET: /Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // calls our custom error message with custom error object
                var errors = new ViewModels.VM_Error();
                errors.ErrorMessages["ExceptionMessage"] = "No id specified";
                return View("Error", errors);
            }

            return View(repoMovie.getMovieFull(id));
        }

        //
        // GET: /Movie/Create
        public ActionResult Create()
        {
            // initialize select list appropriately before calling view
            movieToCreate.DirectorSelectList = repoDirector.getDirectorSelectList();
            movieToCreate.GenreSelectList = repoGenre.getGenreSelectList();

            return View(movieToCreate);
        }

        //
        // POST: /Movie/Create
        [HttpPost]
        public ActionResult Create(ViewModels.MovieCreateForHttpPost newItem)
        {

           // additional check on DirectorId as ModelState doesn't correctly handle all cases
           if (ModelState.IsValid && newItem.DirectorId != -1)
           {
              var createdMovie = repoMovie.createMovie(newItem);
              if (createdMovie == null)
              {
                return View("Error", vme.GetErrorModel(null, ModelState));
              }
              else
              {
                movieToCreate.Clear(); 
                return RedirectToAction("Details", new { Id = createdMovie.Id });
              }
           }
           else
           {
              if (newItem.DirectorId == -1) ModelState.AddModelError("DirectorSelectList", "Select a Director");
              if (newItem.GenreId == null) ModelState.AddModelError("GenreSelectList", "Select One or More Genres");

              movieToCreate.Title = newItem.Title;
              movieToCreate.TicketPrice = newItem.TicketPrice;

              return View(movieToCreate); 
           }
        }

        //
        // GET: /Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repoMovie.getMovieFull(id));
        }

        //
        // POST: /Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(ViewModels.MovieFull mf, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Movie/Delete/5
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

        //
        // GET: /Movie/CreateFormCollection
        public ActionResult CreateFormCollection()
        {
            ViewBag.DirectorSelectList = repoDirector.getDirectorSelectList();
            ViewBag.GenreSelectList = repoGenre.getGenreSelectList();

            return View();
        }

        // POST: /Movie/CreateFormCollection
        [HttpPost]
        public ActionResult CreateFormCollection(ViewModels.MovieFull mf, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid && collection[3] != "-1")
                {
                    // 0 - _RequestValidator
                    // 1 - Movie Name
                    // 2 - Ticket Price
                    // 3 - Director
                    // 4 - Genres
                    if (collection.Count == 5)
                    {
                        repoMovie.createMovie(mf, collection[3], collection[4]);
                    }
                    else if (collection.Count == 4)
                    {
                        // if only Director selected
                        repoMovie.createMovie(mf, collection[3]);
                    }
                    else
                    {
                        repoMovie.createMovie(mf);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Most probably you haven't selected a director or ticket price");
                    return View("Error", vme.GetErrorModel(collection,ModelState));
                }
            }
            catch (Exception e)
            {
                return View("Error", vme.GetErrorModel(collection,ModelState, e.Message));
            }
        }
    }
}
