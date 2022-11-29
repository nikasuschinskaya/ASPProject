using FourthAapMvcApp.Models;
using FourthAapMvcApp.Models.ViewModels.ActorViewModels;
using FourthAapMvcApp.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FourthAapMvcApp.Controllers
{
    public class ActorController : Controller
    {
        private readonly IRepository<Actor> _actorRepository;
        private readonly IRepository<Film> _filmRepository;

        public ActorController(IRepository<Actor> actorRepository, IRepository<Film> filmRepository)
        {
            _actorRepository = actorRepository;
            _filmRepository = filmRepository;
        }

        public IActionResult Index()
        {
            //_actorRepository.Insert(new Actor { Name = "Sasha", Age = 19});
            //_actorRepository.Insert(new Actor { Name = "Nika", Age = 19 });
            //_actorRepository.Insert(new Actor { Name = "Olya", Age = 19 });
            var actors = _actorRepository.GetAll().Select(actor => new IndexActorViewModel
            {
                Id = actor.Id,
                Name = actor.Name,
                Age = actor.Age,
                FilmName = actor.Film.Name
            });
            return View(actors);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var actor = _actorRepository.GetById(id);

            var vm = new UpdateActorViewModel
            {
                Id = actor.Id,
                Name = actor.Name,
                Age = actor.Age,
                FilmId = actor.FilmId
            };

            ViewData["Films"] = new SelectList(_filmRepository.GetAll(), "Id", "Name");

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(UpdateActorViewModel vm)
        {
            if(!ModelState.IsValid) return View(vm);

            var actor = new Actor
            {
                Id = vm.Id,
                Name = vm.Name,
                Age = vm.Age,
                FilmId = vm.FilmId
            };

            _actorRepository.Update(actor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Films"] = new SelectList(_filmRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateActorViewModel vm)
        {
            if(!ModelState.IsValid) return View(vm);

            var actor = new Actor
            {
                Name = vm.Name,
                Age = vm.Age,
                FilmId = vm.FilmId
            };

            _actorRepository.Insert(actor);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var actor = _actorRepository.GetById(id);
            return View(actor);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            _actorRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var actor = _actorRepository.GetById(id);
            return View(actor);
        }
    }
}
