using System.ComponentModel.DataAnnotations;

namespace FourthAapMvcApp.Models.ViewModels.ActorViewModels
{
    public class UpdateActorViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The name must be contain more than 3 letters")]
        [MaxLength(25, ErrorMessage = "The name must be contain 25 letters and less")]
        public string Name { get; set; }

        [Required]
        [Range(0, 130, ErrorMessage = "The age must be from 0 to 130")]
        public int Age { get; set; }

        [Required]
        public int FilmId { get; set; }
    }
}
