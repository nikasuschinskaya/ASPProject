using FourthAapMvcApp.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourthAapMvcApp.Models
{
    public class Actor : NamedEntity
    {
        public int FilmId { get; set; }

        [ForeignKey("FilmId")]
        public virtual Film Film { get; set; }

        public int Age { get; set; }
    }
}
