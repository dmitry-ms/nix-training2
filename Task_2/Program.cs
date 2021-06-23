using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Task_2.EF;
using Task_2.Models;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new AppDbContext())
            {
                var clients = context.Clients.Include(c => c.ClientCars);
                var clientsCars = context.ClientCars.Include(i => i.Vehicle).ThenInclude(i => i.Engine).Include(i => i.Vehicle).ThenInclude(i => i.Transmission).ToList();

                Console.WriteLine($"{"  Name",-22}{"Car",-17}{"Year Of Production",-25}{"Mileage",-15}{"Type engine",-15}{"Type Transmission"}");
                Console.WriteLine(new string('=', 119));
                foreach (var item in clients)
                {
                    Console.WriteLine($"  {item.Name} {item.LastName}");
                    foreach (var c in item.ClientCars)
                    {
                        Console.WriteLine($"{"",22}{c.Vehicle.BrandName + " " + c.Vehicle.ModelName,-17}" +
                            $"{c.YearProduction,-25}{c.Mileage,-15}{c.Vehicle.Engine.EngineType,-15}{c.Vehicle.Transmission.TransmissionType}");
                    }
                    Console.WriteLine(new string('-', 119));
                }

                Console.WriteLine("\n\n\n");
            };


            Console.Read();
        }
    }
}
