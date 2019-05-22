using System;
using System.Collections.Generic;

namespace GymApp.Models
{
    public partial class CheckIn
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Reservation Reservation { get; set; }
    }
}
