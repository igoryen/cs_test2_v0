using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace INT422TestTwo.ViewModels
{
    public class GenreBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class GenreFull: GenreBase
    {
        virtual public List<MovieFull> Movies { get; set; }

        public GenreFull()
        {
            this.Name = string.Empty;
            this.Movies = new List<MovieFull>();
        }

    }
}