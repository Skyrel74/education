using Cinema.API.Models;
using Cinema.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cinema.API.Controllers
{
    public class TimeSlotsController : ApiController
    {
        private readonly SqlTicketsService _ticketsService;

        public TimeSlotsController()
        {
            _ticketsService = new SqlTicketsService();
        }
        // GET api/timeslots
        public IHttpActionResult Get()
        {
            return Json(_ticketsService.GetAllTimeSlotCosts());
        }

        // GET api/timeslots/5
        public IHttpActionResult Get(int id)
        {
            var result = _ticketsService.GetTimeSlotCost(id);
            if (result == null) return NotFound();
            return Json(result);
        }

        // PUT api/timeslots/5
        public IHttpActionResult Put(int id, [FromBody]TimeSlotCost value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ticketsService.UpdateTimeSlotCost(value);
            return Ok(value);
        }
    }
}
