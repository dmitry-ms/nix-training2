using System;
using System.ComponentModel.DataAnnotations;

namespace Task_2.Models
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
