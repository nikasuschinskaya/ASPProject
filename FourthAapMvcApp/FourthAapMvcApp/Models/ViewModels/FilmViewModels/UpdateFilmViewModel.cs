using System.ComponentModel.DataAnnotations;

namespace FourthAapMvcApp.Models.ViewModels.FilmViewModels
{
    public class UpdateFilmViewModel
    {
        public int Id { get; set; }


        [Required]
        [MinLength(3, ErrorMessage = "The name must be contain more than 3 letters")]
        [MaxLength(25, ErrorMessage = "The name must be contain 25 letters and less")]
        public string Name { get; set; }
    }
}
