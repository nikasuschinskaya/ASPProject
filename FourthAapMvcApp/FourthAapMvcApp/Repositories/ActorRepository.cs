using FourthAapMvcApp.Data;
using FourthAapMvcApp.Models;
using FourthAapMvcApp.Repositories.Base;

namespace FourthAapMvcApp.Repositories
{
    public class ActorRepository : BaseRepository<Actor>
    {
        public ActorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override void Delete(int id)
        {
            var actors = _context.Actors.FirstOrDefault(actor => actor.Id.Equals(id));
            _context.Actors.Remove(actors);
            _context.SaveChanges();
        }

        public override IEnumerable<Actor> GetAll() => _context.Actors.ToList();

        public override Actor GetById(int id) => _context.Actors.FirstOrDefault(actor => actor.Id.Equals(id));

        public override void Insert(Actor entity)
        {
            _context.Actors.Add(entity);
            _context.SaveChanges();
        }

        public override void Update(Actor entity)
        {
            _context.Actors.Update(entity);
            _context.SaveChanges();
        }
    }
}
