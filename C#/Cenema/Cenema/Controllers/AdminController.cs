using Cenema.Attributes;
using Cenema.Interfaces;
using Cenema.Models;
using Cenema.Models.Domain;
using Cenema.Services;
using LightInject;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace Cenema.Controllers
{
    public class AdminController : Controller
    {
        [Inject]
        public ITicketsService TicketsService { get; set; }

        [Inject]
        public IImdbService ImdbService { get; set; }

        public ActionResult ExportMovie(string term)
        {
            var movie = ImdbService.GetMovie(term);
            TicketsService.CreateMovie(new Movie()
            {
                Title = movie.Title,
                Description = movie.Plot,
                ImgUrl = movie.Poster,
                Duration = 120
            });
            return Content($"Movie {movie.Title} has been added");
        }

        public ActionResult FindMovieById(int id)
        {
            var movie = TicketsService.GetMovieById(id);
            if (movie == null)
                return Content("Movie with such ID does not exist", "application/json");
            var movieJson = JsonConvert.SerializeObject(movie);
            return Content(movieJson, "application/json");
        }

        public ActionResult FindHallsById(int id)
        {
            var hall = TicketsService.GetHallById(id);
            if (hall == null)
                return Content("Hall with such ID does not exist", "application/json");
            var hallJson = JsonConvert.SerializeObject(hall);
            return Content(hallJson, "application/json");
        }

        public ActionResult FindTimeSlotById(int id)
        {
            var timeSlot = TicketsService.GetTimeSlotById(id);
            if (timeSlot == null)
                return Content("TimeSlot with such ID does not exist", "application/json");
            var timeSlotJson = JsonConvert.SerializeObject(timeSlot);
            return Content(timeSlotJson, "application/json");
        }

        [HttpGet]
        public ActionResult MoviesList()
        {
            var movies = TicketsService.GetAllMovies();
            return View("MoviesList", movies);
        }

        [HttpGet]
        public ActionResult EditMovie(int movieId)
        {
            var movie = TicketsService.GetMovieById(movieId);
            return View("EditMovie", movie);
        }

        [HttpPost]
        public ActionResult EditMovie(Movie model)
        {
            if(ModelState.IsValid)
            {
                var updateResult = TicketsService.UpdateMovie(model);
                if(updateResult)
                    return RedirectToAction("MoviesList");
                return Content("Update failed.");
            }
            return View("EditMovie", model);
        }

        [HttpGet]
        public ActionResult HallsList()
        {
            var halls = TicketsService.GetAllHalls();
            return View("HallsList", halls);
        }

        [HttpGet]
        public ActionResult EditHall(int hallId)
        {
            var hall = TicketsService.GetHallById(hallId);
            return View("EditHall", hall);
        }

        [HttpPost]
        public ActionResult EditHall(Hall model)
        {
            if (ModelState.IsValid)
            {
                var updateResult = TicketsService.UpdateHall(model);
                if (updateResult)
                    return RedirectToAction("HallsList");
                return Content("Update failed.");
            }
            return View("EditHall", model);
        }

        private TimeslotGridRow[] ProccessTimeslots(TimeSlot[] timeslots)
        {
            if (!timeslots.Any())
                return new TimeslotGridRow[0];
            var movies = TicketsService.GetAllMovies();
            var halls = TicketsService.GetAllHalls();

            return timeslots.Select(timeslot => new TimeslotGridRow()
            {
                StartTime = timeslot.StartTime,
                Coast = timeslot.Cost,
                Format = timeslot.Format,
                Id = timeslot.Id,
                Hall = timeslot.Hall,
                Movie = timeslot.Movie,
            }).ToArray();
        }

        [HttpGet]
        public ActionResult TimeSlotsList()
        {
            return View("TimeSlotsList", ProccessTimeslots(TicketsService.GetAllTimeSlots()));
        }

        [HttpGet]
        public ActionResult GetMovieTimeSlotsList(int movieId)
        {
            return View("TimeSlotsList", ProccessTimeslots(TicketsService.GetTimeSlotsByMovieId(movieId)));
        }

        [HttpGet]
        [PopulateHallsList, PopulateMoviesList]
        public ActionResult EditTimeSlot(int timeSlotId)
        {
            var timeSlot = TicketsService.GetTimeSlotById(timeSlotId);
            return View("EditTimeSlot", timeSlot);
        }

        [HttpPost]
        public ActionResult EditTimeSlot(TimeSlot model)
        {
            if (ModelState.IsValid)
            {
                var updateResult = TicketsService.UpdateTimeSlot(model);
                if (updateResult)
                    return RedirectToAction("TimeSlotsList");
                return Content("Update failed.");
            }
            return View("EditTimeSlot", model);
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                var result = TicketsService.CreateMovie(newMovie);
                if (result)
                {
                    return RedirectToAction("MoviesList");
                }
                return Content("Update failed.");
            }
            return View(newMovie);
        }

        [HttpGet]
        [PopulateHallsList, PopulateMoviesList]
        public ActionResult AddTimeSlot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTimeSlot(TimeSlot newTimeSlot)
        {
            if (ModelState.IsValid)
            {
                var result = TicketsService.CreateTimeSlot(newTimeSlot);
                if (result)
                {
                    return RedirectToAction("TimeSlotsList");
                }
                return Content("Update failed.");
            }
            return View(newTimeSlot);
        }

        [HttpGet]
        public ActionResult AddHall()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHall(Hall newHall)
        {
            if (ModelState.IsValid)
            {
                var result = TicketsService.CreateHall(newHall);
                if (result)
                {
                    return RedirectToAction("HallsList");
                }
                return Content("Update failed.");
            }
            return View(newHall);
        }

        [HttpGet]
        public ActionResult RemoveMovie(int movieId)
        {
            if (TicketsService.RemoveMovie(movieId))
                return RedirectToAction("MoviesList");
            return Content("Delete failed.");
        }

        [HttpGet]
        public ActionResult RemoveHall(int hallId)
        {
            if (TicketsService.RemoveHall(hallId))
                return RedirectToAction("HallsList");
            return Content("Delete failed.");
        }

        [HttpGet]
        public ActionResult RemoveTimeSlot(int timeSlotId)
        {
            if(TicketsService.RemoveTimeSlot(timeSlotId))
                return RedirectToAction("TimeSlotsList");
            return Content("Delete failed.");
        }
    }
}