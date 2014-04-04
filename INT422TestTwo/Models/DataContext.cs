using System.Data.Entity;

namespace INT422TestTwo.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContext") { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.MovieBase> MovieBases { get; set; }

        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.MovieFull> MovieFulls { get; set; }

        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.DirectorBase> DirectorBases { get; set; }

        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.GenreBase> GenreBases { get; set; }

        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.DirectorFull> DirectorFulls { get; set; }

        public System.Data.Entity.DbSet<INT422TestTwo.ViewModels.GenreFull> GenreFulls { get; set; }

    }
}