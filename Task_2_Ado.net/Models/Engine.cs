using System;
using System.Data.Linq.Mapping;

namespace Task_2.Models
{
    public enum EngineType
    {
        Diesel,
        Petrol,
        Electric,
        Gas
    }
    [Table(Name = "Engine")]
    public class Engine
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public EngineType EngineType { get; set; }
        [Column]
        public int EnginePower { get; set; }
    }
}
