using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace INT422TestTwo.ViewModels
{
    public class RepoGenre:RepositoryBase
    {
       public GenreFull getGenreFull(int? id)
       {

           var genre = dc.Genres.Include("Movies").FirstOrDefault(i => i.Id == id);
           if (genre == null) return null;

           GenreFull gf = new GenreFull();
           gf.Id = genre.Id;
           gf.Name = genre.Name;

           var rd = new ViewModels.RepoDirector();
           var mfls = new List<MovieFull>();
           foreach (var item in genre.Movies)
           {
               var movie = new MovieFull();
               movie.Id = item.Id;
               movie.Title = item.Title;
               var dir = dc.Movies.Include("Director").FirstOrDefault(m => m.Id == item.Id).Director;
               movie.Director = rd.getDirectorFull(dir.Id);
               mfls.Add(movie);
           }

           gf.Movies = mfls;
           return gf;
       }

       public IEnumerable<GenreBase> getListOfGenreBase()
       {
           var genres = dc.Genres.OrderBy(g => g.Name);
           if (genres == null) return null;

           List<GenreBase> gfls = new List<GenreBase>();
           foreach (var item in genres)
           {
               GenreBase g = new GenreBase();
               g.Id = item.Id;
               g.Name = item.Name;
               gfls.Add(g);
           }

           return gfls;
       }

      public SelectList getGenreSelectList()
      {
         SelectList sl = new SelectList(getListOfGenreBase(), "Id", "Name");
         return sl;
      }
    }
}