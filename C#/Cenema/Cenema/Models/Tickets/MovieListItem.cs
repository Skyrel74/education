﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cenema.Models.Domain.Tickets
{
    public class MovieListItem
    {
        public Movie Movie { get; set; }

        public TimeSlotTag[] AvailableTimeSlots { get; set; }
    }
}