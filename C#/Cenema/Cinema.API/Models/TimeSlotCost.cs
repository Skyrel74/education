using System.ComponentModel.DataAnnotations;

namespace Cinema.API.Models
{
    public class TimeSlotCost
    {
        [Required]
        public int? Id { get; set; }
        public decimal Cost { get; set; }
    }
}