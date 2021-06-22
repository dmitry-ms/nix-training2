using System;
using System.Data.Linq.Mapping;

namespace Task_2.Models
{
    [Table(Name = "ClientCars")]
    public class ClientCar
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column]
        public Guid VehicleId { get; set; }
        [Column]
        public Guid ClientId { get; set; }
        [Column]
        public int YearProduction { get; set; }
        [Column]
        public int Mileage { get; set; }
    }
}
