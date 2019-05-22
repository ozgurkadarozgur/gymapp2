using System;
using System.Collections.Generic;
using System.Linq;

namespace GymApp.Models
{
    public partial class Reservation
    {
        private GymAppContext db;

        public Reservation()
        {
            CheckIn = new HashSet<CheckIn>();
        }

        public Reservation(GymAppContext gymAppContext)
        {
            CheckIn = new HashSet<CheckIn>();
            db = gymAppContext;
        }
        
        public bool didCheckIn() {            
            var checkin = db.CheckIn.Where(x => x.ReservationId == this.Id).FirstOrDefault();            
            if (checkin != null)  return true;
            return false;
        }
        
        public bool didCheckIn(int id) {            
            var checkin = db.CheckIn.Where(x => x.ReservationId == id).FirstOrDefault();            
            if (checkin != null)  return true;
            return false;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GymId { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }

        public Gym Gym { get; set; }
        public User User { get; set; }
        public ICollection<CheckIn> CheckIn { get; set; }
    }
}
