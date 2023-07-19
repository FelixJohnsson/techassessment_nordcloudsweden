using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book.Api.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false },
                    { new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false },
                    { new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"), false }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "HotelId", "IsDeleted", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("002f3b87-d57a-43d9-ba31-6531ebc6dbe3"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "101", 0 },
                    { new Guid("12473933-3a14-4858-954f-7fd0e8402c84"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "404", 2 },
                    { new Guid("12cdb371-f079-4a86-9686-f13d8215a571"), new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"), false, "F", 1 },
                    { new Guid("16c37356-eb57-4c0e-a767-396d73bc7a49"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "403", 2 },
                    { new Guid("1c591e3a-34af-4a46-84bb-3a39821dc930"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "3002", 1 },
                    { new Guid("21df563d-7157-4707-80f0-a725794bf76b"), new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"), false, "B", 2 },
                    { new Guid("225d6dcc-546d-441c-b695-393b641f1bea"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "2006", 1 },
                    { new Guid("229b6d7d-9482-447f-9501-546180da8a7f"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "304", 1 },
                    { new Guid("30e4b36f-a380-407b-92d9-ad5fb6a68a27"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "1003", 0 },
                    { new Guid("32a9d0c1-d129-425e-bcb9-54df52d042c9"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "501", 2 },
                    { new Guid("3456e524-1f22-4c80-ab6c-ae386de9b3ff"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "503", 2 },
                    { new Guid("392f8109-4616-4ca7-992c-faf01ba00762"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "303", 1 },
                    { new Guid("444c1cb8-83f7-4ae2-9e35-78166517e118"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "2002", 1 },
                    { new Guid("4780fec5-501e-49cf-9778-25310534a193"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "202", 1 },
                    { new Guid("4967c185-bd83-4fbd-ac87-a4e56edd3359"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "103", 0 },
                    { new Guid("53cb40b7-b454-4473-876c-ac76c6f75038"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "3003", 0 },
                    { new Guid("5a0828b0-fb3e-445f-b5f7-b542fe0b9b6f"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "302", 1 },
                    { new Guid("5def7269-45e6-45a8-8949-2486115df694"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "3005", 0 },
                    { new Guid("6a9c49d5-6349-45d6-b2f7-2a22cacebed0"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "3004", 1 },
                    { new Guid("6d2e4603-b909-4dc8-ae32-5e46f0cb9ffb"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "1002", 1 },
                    { new Guid("7204d838-1bb2-4893-8cbf-9d7eb4c99d00"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "4002", 2 },
                    { new Guid("725e607d-93b1-4dbd-943f-79f8243e8de4"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "2003", 0 },
                    { new Guid("741c5263-60e0-4349-8821-c1cd9046a789"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "2004", 1 },
                    { new Guid("86f78365-5bd4-4084-9c01-ba4ce4be93b1"), new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"), false, "E", 1 },
                    { new Guid("8f606872-e733-48f8-bdeb-04d9bef751a9"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "205", 1 },
                    { new Guid("9567a26c-d2dc-4149-97de-6d5de1a69ccb"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "102", 0 },
                    { new Guid("95d8e017-feb4-4b8d-831a-b57389b40f67"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "1001", 0 },
                    { new Guid("9cdcda25-4b79-4f31-b09e-43adfc89943b"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "5002", 2 },
                    { new Guid("a1b43a9a-a88e-4258-a572-5498e0fb3259"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "306", 1 },
                    { new Guid("a78b8d99-e449-4bc4-a3d7-fa34dbd7185b"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "201", 1 },
                    { new Guid("ac7b2754-ed2b-46c9-b265-9f02746e01a4"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "2001", 0 },
                    { new Guid("b116361e-c0da-4000-bad0-eebe986b3b44"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "4003", 2 },
                    { new Guid("b6d9c9fa-944f-4aec-89ca-95b544b82cfc"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "1004", 1 },
                    { new Guid("b7eba9d7-1ad9-4882-a793-80b3fa6548d8"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "203", 1 },
                    { new Guid("bfc8c7f3-bc7f-4a71-8983-02f045400f09"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "204", 1 },
                    { new Guid("c1ca1a42-fb50-410f-ac40-f8b9dcae8e21"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "206", 1 },
                    { new Guid("c41d6c60-5e20-49d1-b778-6ae1780c3450"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "4001", 2 },
                    { new Guid("c947c771-17f6-41ae-b8c0-70edb5213d04"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "401", 2 },
                    { new Guid("ca69ff46-9e8e-483d-bbfe-071e38166502"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "3006", 1 },
                    { new Guid("cb17a359-4186-450c-8e7f-1387f8e2d155"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "107", 0 },
                    { new Guid("cc36d934-096b-4427-b759-e03630d190e8"), new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"), false, "A", 2 },
                    { new Guid("cf842faf-beef-4a2a-aa5d-d634830a0de3"), new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"), false, "C", 2 },
                    { new Guid("d17d7922-c4d7-4319-abaf-aea83aa724cc"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "106", 0 },
                    { new Guid("d9a3fc35-c2fa-461c-9be9-5d41f86ee4a2"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "5001", 2 },
                    { new Guid("dbdcb678-0c6f-4ecd-90ad-ec899ebca496"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "502", 2 },
                    { new Guid("e23c12b6-86a4-49aa-bf2d-6da3c9854aeb"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "3001", 0 },
                    { new Guid("e7fcea98-cc16-4581-9747-d48316aea3fe"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "402", 2 },
                    { new Guid("e897ad97-170e-4dd7-9597-e8ea46f55344"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "105", 0 },
                    { new Guid("ec1f612e-80d1-40f6-8a63-a64faed918ff"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "5003", 2 },
                    { new Guid("faeb8c43-1b1b-41b4-a7e1-e0e79bd54fb0"), new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"), false, "D", 1 },
                    { new Guid("fc2c89e1-822b-4709-bb2f-d39e9044e69e"), new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"), false, "2005", 0 },
                    { new Guid("fcf08489-96b9-4b2f-8eb0-c50ffe8bf4ee"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "305", 1 },
                    { new Guid("ff557c7f-a9cd-498e-aab2-c16a7213651e"), new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"), false, "104", 0 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "EndDate", "GuestName", "Guests", "IsDeleted", "RoomId", "StartDate" },
                values: new object[,]
                {
                    { new Guid("298880fe-9bb6-484e-93cb-ebc08efebf61"), new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Local), "Harrison Ford", 4, false, new Guid("cc36d934-096b-4427-b759-e03630d190e8"), new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("58641e5d-fb38-4df6-9df8-3e8c42fa2644"), new DateTime(2023, 7, 24, 0, 0, 0, 0, DateTimeKind.Local), "Jane Doe", 2, false, new Guid("002f3b87-d57a-43d9-ba31-6531ebc6dbe3"), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("5957ed91-41fc-48c0-ad8e-974713a75edb"), new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), "Humprey Bogart", 2, false, new Guid("cc36d934-096b-4427-b759-e03630d190e8"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("74260a32-8002-4dfa-850c-d9635e8a2f29"), new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), "Ernst Hemingway", 2, false, new Guid("1c591e3a-34af-4a46-84bb-3a39821dc930"), new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("798b274a-b853-40df-9caf-c079f43fd29b"), new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Local), "Edgar Allan Poe", 1, false, new Guid("1c591e3a-34af-4a46-84bb-3a39821dc930"), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("94d4ccca-f9c5-46ae-ad48-61bb7ab4f899"), new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), "Peter McAllister", 2, false, new Guid("002f3b87-d57a-43d9-ba31-6531ebc6dbe3"), new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("992aa3ae-3cf0-4ee7-91c1-420fc64ab9df"), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Local), "Tom Hanks", 2, false, new Guid("cc36d934-096b-4427-b759-e03630d190e8"), new DateTime(2023, 8, 4, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("a7ffdc04-0ba4-4607-9354-0ab0a1ce39e3"), new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Local), "Jane Austen", 3, false, new Guid("1c591e3a-34af-4a46-84bb-3a39821dc930"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("af3a43af-0609-4ac0-a77a-652887c11bb7"), new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local), "John Smith", 2, false, new Guid("002f3b87-d57a-43d9-ba31-6531ebc6dbe3"), new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("298880fe-9bb6-484e-93cb-ebc08efebf61"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("58641e5d-fb38-4df6-9df8-3e8c42fa2644"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("5957ed91-41fc-48c0-ad8e-974713a75edb"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("74260a32-8002-4dfa-850c-d9635e8a2f29"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("798b274a-b853-40df-9caf-c079f43fd29b"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("94d4ccca-f9c5-46ae-ad48-61bb7ab4f899"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("992aa3ae-3cf0-4ee7-91c1-420fc64ab9df"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("a7ffdc04-0ba4-4607-9354-0ab0a1ce39e3"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("af3a43af-0609-4ac0-a77a-652887c11bb7"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("12473933-3a14-4858-954f-7fd0e8402c84"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("12cdb371-f079-4a86-9686-f13d8215a571"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("16c37356-eb57-4c0e-a767-396d73bc7a49"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("21df563d-7157-4707-80f0-a725794bf76b"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("225d6dcc-546d-441c-b695-393b641f1bea"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("229b6d7d-9482-447f-9501-546180da8a7f"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("30e4b36f-a380-407b-92d9-ad5fb6a68a27"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("32a9d0c1-d129-425e-bcb9-54df52d042c9"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("3456e524-1f22-4c80-ab6c-ae386de9b3ff"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("392f8109-4616-4ca7-992c-faf01ba00762"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("444c1cb8-83f7-4ae2-9e35-78166517e118"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4780fec5-501e-49cf-9778-25310534a193"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4967c185-bd83-4fbd-ac87-a4e56edd3359"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("53cb40b7-b454-4473-876c-ac76c6f75038"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("5a0828b0-fb3e-445f-b5f7-b542fe0b9b6f"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("5def7269-45e6-45a8-8949-2486115df694"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6a9c49d5-6349-45d6-b2f7-2a22cacebed0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("6d2e4603-b909-4dc8-ae32-5e46f0cb9ffb"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("7204d838-1bb2-4893-8cbf-9d7eb4c99d00"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("725e607d-93b1-4dbd-943f-79f8243e8de4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("741c5263-60e0-4349-8821-c1cd9046a789"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("86f78365-5bd4-4084-9c01-ba4ce4be93b1"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("8f606872-e733-48f8-bdeb-04d9bef751a9"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("9567a26c-d2dc-4149-97de-6d5de1a69ccb"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("95d8e017-feb4-4b8d-831a-b57389b40f67"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("9cdcda25-4b79-4f31-b09e-43adfc89943b"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a1b43a9a-a88e-4258-a572-5498e0fb3259"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a78b8d99-e449-4bc4-a3d7-fa34dbd7185b"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ac7b2754-ed2b-46c9-b265-9f02746e01a4"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b116361e-c0da-4000-bad0-eebe986b3b44"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b6d9c9fa-944f-4aec-89ca-95b544b82cfc"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("b7eba9d7-1ad9-4882-a793-80b3fa6548d8"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("bfc8c7f3-bc7f-4a71-8983-02f045400f09"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c1ca1a42-fb50-410f-ac40-f8b9dcae8e21"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c41d6c60-5e20-49d1-b778-6ae1780c3450"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c947c771-17f6-41ae-b8c0-70edb5213d04"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ca69ff46-9e8e-483d-bbfe-071e38166502"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("cb17a359-4186-450c-8e7f-1387f8e2d155"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("cf842faf-beef-4a2a-aa5d-d634830a0de3"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d17d7922-c4d7-4319-abaf-aea83aa724cc"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("d9a3fc35-c2fa-461c-9be9-5d41f86ee4a2"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("dbdcb678-0c6f-4ecd-90ad-ec899ebca496"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e23c12b6-86a4-49aa-bf2d-6da3c9854aeb"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e7fcea98-cc16-4581-9747-d48316aea3fe"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("e897ad97-170e-4dd7-9597-e8ea46f55344"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ec1f612e-80d1-40f6-8a63-a64faed918ff"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("faeb8c43-1b1b-41b4-a7e1-e0e79bd54fb0"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fc2c89e1-822b-4709-bb2f-d39e9044e69e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("fcf08489-96b9-4b2f-8eb0-c50ffe8bf4ee"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("ff557c7f-a9cd-498e-aab2-c16a7213651e"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("002f3b87-d57a-43d9-ba31-6531ebc6dbe3"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("1c591e3a-34af-4a46-84bb-3a39821dc930"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("cc36d934-096b-4427-b759-e03630d190e8"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("086f2dae-aac0-4de4-9ad1-64662759430a"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("08f6372e-b332-412a-bb61-a5d9682bc9a7"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("efe32237-1ccb-4c95-98de-8960bbfdf0be"));
        }
    }
}
