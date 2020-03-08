using Cenema.Interfaces;
using Cenema.Models.Tickets;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Cenema.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService)
        {
            _ticketsService = ticketsService;
        }

        public ActionResult GetMovies()
        {
            var allMovies = _ticketsService.GetFullMoviesInfo();
            return View("~/Views/Tickets/MoviesList.cshtml", allMovies);
        }

        public ActionResult GetHallInfo(int timeSlotId) {
            var timeSlot = _ticketsService.GetTimeSlotById(timeSlotId);
            var model = new HallInfo()
            {
                ColumnsCount = 20,
                RowsCount = 12,
                TicketCost = timeSlot.Cost,
                CurrentTimeSlotId = timeSlotId,
                RequestedSeats = timeSlot.RequestedSeats
            };
            return View("HallInfo", model);
        }

        public string ProcessRequest(SeatsProcessRequest request)
        {
            var result = _ticketsService.AddRequestedSeatsToTimeSlot(request);
            return JsonConvert.SerializeObject(new { requestResult = result });
        }
    }
}