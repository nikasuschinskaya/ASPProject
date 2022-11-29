using System.ComponentModel.DataAnnotations;

namespace FourthAapMvcApp.Models.ViewModels.ActorViewModels
{
    public class IndexActorViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Actor's Name")]
        public string Name { get; set; }


        [Display(Name = "Actor's Age")]
        public int Age { get; set; }


        [Display(Name = "Film Name")]
        public string FilmName { get; set; }
    }
}
