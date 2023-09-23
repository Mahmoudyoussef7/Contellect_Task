using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "LockedBy", "Name", "Notes", "Phone" },
                values: new object[,]
                {
                    { new Guid("1a25b416-007e-4f7c-9cfb-afb2cebb9d1d"), "Cairo", "", "Ahbnmbnmed", "", "+2015168139999" },
                    { new Guid("32712d3c-3baa-43bf-89b2-d18acd665be4"), "Cairo", "", "p'wreer", "", "+201515553845" },
                    { new Guid("3306a4e1-9144-44bf-af59-0f3571cfe5ae"), "Cairo", "", "Ahbcvbmed", "", "+2067867868384" },
                    { new Guid("54fa99c7-4cba-4665-9a9b-ce6e20b558d3"), "Cairo", "", "Ahmed", "", "+2015168138451" },
                    { new Guid("5ccb79d7-9714-464c-afa1-0943c891b25e"), "Cairo", "", "fdsf", "", "+201544443445" },
                    { new Guid("5e2e9bd5-f05b-4cb2-a3ef-12cc224ed133"), "Cairo", "", "jghj", "", "+2018888888884" },
                    { new Guid("89be456b-0052-4ffd-bc68-53a74e0c309d"), "Cairo", "", "bmnmb", "", "+2066666681384" },
                    { new Guid("a2a77aec-69c1-4b40-b1dd-fcf644211b77"), "Cairo", "", "oiio", "", "+202222238451" },
                    { new Guid("b9065a41-d1f8-421b-aec6-4e382d26bd7a"), "Cairo", "", "dfg", "", "+2015176867884" },
                    { new Guid("cb7f4a56-d4ba-4a61-be84-eb4b99c651f2"), "Cairo", "", "op[opp", "", "+2015333333845" },
                    { new Guid("ce2a09f6-b311-4ed6-9dfd-c1c94692457f"), "Cairo", "", "jkljll;", "", "+2015100000005" },
                    { new Guid("d4e78b8c-1b1a-4832-a789-2bff07ba8f8d"), "Cairo", "", "asd", "", "+2015676786871" },
                    { new Guid("e4ba3c2e-eb82-4945-b729-077341749525"), "Cairo", "", "tyu", "", "+201516819999" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
