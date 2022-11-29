using System.ComponentModel.DataAnnotations;

namespace FourthAapMvcApp.Models.ViewModels.FilmViewModels
{
    public class IndexFilmViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Film's name")]
        public string Name { get; set; }


        [Display(Name = "List of actors")]
        public string Actors { get; set; }
    }
}
