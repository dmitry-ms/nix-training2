using Microsoft.EntityFrameworkCore;
using System;
using Task_2.Models;

namespace Task_2.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientCar> ClientCars { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=DMITRIY-LAPTOP; Database=Task2; Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("A7EE20C4-7E96-4041-93FF-AEC8C3545B44"), Name = "asd", EnginePower = 150, EngineType = EngineType.Diesel });
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("4B17A8A4-9B8E-4387-86C6-22B937F0F0A6"), Name = "wbf", EnginePower = 180, EngineType = EngineType.Diesel });
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("09539AB3-C061-4D5E-B8DF-87D004E72C4D"), Name = "tsn", EnginePower = 120, EngineType = EngineType.Diesel });

            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("79E5314A-B408-4777-8130-50ACCDDC6AA4"), Name = "jnf", EnginePower = 210, EngineType = EngineType.Electric });
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("3E075A48-9B6D-4461-8C8E-F79EF462DB2B"), Name = "mdf", EnginePower = 100, EngineType = EngineType.Electric });
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("6C4B2C63-A536-4D28-911C-E933E58DF8C3"), Name = "sms", EnginePower = 110, EngineType = EngineType.Electric });

            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("AE04849A-3CE0-4CF4-B241-AFA4CA03971F"), Name = "krf", EnginePower = 130, EngineType = EngineType.Gas });
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("449233EF-CF17-4E95-BEAC-3FCF7B5125BD"), Name = "xhd", EnginePower = 145, EngineType = EngineType.Gas });
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("3E5069FB-1CB5-4D3B-AFC7-6B8842AF893C"), Name = "tsn", EnginePower = 190, EngineType = EngineType.Gas });

            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("BBCD17CE-30DE-4F0A-9EC0-BA8DBD6C2682"), Name = "rxf", EnginePower = 250, EngineType = EngineType.Petrol });
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("4A7A8A98-1F65-41F7-AD51-3196C33EE5D0"), Name = "bef", EnginePower = 170, EngineType = EngineType.Petrol });
            modelBuilder.Entity<Engine>().HasData(new Engine { Id = new Guid("EA66B050-2F0F-4184-856E-173DE6AAA8AF"), Name = "ksc", EnginePower = 165, EngineType = EngineType.Petrol });


            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = new Guid("197822F7-73AE-4761-9B50-2AB9FA3DC0B1"), Name = "dq200", TransmissionType = TransmissionType.Automatic });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = new Guid("4EE53A66-8D84-4045-9EAE-78A66A5804D1"), Name = "dq250", TransmissionType = TransmissionType.Automatic });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = new Guid("A1A947D9-3EE1-46A4-9E31-EE50F0122409"), Name = "ndg", TransmissionType = TransmissionType.Manual });

            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = new Guid("A8E8B4C9-D5DC-4531-AF00-EF7D0E61E520"), Name = "tdv", TransmissionType = TransmissionType.Manual });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = new Guid("9923A1B7-508B-4028-BFEE-B9A4C802E45B"), Name = "dq300", TransmissionType = TransmissionType.Robotic });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = new Guid("061611AF-A120-4A2E-9478-9F2D68FDD6C1"), Name = "dq350", TransmissionType = TransmissionType.Robotic });

            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = new Guid("D05D4A40-7FE2-4F62-AA4A-4CFA7394BE7C"), Name = "rcdg", TransmissionType = TransmissionType.Variator });
            modelBuilder.Entity<Transmission>().HasData(new Transmission { Id = new Guid("3D26CD66-1BD2-42CD-AF14-ECCC3618BE26"), Name = "jydc", TransmissionType = TransmissionType.Variator });

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("192B609C-193A-4B74-94DB-8417326FB1BD"),
                BrandName = "VW",
                ModelName = "Passat",
                EngineId = new Guid("A7EE20C4-7E96-4041-93FF-AEC8C3545B44"),
                TransmissionId = new Guid("197822F7-73AE-4761-9B50-2AB9FA3DC0B1"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("B0416954-6776-482F-BE10-86211058CE42"),
                BrandName = "Subaru",
                ModelName = "Forester",
                EngineId = new Guid("4B17A8A4-9B8E-4387-86C6-22B937F0F0A6"),
                TransmissionId = new Guid("4EE53A66-8D84-4045-9EAE-78A66A5804D1"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("25AEDEAD-16F6-40AC-9989-BA27488A9E4C"),
                BrandName = "Audi",
                ModelName = "Q5",
                EngineId = new Guid("09539AB3-C061-4D5E-B8DF-87D004E72C4D"),
                TransmissionId = new Guid("A1A947D9-3EE1-46A4-9E31-EE50F0122409"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("D1FE4900-52F9-4305-94EC-77B775C452F4"),
                BrandName = "Honda",
                ModelName = "Civic",
                EngineId = new Guid("79E5314A-B408-4777-8130-50ACCDDC6AA4"),
                TransmissionId = new Guid("A8E8B4C9-D5DC-4531-AF00-EF7D0E61E520"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("D5C40DEA-D425-435E-A2E4-B69EADF5E9CA"),
                BrandName = "Renault",
                ModelName = "Logan",
                EngineId = new Guid("3E075A48-9B6D-4461-8C8E-F79EF462DB2B"),
                TransmissionId = new Guid("9923A1B7-508B-4028-BFEE-B9A4C802E45B"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("D395273F-120A-4779-BD6A-8B2C16C5E3F5"),
                BrandName = "Kia",
                ModelName = "Rio",
                EngineId = new Guid("6C4B2C63-A536-4D28-911C-E933E58DF8C3"),
                TransmissionId = new Guid("061611AF-A120-4A2E-9478-9F2D68FDD6C1"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("563A405A-E63B-421C-BA5A-E081131F57B1"),
                BrandName = "Dodge",
                ModelName = "Ram",
                EngineId = new Guid("AE04849A-3CE0-4CF4-B241-AFA4CA03971F"),
                TransmissionId = new Guid("D05D4A40-7FE2-4F62-AA4A-4CFA7394BE7C"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("72E078BD-CB2B-44E6-83C7-1442098F536B"),
                BrandName = "BMW",
                ModelName = "Series5",
                EngineId = new Guid("449233EF-CF17-4E95-BEAC-3FCF7B5125BD"),
                TransmissionId = new Guid("3D26CD66-1BD2-42CD-AF14-ECCC3618BE26"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("CBA5843F-9132-434B-AD1C-67D2BB7B9527"),
                BrandName = "Citroen",
                ModelName = "Nemo",
                EngineId = new Guid("3E5069FB-1CB5-4D3B-AFC7-6B8842AF893C"),
                TransmissionId = new Guid("4EE53A66-8D84-4045-9EAE-78A66A5804D1"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("EFFEFF1E-DE70-4C17-8DD0-AAD1BEB60CA0"),
                BrandName = "Lada",
                ModelName = "Kalina",
                EngineId = new Guid("BBCD17CE-30DE-4F0A-9EC0-BA8DBD6C2682"),
                TransmissionId = new Guid("9923A1B7-508B-4028-BFEE-B9A4C802E45B"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("B787D15D-7AB0-440C-97FD-058576566AB4"),
                BrandName = "Ford",
                ModelName = "Focus",
                EngineId = new Guid("4A7A8A98-1F65-41F7-AD51-3196C33EE5D0"),
                TransmissionId = new Guid("D05D4A40-7FE2-4F62-AA4A-4CFA7394BE7C"),
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                Id = new Guid("E77990F8-4A55-4BEA-A861-9FE8E40ED65A"),
                BrandName = "Toyota",
                ModelName = "Prius",
                EngineId = new Guid("EA66B050-2F0F-4184-856E-173DE6AAA8AF"),
                TransmissionId = new Guid("3D26CD66-1BD2-42CD-AF14-ECCC3618BE26"),
            });

            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("8264B79C-4904-4DC6-B680-4B697B8BA649"), Name = "Ivan", LastName = "Ivanovich", Gender = Gender.Male });
            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("1DFEB5CA-828F-4BBB-BA26-E2E18CA38425"), Name = "Peter", LastName = "Petrov", Gender = Gender.Male });
            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("492661C5-3581-4DDC-AE38-8A431C615A4D"), Name = "Yuriy", LastName = "Yuriyovich", Gender = Gender.Male });
            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("8948A3D2-E7A7-4519-BAF8-0BEFAF1C80B1"), Name = "Eugen", LastName = "Eugenievich", Gender = Gender.Male });
            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("C9ADB4D2-D5B3-45E7-82C1-79BCD8AFB032"), Name = "Denis", LastName = "Denisovich", Gender = Gender.Male });
            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("F7F229DD-B479-48A8-A6AB-4379DB57D7F4"), Name = "Dmitrii", LastName = "Dmitrivich", Gender = Gender.Male });
            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("28F23C8E-85A4-4DA3-8FA4-E6F954748066"), Name = "Mirina", LastName = "Ivanova", Gender = Gender.Female });
            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("EBD29ECE-D978-4936-812E-338357962351"), Name = "Alina", LastName = "Petrova", Gender = Gender.Female });
            modelBuilder.Entity<Client>().HasData(new Client { Id = new Guid("E29FDAC2-C957-4AAD-B9B6-9EA44EFD5C70"), Name = "Sofia", LastName = "Sofievna", Gender = Gender.Female });



            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("F6C324B7-48D4-405C-91AE-4A4498F17FF4"), ClientId = new Guid("8264B79C-4904-4DC6-B680-4B697B8BA649"), VehicleId = new Guid("192B609C-193A-4B74-94DB-8417326FB1BD"), YearProduction = 2000, Mileage = 500000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("58A95B38-F6BC-4300-8A8F-210DD8F8E708"), ClientId = new Guid("1DFEB5CA-828F-4BBB-BA26-E2E18CA38425"), VehicleId = new Guid("B0416954-6776-482F-BE10-86211058CE42"), YearProduction = 2018, Mileage = 30000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("8D1BF6F4-B11D-4487-A61A-014FA92BEAFF"), ClientId = new Guid("492661C5-3581-4DDC-AE38-8A431C615A4D"), VehicleId = new Guid("25AEDEAD-16F6-40AC-9989-BA27488A9E4C"), YearProduction = 2014, Mileage = 140000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("60E27D5E-5D77-4B13-B85E-648AEE62644C"), ClientId = new Guid("8948A3D2-E7A7-4519-BAF8-0BEFAF1C80B1"), VehicleId = new Guid("D1FE4900-52F9-4305-94EC-77B775C452F4"), YearProduction = 2011, Mileage = 180000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("3D8DC43E-82AA-4090-A232-1C5ABBD199E0"), ClientId = new Guid("C9ADB4D2-D5B3-45E7-82C1-79BCD8AFB032"), VehicleId = new Guid("D5C40DEA-D425-435E-A2E4-B69EADF5E9CA"), YearProduction = 2005, Mileage = 320000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("62DF00AF-D7E6-4355-B06C-24AC0D2F55D4"), ClientId = new Guid("F7F229DD-B479-48A8-A6AB-4379DB57D7F4"), VehicleId = new Guid("D395273F-120A-4779-BD6A-8B2C16C5E3F5"), YearProduction = 2003, Mileage = 447000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("1F0DBB22-AFA9-4D9E-AE32-EAD056709E91"), ClientId = new Guid("28F23C8E-85A4-4DA3-8FA4-E6F954748066"), VehicleId = new Guid("563A405A-E63B-421C-BA5A-E081131F57B1"), YearProduction = 2009, Mileage = 250000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("C82C2016-ED72-44E9-9386-624EE6E11804"), ClientId = new Guid("EBD29ECE-D978-4936-812E-338357962351"), VehicleId = new Guid("72E078BD-CB2B-44E6-83C7-1442098F536B"), YearProduction = 2020, Mileage = 5000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("1DFADA18-5FAC-4EF7-9E9C-5C14E1E9E27D"), ClientId = new Guid("E29FDAC2-C957-4AAD-B9B6-9EA44EFD5C70"), VehicleId = new Guid("CBA5843F-9132-434B-AD1C-67D2BB7B9527"), YearProduction = 2017, Mileage = 70000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("DB90A95A-64EF-4827-A0AD-809343764EB1"), ClientId = new Guid("8264B79C-4904-4DC6-B680-4B697B8BA649"), VehicleId = new Guid("EFFEFF1E-DE70-4C17-8DD0-AAD1BEB60CA0"), YearProduction = 2019, Mileage = 35000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("E9081A54-05EB-4299-A16F-9F718FB3620E"), ClientId = new Guid("1DFEB5CA-828F-4BBB-BA26-E2E18CA38425"), VehicleId = new Guid("B787D15D-7AB0-440C-97FD-058576566AB4"), YearProduction = 2004, Mileage = 540000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("0BB7D2D2-B932-449C-BD53-35CFA941F573"), ClientId = new Guid("492661C5-3581-4DDC-AE38-8A431C615A4D"), VehicleId = new Guid("E77990F8-4A55-4BEA-A861-9FE8E40ED65A"), YearProduction = 2001, Mileage = 610000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("22CEFFB5-52B8-4BF8-9473-3A9695724A25"), ClientId = new Guid("8948A3D2-E7A7-4519-BAF8-0BEFAF1C80B1"), VehicleId = new Guid("192B609C-193A-4B74-94DB-8417326FB1BD"), YearProduction = 2007, Mileage = 340000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("4574AD1E-0739-4DAF-9112-5DB7EED8DF02"), ClientId = new Guid("C9ADB4D2-D5B3-45E7-82C1-79BCD8AFB032"), VehicleId = new Guid("25AEDEAD-16F6-40AC-9989-BA27488A9E4C"), YearProduction = 2016, Mileage = 142000});
            modelBuilder.Entity<ClientCar>().HasData(new ClientCar { Id = new Guid("947B36BF-DE7E-45D4-9BE3-E3F2A46A00DB"), ClientId = new Guid("F7F229DD-B479-48A8-A6AB-4379DB57D7F4"), VehicleId = new Guid("D5C40DEA-D425-435E-A2E4-B69EADF5E9CA"), YearProduction = 2015, Mileage = 210000});







            base.OnModelCreating(modelBuilder);
        }
    }
}
