using System;
using System.ComponentModel.DataAnnotations;

namespace Task_2.Models
{
    public class ClientCar : BaseEntity
    {
        [Required]
        public Vehicle Vehicle { get; set; }
        public Guid VehicleId { get; set; }
        [Required]
        public Client Client { get; set; }
        public Guid ClientId { get; set; }
        public int YearProduction { get; set; }
        public int Mileage { get; set; }
    }
}
