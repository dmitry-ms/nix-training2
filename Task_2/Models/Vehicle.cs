using System;
using System.ComponentModel.DataAnnotations;

namespace Task_2.Models
{
    public class Vehicle : BaseEntity
    {
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public Engine Engine { get; set; }
        public Guid EngineId { get; set; }
        [Required]
        public Transmission Transmission { get; set; }
        public Guid TransmissionId { get; set; }
    }
}
