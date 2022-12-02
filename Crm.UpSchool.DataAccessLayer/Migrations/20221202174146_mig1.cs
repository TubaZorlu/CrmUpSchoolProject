using Microsoft.EntityFrameworkCore.Migrations;

namespace Crm.UpSchool.DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SuppilerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuppilerCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppilerCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppilerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppilerMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppilerContactName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SuppilerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
