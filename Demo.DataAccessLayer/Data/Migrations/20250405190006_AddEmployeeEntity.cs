using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 5, 21, 0, 5, 809, DateTimeKind.Local).AddTicks(118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 5, 0, 9, 24, 813, DateTimeKind.Local).AddTicks(8590));

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    varchar50 = table.Column<string>(name: "varchar(50)", type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    varchar100 = table.Column<string>(name: "varchar(100)", type: "nvarchar(max)", nullable: false),
                    decimal102 = table.Column<decimal>(name: "decimal(10,2)", type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HiringDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 5, 0, 9, 24, 813, DateTimeKind.Local).AddTicks(8590),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 4, 5, 21, 0, 5, 809, DateTimeKind.Local).AddTicks(118));
        }
    }
}
