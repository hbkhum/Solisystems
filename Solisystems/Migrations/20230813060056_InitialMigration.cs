using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solisystems.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryCode = table.Column<string>(type: "text", nullable: false),
                    CategoryName = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "text", nullable: false),
                    CategoryCode = table.Column<string>(type: "text", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryCode",
                        column: x => x.CategoryCode,
                        principalTable: "Categories",
                        principalColumn: "CategoryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryCode", "CategoryName", "CreationDate" },
                values: new object[,]
                {
                    { "1", "Pain Relief", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4204) },
                    { "11", "Diabetes Management", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4282) },
                    { "13", "Weight Management & Nutritional Foods", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4288) },
                    { "14", "Physical Fitness & Exercise Equipment", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4296) },
                    { "15", "Health Supports", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4304) },
                    { "16", "Compression Support", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4311) },
                    { "17", "Multi-Cultural Beauty Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4316) },
                    { "19", "Eye & Ear Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4322) },
                    { "21", "Family Planning", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4327) },
                    { "23", "Feminine Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4332) },
                    { "25", "First Aid", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4337) },
                    { "27", "Foot Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4341) },
                    { "29", "Hair Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4345) },
                    { "3", "Digestive Health", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4227) },
                    { "30", "Homeopathic Kits & Single Remedies", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4372) },
                    { "31", "Alternative Therapy", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4380) },
                    { "33", "Shaving & Grooming", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4386) },
                    { "35", "Oral Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4391) },
                    { "37", "Skin Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4396) },
                    { "38", "Nicotine Replacement Therapy", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4404) },
                    { "39", "Sun Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4408) },
                    { "40", "Trial & Travel Sizes", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4414) },
                    { "41", "Vitamins & Dietary Supplements", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4419) },
                    { "43", "Wets & Drys", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4424) },
                    { "44", "Batteries", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4429) },
                    { "5", "Baby Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4233) },
                    { "51", "Automotive Supplies", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4434) },
                    { "53", "Confections", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4439) },
                    { "54", "Cosmetics", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4466) },
                    { "55", "Electronics & Audio/Video", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4471) },
                    { "56", "Food & Beverages", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4476) },
                    { "57", "Gifts & Novelties", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4483) },
                    { "58", "Greeting Cards & Other Assoc. Mfg. Items", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4488) },
                    { "59", "Hair Accessories", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4494) },
                    { "60", "Household Products", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4499) },
                    { "61", "Leather/Vinyl Goods", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4506) },
                    { "62", "Magazines & Books", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4514) },
                    { "64", "Pet & Animal Supplies", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4519) },
                    { "65", "Photography", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4546) },
                    { "66", "Seasonal Products", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4553) },
                    { "67", "Sewing & Crafts", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4558) },
                    { "68", "Soft Lines", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4562) },
                    { "69", "Sports & Recreation", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4568) },
                    { "7", "Cold & Allergy", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4264) },
                    { "70", "School & Office", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4573) },
                    { "71", "Tobacco", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4578) },
                    { "72", "Toys", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4583) },
                    { "73", "Fragrances", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4588) },
                    { "78", "Professional OTCs In Pharmacy", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4593) },
                    { "9", "Deodorants", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4274) },
                    { "90", "Home Health Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4598) },
                    { "94", "Incontinence", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4607) },
                    { "95", "Patient Skin Care", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4612) },
                    { "96", "Home Diag &Patient Aids For Daily Living", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4637) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductCode", "CategoryCode", "CreationDate", "ProductName" },
                values: new object[,]
                {
                    { "0000000001", "1", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4654), "Product 01" },
                    { "0000000002", "1", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4666), "Product 02" },
                    { "0000000003", "1", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4672), "Product 03" },
                    { "0000000004", "9", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4677), "Product 04" },
                    { "0000000005", "9", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4683), "Product 05" },
                    { "0000000006", "9", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4689), "Product 06" },
                    { "0000000007", "9", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4694), "Product 07" },
                    { "0000000008", "17", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4700), "Product 08" },
                    { "0000000009", "17", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4704), "Product 09" },
                    { "0000000010", "17", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4711), "Product 10" },
                    { "0000000011", "17", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4716), "Product 11" },
                    { "0000000012", "21", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4721), "Product 12" },
                    { "0000000013", "21", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4726), "Product 13" },
                    { "0000000014", "21", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4731), "Product 14" },
                    { "0000000015", "21", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4758), "Product 15" },
                    { "0000000016", "30", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4763), "Product 16" },
                    { "0000000017", "30", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4768), "Product 17" },
                    { "0000000018", "30", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4775), "Product 18" },
                    { "0000000019", "30", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4781), "Product 19" },
                    { "0000000020", "38", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4785), "Product 20" },
                    { "0000000021", "38", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4790), "Product 21" },
                    { "0000000022", "38", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4795), "Product 22" },
                    { "0000000023", "38", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4802), "Product 23" },
                    { "0000000024", "38", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4807), "Product 24" },
                    { "0000000025", "40", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4812), "Product 25" },
                    { "0000000026", "40", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4817), "Product 26" },
                    { "0000000027", "40", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4823), "Product 27" },
                    { "0000000028", "40", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4827), "Product 28" },
                    { "0000000029", "55", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4860), "Product 29" },
                    { "0000000030", "55", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4865), "Product 30" },
                    { "0000000031", "55", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4870), "Product 31" },
                    { "0000000032", "55", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4875), "Product 32" },
                    { "0000000033", "55", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4880), "Product 33" },
                    { "0000000034", "60", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4887), "Product 34" },
                    { "0000000035", "60", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4892), "Product 35" },
                    { "0000000036", "60", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4897), "Product 36" },
                    { "0000000037", "60", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4929), "Product 37" },
                    { "0000000038", "65", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4936), "Product 38" },
                    { "0000000039", "65", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4941), "Product 39" },
                    { "0000000040", "65", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4946), "Product 40" },
                    { "0000000041", "65", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4951), "Product 41" },
                    { "0000000042", "66", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4956), "Product 42" },
                    { "0000000043", "67", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4961), "Product 43" },
                    { "0000000044", "68", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4977), "Product 44" },
                    { "0000000045", "70", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4982), "Product 45" },
                    { "0000000046", "71", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4988), "Product 46" },
                    { "0000000047", "72", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4992), "Product 47" },
                    { "0000000048", "73", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(4997), "Product 48" },
                    { "0000000049", "90", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5002), "Product 49" },
                    { "0000000050", "90", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5007), "Product 50" },
                    { "0000000051", "90", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5032), "Product 51" },
                    { "0000000052", "90", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5037), "Product 52" },
                    { "0000000053", "95", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5042), "Product 53" },
                    { "0000000054", "95", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5046), "Product 54" },
                    { "0000000055", "95", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5051), "Product 55" },
                    { "0000000056", "95", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5056), "Product 56" },
                    { "0000000057", "95", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5060), "Product 57" },
                    { "0000000058", "95", new DateTime(2023, 8, 13, 6, 0, 56, 288, DateTimeKind.Utc).AddTicks(5065), "Product 58" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories",
                column: "CategoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCode",
                table: "Products",
                column: "CategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCode",
                table: "Products",
                column: "ProductCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
