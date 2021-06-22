using System;
using System.Data.Linq.Mapping;

namespace Task_2.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    [Table(Name = "Clients")]
    public class Client
    {
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [Column]
        public string Name { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column]
        public Gender Gender { get; set; }
    }
}
