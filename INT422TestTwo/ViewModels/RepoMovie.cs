using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace INT422TestTwo.ViewModels
{
    public class RepoMovie: RepositoryBase
    {
        public MovieFull getMovieFull(int? id)
        {
            if (id == null) return null;

            // can use FirstOrDefault but SingleOrDefault is stricter - throwing exception if it fails
            var movie = dc.Movies.Include("Genres").Include("Director").SingleOrDefault(n => n.Id == id);
            if (movie == null) return null;

            MovieFull mf = new MovieFull();
            mf.Id = movie.Id;
            mf.Title = movie.Title;
            mf.TicketPrice = movie.TicketPrice;
            mf.Director = rd.getDirectorFull(movie.Director.Id);

            List<GenreFull> gfls = new List<GenreFull>();
            foreach (var item in movie.Genres)
            {
                gfls.Add(rg.getGenreFull(item.Id));
            }
            mf.Genres = gfls;

            return mf;
        }

        public IEnumerable<ViewModels.MovieBase> getListOfMovieBase()
        {
            var all_movies = dc.Movies.OrderBy(m => m.Title);

            List<MovieBase> mbls = new List<MovieBase>();
            foreach (var item in all_movies)
            {
                MovieBase mf = new MovieBase();
                mf.Id = item.Id;
                mf.Title = item.Title;
                mbls.Add(mf);
            }

            return mbls;
        }

        public MovieFull createMovie(MovieCreateForHttpPost newItem)
        {
            var d = dc.Directors.Find(newItem.DirectorId);
            Models.Movie mov = new Models.Movie();

            mov.Title = newItem.Title;
            mov.TicketPrice = newItem.TicketPrice;

            mov.Director = d;

            foreach (var item in newItem.GenreId)
            {
                var g = dc.Genres.Find(item);
                mov.Genres.Add(g);
            }

            dc.Movies.Add(mov);
            dc.SaveChanges();

            return getMovieFull(mov.Id);
        }

        public MovieFull createMovie(MovieFull mf, string selDirector="", string selGenres = "")
        {
            Models.Movie m = new Models.Movie();

            m.Title = mf.Title;
            m.TicketPrice = mf.TicketPrice;

            if (selDirector != "")
            {
                int directorInt32 = Convert.ToInt32(selDirector);
                m.Director = dc.Directors.FirstOrDefault(n => n.Id == directorInt32);
            }

            if (selGenres != "")
            {
                foreach (var item in selGenres.Split(','))
                {
                      var itemInt32 = Convert.ToInt32(item);
                      var g = dc.Genres.FirstOrDefault(gg => gg.Id == itemInt32);
                      m.Genres.Add(g);
                }
            }
           
            dc.Movies.Add(m);
            dc.SaveChanges();

            return getMovieFull(m.Id);
        }

        public SelectList getMoviesSelectList()
        {
            SelectList sl = new SelectList(getListOfMovieBase(), "Id", "Title");
            return sl;
        }
        public RepoMovie(){
            rd = new RepoDirector();
            rg = new RepoGenre();
        }

        // Implementation details
        RepoDirector rd;
        RepoGenre rg;
    }
}

/* Unused but working code. I've left this in, as an example of how to solve
 * some situations I encountered before but that changed over time and I no longer
 * need these functions.
 */ 

 /* public MovieFull createMovie(string title, string price, string d, string gids)
        {
            Models.Movie m = new Models.Movie();
            
            m.Title = title;
            m.TicketPrice = Convert.ToDecimal(price);

            foreach (var item in gids.Split(','))
            {
                var intItem = Convert.ToInt32(item);
                var g =dc.Genres.FirstOrDefault(gg => gg.Id == intItem);
                m.Genres.Add(g);
            }

            int did = Convert.ToInt32(d);
            m.Director = dc.Directors.FirstOrDefault(n => n.Id == did);

            dc.Movies.Add(m);
            dc.SaveChanges();

            return getMovieFull(m.Id);
        }
 
        public MovieBase getMovieBase(int? id)
        {
            if (id == null) return null;

            var movie = dc.Movies.SingleOrDefault(n => n.Id == id);
            if (movie == null) return null;

            MovieBase mb = new MovieBase();
            mb.Id = movie.Id;
            mb.Title = movie.Title;

            return mb;
        }
*/