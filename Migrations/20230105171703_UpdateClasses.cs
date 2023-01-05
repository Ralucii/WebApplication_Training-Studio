using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_Training_Studio.Migrations
{
    public partial class UpdateClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "FitnessClass",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "LocationID",
                table: "FitnessClass",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainerID",
                table: "FitnessClass",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClass_LocationID",
                table: "FitnessClass",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClass_TrainerID",
                table: "FitnessClass",
                column: "TrainerID");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClass_Locations_LocationID",
                table: "FitnessClass",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FitnessClass_Trainer_TrainerID",
                table: "FitnessClass",
                column: "TrainerID",
                principalTable: "Trainer",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClass_Locations_LocationID",
                table: "FitnessClass");

            migrationBuilder.DropForeignKey(
                name: "FK_FitnessClass_Trainer_TrainerID",
                table: "FitnessClass");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_FitnessClass_LocationID",
                table: "FitnessClass");

            migrationBuilder.DropIndex(
                name: "IX_FitnessClass_TrainerID",
                table: "FitnessClass");

            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "FitnessClass");

            migrationBuilder.DropColumn(
                name: "TrainerID",
                table: "FitnessClass");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "FitnessClass",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
