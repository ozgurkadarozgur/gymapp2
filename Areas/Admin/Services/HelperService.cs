using System.Collections.Generic;
using System.Linq;
using GymApp.Models;
using Microsoft.AspNetCore.Http;

namespace GymApp.Areas.Admin.Services
{
    public class HelperService
    {
        private GymAppContext db;

        public HelperService(GymAppContext gymAppContext)
        {
            db = gymAppContext;
        }

        public GymAppContext getAppDbContext()
        {            
            return db;
        }


        public List<UserType> ListUserTypes()
        {
            return db.UserType.ToList();
        }

        public List<User> ListGymOwner()
        {
            return db.User.Where(x => x.UserTypeId == 2).ToList();
        }

    }
}