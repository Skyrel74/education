using Cenema.Models.Domain;
using System;

namespace Cenema.Models
{
    public class TimeslotGridRow
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Coast { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public Format Format { get; set; }
    }
}