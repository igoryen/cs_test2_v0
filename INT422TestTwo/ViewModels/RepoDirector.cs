using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace INT422TestTwo.ViewModels
{
    public class RepoDirector : RepositoryBase
    {
        public DirectorFull getDirectorFull(int? id)
        {
            var director = dc.Directors.Include("Movies").FirstOrDefault(i => i.Id == id);
            if (director == null) return null;

            DirectorFull df = new DirectorFull();
            df.Id = director.Id;
            df.Name = director.Name;
            List<MovieBase> mv = new List<MovieBase>();
            foreach (var item in director.Movies)
            {
                MovieBase mb = new MovieBase();
                mb.Id = item.Id;
                mb.Title = item.Title;
                mv.Add(mb);
            }
            df.Movies = mv;

            return df;
        }

        public IEnumerable<DirectorBase> getListOfDirectorBase()
        {
            var directors = dc.Directors.OrderBy(d => d.Name);
            if (directors == null) return null;

            List<DirectorBase> dls = new List<DirectorBase>();
            foreach (var item in directors)
            {
                DirectorBase db = new DirectorBase();
                db.Id = item.Id;
                db.Name = item.Name;
                dls.Add(db);
            }
            return dls.ToList();
        }

        // unused at the moment but can be potentially useful as it shows how 
        // to convert from Models.Director to ViewModels.DirectorFull
        public DirectorFull toDirectorFull(Models.Director d)
        {
            if (d == null) return null;

            DirectorFull df = new DirectorFull();
            df.Id = d.Id;
            df.Name = d.Name;

            df.Movies = new List<MovieBase>();
            foreach (var item in d.Movies)
            {
                MovieBase m = new MovieBase();
                m.Id = item.Id;
                m.Title = item.Title;
                df.Movies.Add(m);
            }

            return df;
        }

        public SelectList getDirectorSelectList()
        {
            var dbls = new List<DirectorBase>();

            // first Director in our select list is BOGUS! ;)
            dbls.Add(new DirectorBase
            {
                Name = "Select a Director",
                Id = -1
            });

            foreach (var item in getListOfDirectorBase())
            {
                dbls.Add(item);
            }

            SelectList sl = new SelectList(dbls.ToList(), "Id", "Name");
            return sl;
        }

    }
}