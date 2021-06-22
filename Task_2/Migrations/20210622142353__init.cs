using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task_2.Migrations
{
    public partial class _init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineType = table.Column<int>(type: "int", nullable: false),
                    EnginePower = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransmissionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Transmission_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientCars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearProduction = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCars_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCars_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Gender", "LastName", "Name" },
                values: new object[,]
                {
                    { new Guid("8264b79c-4904-4dc6-b680-4b697b8ba649"), 0, "Ivanovich", "Ivan" },
                    { new Guid("1dfeb5ca-828f-4bbb-ba26-e2e18ca38425"), 0, "Petrov", "Peter" },
                    { new Guid("492661c5-3581-4ddc-ae38-8a431c615a4d"), 0, "Yuriyovich", "Yuriy" },
                    { new Guid("8948a3d2-e7a7-4519-baf8-0befaf1c80b1"), 0, "Eugenievich", "Eugen" },
                    { new Guid("c9adb4d2-d5b3-45e7-82c1-79bcd8afb032"), 0, "Denisovich", "Denis" },
                    { new Guid("f7f229dd-b479-48a8-a6ab-4379db57d7f4"), 0, "Dmitrivich", "Dmitrii" },
                    { new Guid("28f23c8e-85a4-4da3-8fa4-e6f954748066"), 1, "Ivanova", "Mirina" },
                    { new Guid("ebd29ece-d978-4936-812e-338357962351"), 1, "Petrova", "Alina" },
                    { new Guid("e29fdac2-c957-4aad-b9b6-9ea44efd5c70"), 1, "Sofievna", "Sofia" }
                });

            migrationBuilder.InsertData(
                table: "Engine",
                columns: new[] { "Id", "EnginePower", "EngineType", "Name" },
                values: new object[,]
                {
                    { new Guid("ea66b050-2f0f-4184-856e-173de6aaa8af"), 165, 1, "ksc" },
                    { new Guid("4a7a8a98-1f65-41f7-ad51-3196c33ee5d0"), 170, 1, "bef" },
                    { new Guid("bbcd17ce-30de-4f0a-9ec0-ba8dbd6c2682"), 250, 1, "rxf" },
                    { new Guid("3e5069fb-1cb5-4d3b-afc7-6b8842af893c"), 190, 3, "tsn" },
                    { new Guid("449233ef-cf17-4e95-beac-3fcf7b5125bd"), 145, 3, "xhd" },
                    { new Guid("ae04849a-3ce0-4cf4-b241-afa4ca03971f"), 130, 3, "krf" },
                    { new Guid("6c4b2c63-a536-4d28-911c-e933e58df8c3"), 110, 2, "sms" },
                    { new Guid("3e075a48-9b6d-4461-8c8e-f79ef462db2b"), 100, 2, "mdf" },
                    { new Guid("79e5314a-b408-4777-8130-50accddc6aa4"), 210, 2, "jnf" },
                    { new Guid("09539ab3-c061-4d5e-b8df-87d004e72c4d"), 120, 0, "tsn" },
                    { new Guid("4b17a8a4-9b8e-4387-86c6-22b937f0f0a6"), 180, 0, "wbf" },
                    { new Guid("a7ee20c4-7e96-4041-93ff-aec8c3545b44"), 150, 0, "asd" }
                });

            migrationBuilder.InsertData(
                table: "Transmission",
                columns: new[] { "Id", "Name", "TransmissionType" },
                values: new object[,]
                {
                    { new Guid("197822f7-73ae-4761-9b50-2ab9fa3dc0b1"), "dq200", 0 },
                    { new Guid("4ee53a66-8d84-4045-9eae-78a66a5804d1"), "dq250", 0 },
                    { new Guid("a1a947d9-3ee1-46a4-9e31-ee50f0122409"), "ndg", 3 },
                    { new Guid("a8e8b4c9-d5dc-4531-af00-ef7d0e61e520"), "tdv", 3 },
                    { new Guid("9923a1b7-508b-4028-bfee-b9a4c802e45b"), "dq300", 1 },
                    { new Guid("061611af-a120-4a2e-9478-9f2d68fdd6c1"), "dq350", 1 },
                    { new Guid("d05d4a40-7fe2-4f62-aa4a-4cfa7394be7c"), "rcdg", 2 },
                    { new Guid("3d26cd66-1bd2-42cd-af14-eccc3618be26"), "jydc", 2 }
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "BrandName", "EngineId", "ModelName", "TransmissionId" },
                values: new object[,]
                {
                    { new Guid("192b609c-193a-4b74-94db-8417326fb1bd"), "VW", new Guid("a7ee20c4-7e96-4041-93ff-aec8c3545b44"), "Passat", new Guid("197822f7-73ae-4761-9b50-2ab9fa3dc0b1") },
                    { new Guid("b0416954-6776-482f-be10-86211058ce42"), "Subaru", new Guid("4b17a8a4-9b8e-4387-86c6-22b937f0f0a6"), "Forester", new Guid("4ee53a66-8d84-4045-9eae-78a66a5804d1") },
                    { new Guid("cba5843f-9132-434b-ad1c-67d2bb7b9527"), "Citroen", new Guid("3e5069fb-1cb5-4d3b-afc7-6b8842af893c"), "Nemo", new Guid("4ee53a66-8d84-4045-9eae-78a66a5804d1") },
                    { new Guid("25aedead-16f6-40ac-9989-ba27488a9e4c"), "Audi", new Guid("09539ab3-c061-4d5e-b8df-87d004e72c4d"), "Q5", new Guid("a1a947d9-3ee1-46a4-9e31-ee50f0122409") },
                    { new Guid("d1fe4900-52f9-4305-94ec-77b775c452f4"), "Honda", new Guid("79e5314a-b408-4777-8130-50accddc6aa4"), "Civic", new Guid("a8e8b4c9-d5dc-4531-af00-ef7d0e61e520") },
                    { new Guid("d5c40dea-d425-435e-a2e4-b69eadf5e9ca"), "Renault", new Guid("3e075a48-9b6d-4461-8c8e-f79ef462db2b"), "Logan", new Guid("9923a1b7-508b-4028-bfee-b9a4c802e45b") },
                    { new Guid("effeff1e-de70-4c17-8dd0-aad1beb60ca0"), "Lada", new Guid("bbcd17ce-30de-4f0a-9ec0-ba8dbd6c2682"), "Kalina", new Guid("9923a1b7-508b-4028-bfee-b9a4c802e45b") },
                    { new Guid("d395273f-120a-4779-bd6a-8b2c16c5e3f5"), "Kia", new Guid("6c4b2c63-a536-4d28-911c-e933e58df8c3"), "Rio", new Guid("061611af-a120-4a2e-9478-9f2d68fdd6c1") },
                    { new Guid("563a405a-e63b-421c-ba5a-e081131f57b1"), "Dodge", new Guid("ae04849a-3ce0-4cf4-b241-afa4ca03971f"), "Ram", new Guid("d05d4a40-7fe2-4f62-aa4a-4cfa7394be7c") },
                    { new Guid("b787d15d-7ab0-440c-97fd-058576566ab4"), "Ford", new Guid("4a7a8a98-1f65-41f7-ad51-3196c33ee5d0"), "Focus", new Guid("d05d4a40-7fe2-4f62-aa4a-4cfa7394be7c") },
                    { new Guid("72e078bd-cb2b-44e6-83c7-1442098f536b"), "BMW", new Guid("449233ef-cf17-4e95-beac-3fcf7b5125bd"), "Series5", new Guid("3d26cd66-1bd2-42cd-af14-eccc3618be26") },
                    { new Guid("e77990f8-4a55-4bea-a861-9fe8e40ed65a"), "Toyota", new Guid("ea66b050-2f0f-4184-856e-173de6aaa8af"), "Prius", new Guid("3d26cd66-1bd2-42cd-af14-eccc3618be26") }
                });

            migrationBuilder.InsertData(
                table: "ClientCars",
                columns: new[] { "Id", "ClientId", "Mileage", "VehicleId", "YearProduction" },
                values: new object[,]
                {
                    { new Guid("f6c324b7-48d4-405c-91ae-4a4498f17ff4"), new Guid("8264b79c-4904-4dc6-b680-4b697b8ba649"), 500000, new Guid("192b609c-193a-4b74-94db-8417326fb1bd"), 2000 },
                    { new Guid("22ceffb5-52b8-4bf8-9473-3a9695724a25"), new Guid("8948a3d2-e7a7-4519-baf8-0befaf1c80b1"), 340000, new Guid("192b609c-193a-4b74-94db-8417326fb1bd"), 2007 },
                    { new Guid("58a95b38-f6bc-4300-8a8f-210dd8f8e708"), new Guid("1dfeb5ca-828f-4bbb-ba26-e2e18ca38425"), 30000, new Guid("b0416954-6776-482f-be10-86211058ce42"), 2018 },
                    { new Guid("1dfada18-5fac-4ef7-9e9c-5c14e1e9e27d"), new Guid("e29fdac2-c957-4aad-b9b6-9ea44efd5c70"), 70000, new Guid("cba5843f-9132-434b-ad1c-67d2bb7b9527"), 2017 },
                    { new Guid("8d1bf6f4-b11d-4487-a61a-014fa92beaff"), new Guid("492661c5-3581-4ddc-ae38-8a431c615a4d"), 140000, new Guid("25aedead-16f6-40ac-9989-ba27488a9e4c"), 2014 },
                    { new Guid("4574ad1e-0739-4daf-9112-5db7eed8df02"), new Guid("c9adb4d2-d5b3-45e7-82c1-79bcd8afb032"), 142000, new Guid("25aedead-16f6-40ac-9989-ba27488a9e4c"), 2016 },
                    { new Guid("60e27d5e-5d77-4b13-b85e-648aee62644c"), new Guid("8948a3d2-e7a7-4519-baf8-0befaf1c80b1"), 180000, new Guid("d1fe4900-52f9-4305-94ec-77b775c452f4"), 2011 },
                    { new Guid("3d8dc43e-82aa-4090-a232-1c5abbd199e0"), new Guid("c9adb4d2-d5b3-45e7-82c1-79bcd8afb032"), 320000, new Guid("d5c40dea-d425-435e-a2e4-b69eadf5e9ca"), 2005 },
                    { new Guid("947b36bf-de7e-45d4-9be3-e3f2a46a00db"), new Guid("f7f229dd-b479-48a8-a6ab-4379db57d7f4"), 210000, new Guid("d5c40dea-d425-435e-a2e4-b69eadf5e9ca"), 2015 },
                    { new Guid("db90a95a-64ef-4827-a0ad-809343764eb1"), new Guid("8264b79c-4904-4dc6-b680-4b697b8ba649"), 35000, new Guid("effeff1e-de70-4c17-8dd0-aad1beb60ca0"), 2019 },
                    { new Guid("62df00af-d7e6-4355-b06c-24ac0d2f55d4"), new Guid("f7f229dd-b479-48a8-a6ab-4379db57d7f4"), 447000, new Guid("d395273f-120a-4779-bd6a-8b2c16c5e3f5"), 2003 },
                    { new Guid("1f0dbb22-afa9-4d9e-ae32-ead056709e91"), new Guid("28f23c8e-85a4-4da3-8fa4-e6f954748066"), 250000, new Guid("563a405a-e63b-421c-ba5a-e081131f57b1"), 2009 },
                    { new Guid("e9081a54-05eb-4299-a16f-9f718fb3620e"), new Guid("1dfeb5ca-828f-4bbb-ba26-e2e18ca38425"), 540000, new Guid("b787d15d-7ab0-440c-97fd-058576566ab4"), 2004 },
                    { new Guid("c82c2016-ed72-44e9-9386-624ee6e11804"), new Guid("ebd29ece-d978-4936-812e-338357962351"), 5000, new Guid("72e078bd-cb2b-44e6-83c7-1442098f536b"), 2020 },
                    { new Guid("0bb7d2d2-b932-449c-bd53-35cfa941f573"), new Guid("492661c5-3581-4ddc-ae38-8a431c615a4d"), 610000, new Guid("e77990f8-4a55-4bea-a861-9fe8e40ed65a"), 2001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCars_ClientId",
                table: "ClientCars",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCars_VehicleId",
                table: "ClientCars",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_EngineId",
                table: "Vehicle",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TransmissionId",
                table: "Vehicle",
                column: "TransmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "Transmission");
        }
    }
}
