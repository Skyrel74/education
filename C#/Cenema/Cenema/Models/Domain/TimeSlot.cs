using Cenema.Models.Tickets;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cenema.Models.Domain
{
    public class TimeSlot : BaseEntity
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Range(1, 1000, ErrorMessage = "Price must be between $1 and $100")]
        public decimal Cost { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [Required]
        public int HallId { get; set; }
        public Hall Hall { get; set; }
        [Required]
        public Format Format { get; set; }
        public TimeSlotSeatRequest[] RequestedSeats { get; set; }
    }
}