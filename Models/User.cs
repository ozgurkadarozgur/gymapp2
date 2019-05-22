using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GymApp.Areas.Home.ViewModels;

namespace GymApp.Models
{
    public class User
    {
        public User()
        {
            Gym = new HashSet<Gym>();
            Reservation = new HashSet<Reservation>();
        }

        public User(RegisterViewModel registerViewModel) {
            FirstName = registerViewModel.FirstName;
            LastName = registerViewModel.LastName;
            Password = registerViewModel.Password;
            Email = registerViewModel.Email;
            Phone = registerViewModel.Phone;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public int Id { get; set; }            
        public int UserTypeId { get; set; }        
        public string Username { get; set; }    
        public string Password { get; set; }    
        public string FirstName { get; set; }        
        public string LastName { get; set; }    
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TCNumber { get; set; }
        public byte IsConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public UserType UserType { get; set; }
        public ICollection<Gym> Gym { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
    }
}
