using FourthAapMvcApp.Entities;

namespace FourthAapMvcApp.Models
{
    public class Film : NamedEntity
    {
        public virtual List<Actor> Actors { get; set; } = new List<Actor>();
    }
}
