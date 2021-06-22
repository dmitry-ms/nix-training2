using System.ComponentModel.DataAnnotations;

namespace Task_2.Models
{
    public enum TransmissionType
    {
        Automatic,
        Robotic,
        Variator,
        Manual
    }

    public class Transmission : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public TransmissionType TransmissionType { get; set; }
    }
}
