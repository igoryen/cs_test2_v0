using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace INT422TestTwo.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = new List<Genre>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        
        public Director Director { get; set; }
        
        public List<Genre> Genres { get; set; }
    }

    public class Director
    {
        public Director()
        {
            this.Name = string.Empty;
            this.Movies = new List<Movie>();
        }
        public Director(string d)
        {
            this.Name = d;
            this.Movies = new List<Movie>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
    public class Genre
    {
        public Genre()
        {
            this.Name = string.Empty;
            this.Movies = new List<Movie>();
        }
        public Genre(string d)
        {
            this.Name = d;
            this.Movies = new List<Movie>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}