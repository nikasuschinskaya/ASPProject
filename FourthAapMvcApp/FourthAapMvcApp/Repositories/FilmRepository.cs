using FourthAapMvcApp.Data;
using FourthAapMvcApp.Models;
using FourthAapMvcApp.Repositories.Base;

namespace FourthAapMvcApp.Repositories
{
    public class FilmRepository : BaseRepository<Film>
    {
        public FilmRepository(ApplicationDbContext context) : base(context) { }

        public override void Delete(int id)
        {
            var films = _context.Films.FirstOrDefault(film => film.Id.Equals(id));
            _context.Films.Remove(films);
            _context.SaveChanges();
        }

        public override IEnumerable<Film> GetAll() => _context.Films.ToList();

        public override Film GetById(int id) => _context.Films.FirstOrDefault(film => film.Id.Equals(id));

        public override void Insert(Film entity)
        {
            _context.Films.Add(entity);
            _context.SaveChanges();
        }

        public override void Update(Film entity)
        {
            _context.Films.Update(entity);
            _context.SaveChanges();
        }
    }
}
