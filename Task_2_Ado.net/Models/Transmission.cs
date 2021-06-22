using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace Task_2.Models
{
    public enum TransmissionType
    {
        Automatic,
        Robotic,
        Variator,
        Manual
    }
    [Table(Name = "Transmission")]
    public class Transmission 
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public TransmissionType TransmissionType { get; set; }

    }
}
