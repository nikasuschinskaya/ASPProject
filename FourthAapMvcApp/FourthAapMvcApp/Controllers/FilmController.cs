using FourthAapMvcApp.Models;
using FourthAapMvcApp.Models.ViewModels.FilmViewModels;
using FourthAapMvcApp.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace FourthAapMvcApp.Controllers
{
    public class FilmController : Controller
    {
        private readonly IRepository<Film> _filmRepository;

        public FilmController(IRepository<Film> filmRepository) => _filmRepository = filmRepository;

        public IActionResult Index()
        {
            var films = _filmRepository.GetAll().Select(film => new IndexFilmViewModel
            {
                Id = film.Id,
                Name = film.Name,
                Actors = String.Join(",", film.Actors?.Select(actor => actor.Name))
            });
            return View(films);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var film = _filmRepository.GetById(id);

            var vm = new UpdateFilmViewModel
            {
                Id = film.Id,
                Name = film.Name,
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(UpdateFilmViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var film = new Film
            {
                Id = vm.Id,
                Name = vm.Name
            };

            _filmRepository.Update(film);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateFilmViewModel vm)
        {
            if(!ModelState.IsValid) return View(vm);

            var film = new Film
            {
                Name = vm.Name
            };

            _filmRepository.Insert(film);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var film = _filmRepository.GetById(id);
            return View(film);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            _filmRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) => View(_filmRepository.GetById(id));
    }
}
