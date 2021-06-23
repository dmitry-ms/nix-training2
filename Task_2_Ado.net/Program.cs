using System;
using System.Linq;
using System.Data.Linq;
using Task_2.Models;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace Task_2_Ado.net
{
    class Program
    {
        static string connectionString = "Data Source=DMITRIY-LAPTOP; Database=Task2; Trusted_Connection=True;";
        static void Main(string[] args)
        {

            //Работа с БД через LINQ
            using (DataContext db = new DataContext(connectionString))
            {

                ShowClientAndTheirCars(db);

                var newClientId = AddNewClient(db, "Victor", "Victorovich", Gender.Male);
                var vehicleId = GetVehicle(db, "VW", "Passat");
                var newCarId = AddCarToClient(db, newClientId, vehicleId, 152000, 2017);

                ShowClientAndTheirCars(db);

                ChangeCarMileage(db, newCarId, 173672);

                ShowClientAndTheirCars(db);

                DeleteClient(db, newClientId);

                ShowClientAndTheirCars(db);
            }


            // Json сереализация
            //Serialize(ListClients());

        }


        public static void ShowClientAndTheirCars(DataContext db)
        {
            var res = from c in db.GetTable<Client>()
                      join a in db.GetTable<ClientCar>() on c.Id equals a.ClientId
                      join v in db.GetTable<Vehicle>() on a.VehicleId equals v.Id
                      join e in db.GetTable<Engine>() on v.EngineId equals e.Id
                      join t in db.GetTable<Transmission>() on v.TransmissionId equals t.Id
                      select new
                      {
                          ClientName = c.Name,
                          ClientLastName = c.LastName,
                          ClientGender = c.Gender,
                          ClientCarBrandName = v.BrandName,
                          ClientCarModelName = v.ModelName,
                          ClientCarYearProduction = a.YearProduction,
                          ClientCarMileage = a.Mileage,
                          CarEngineType = e.EngineType,
                          CarTransmissionType = t.TransmissionType
                      };
            var groupRes = from q in res group q by q.ClientName;


            Console.WriteLine($"{"  Name",-22}{"Car",-17}{"Year Of Production",-25}{"Mileage",-15}{"Type engine",-15}{"Type Transmission"}");
            Console.WriteLine(new string('=', 119));
            foreach (var item in groupRes)
            {
                Console.WriteLine($"  {item.Key} {item.FirstOrDefault().ClientLastName}");
                foreach (var c in item)
                {
                    Console.WriteLine($"{"",22}{c.ClientCarBrandName + " " + c.ClientCarModelName,-17}" +
                        $"{c.ClientCarYearProduction,-25}{c.ClientCarMileage,-15}{c.CarEngineType,-15}{c.CarTransmissionType}");
                }
                Console.WriteLine(new string('-', 119));
            }

            Console.WriteLine("\n\n\n");
            Console.ReadKey();
        }


        public static Guid AddNewClient(DataContext db, string name, string lastName, Gender gender)
        {
            Client client = new Client() { Id = Guid.NewGuid(), Name = name, LastName = lastName, Gender = gender };
            db.GetTable<Client>().InsertOnSubmit(client);
            db.SubmitChanges();
            return db.GetTable<Client>().FirstOrDefault<Client>(c => c.Name == client.Name && c.LastName == client.LastName).Id;
        }
        public static Guid GetVehicle(DataContext db, string brandName, string modelName)
        {
            return db.GetTable<Vehicle>().FirstOrDefault<Vehicle>(v => v.BrandName == brandName && v.ModelName == modelName).Id;
        }
        public static Guid AddCarToClient(DataContext db, Guid clientId, Guid vehicleId, int mileage, int yearProduction)
        {
            var id = Guid.NewGuid();
            ClientCar car = new ClientCar() { Id = id, ClientId = clientId, VehicleId = vehicleId, Mileage = mileage, YearProduction = yearProduction };
            db.GetTable<ClientCar>().InsertOnSubmit(car);
            db.SubmitChanges();
            return id;
        }
        public static void DeleteClient(DataContext db, Guid idClient)
        {
            Client client = db.GetTable<Client>().FirstOrDefault(c => c.Id == idClient);
            if (client != null)
            {
                var clientCars = from c in db.GetTable<ClientCar>()
                                 where c.ClientId == client.Id
                                 select c;
                if (clientCars != null)
                {
                    foreach (var item in clientCars)
                    {
                        db.GetTable<ClientCar>().DeleteOnSubmit(item);
                        //db.SubmitChanges();
                    }
                }
                db.GetTable<Client>().DeleteOnSubmit(client);
                db.SubmitChanges();
            }
            else
                throw new Exception("Such client is not exist.");
        }
        public static void ChangeCarMileage(DataContext db, Guid idCar, int newMielage)
        {
            var car = db.GetTable<ClientCar>().FirstOrDefault(c => c.Id == idCar);
            if (car != null)
            {
                car.Mileage = newMielage;
                db.SubmitChanges();
            }
            else
                throw new Exception("Such car is not exist.");
        }


        public static void Serialize<T>(List<T> list)
        {
            Task t = Serializer.SaveData(list);

            Console.WriteLine("Подождите пожалуйста! Идет сохранение данных.\n");

            while (t.IsCompleted != true)
            {
                Console.Write("#");
                Thread.Sleep(100);
            }
            Console.WriteLine("\nДанные успешно сохранены.\n");
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\nПодождите пожалуйста! Идет считывание данных.\n");

            var cls = Serializer.ReadData<List<Client>>();

            while (cls.IsCompleted != true)
            {
                Console.Write("#");
                Thread.Sleep(100);
            }

            Console.WriteLine("\nДанные успешно считаны.\n\n\n");

            Console.WriteLine("Collection of objects:\n");

            foreach (var item in cls.Result)
            {
                Console.Write(item.Name + " ");
                Console.Write(item.LastName + "\n");
            }
        }

        private static List<Client> ListClients()
        {
            using (DataContext db = new DataContext(connectionString))
            {
                return db.GetTable<Client>().ToList();
            }
        }
    }
}
