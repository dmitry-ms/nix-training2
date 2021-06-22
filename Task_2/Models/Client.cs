using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task_2.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Client : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        //public DateTime BirthDay { get; set; }
        //public string Email { get; set; } 
        //[Required]
        //public string Phone { get; set; }  
        //public string Address { get; set; }
        public List<ClientCar> ClientCars { get; set; }
    }
}
