using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace Task_2.Models
{
    [Table(Name = "Vehicle")]
    public class Vehicle
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid Id { get; set; }
        [Column]
        public string BrandName { get; set; }
        [Column]
        public string ModelName { get; set; }
        [Column]
        public Guid EngineId { get; set; }
        [Column]
        public Guid TransmissionId { get; set; }
    }
}
