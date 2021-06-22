using System.ComponentModel.DataAnnotations;

namespace Task_2.Models
{
    public enum EngineType
    {
        Diesel,
        Petrol,
        Electric,
        Gas
    }
    public class Engine : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public EngineType EngineType { get; set; }
        public int EnginePower { get; set; }
    }
}
