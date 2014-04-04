using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace INT422TestTwo.ViewModels
{
    public class MovieBase {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }

    public class MovieFull: MovieBase
    {
        [Required]
        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }
        
       public DirectorFull Director { get; set; }
        
       public List<GenreFull> Genres { get; set; }

        public MovieFull()
        {
            this.Director = new DirectorFull();
            this.Genres = new List<GenreFull>();
        }
    }

    // Http GET method of Movie/Create sends this object to the browser
    public class MovieCreateForHttpGet
    {
        public string Title { get; set; }

        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }

        public SelectList DirectorSelectList { get; set; }

        public SelectList GenreSelectList { get; set; }

        public void Clear()
        {
            Title = string.Empty;
            TicketPrice = 0;
        }
    }

    // Http POST method of Movie/Create recieves this object from the browser
    public class MovieCreateForHttpPost
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }

        [Required(ErrorMessage="Select a Director")]
        public int DirectorId { get; set; }

        [Required(ErrorMessage="Select One or More Genres")]
        public virtual ICollection<int> GenreId { get; set; }
    }
}