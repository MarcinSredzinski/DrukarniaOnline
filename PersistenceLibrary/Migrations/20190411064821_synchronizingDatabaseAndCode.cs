using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceLibrary.Migrations
{
    public partial class synchronizingDatabaseAndCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipment_Employees_EmployeeId",
                table: "EmployeeEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipment_Equipments_EquipmentId",
                table: "EmployeeEquipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEquipment",
                table: "EmployeeEquipment");

            migrationBuilder.RenameTable(
                name: "EmployeeEquipment",
                newName: "EmployeeEquipments");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEquipment_EquipmentId",
                table: "EmployeeEquipments",
                newName: "IX_EmployeeEquipments_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEquipment_EmployeeId",
                table: "EmployeeEquipments",
                newName: "IX_EmployeeEquipments_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEquipments",
                table: "EmployeeEquipments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipments_Employees_EmployeeId",
                table: "EmployeeEquipments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipments_Equipments_EquipmentId",
                table: "EmployeeEquipments",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipments_Employees_EmployeeId",
                table: "EmployeeEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEquipments_Equipments_EquipmentId",
                table: "EmployeeEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEquipments",
                table: "EmployeeEquipments");

            migrationBuilder.RenameTable(
                name: "EmployeeEquipments",
                newName: "EmployeeEquipment");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEquipments_EquipmentId",
                table: "EmployeeEquipment",
                newName: "IX_EmployeeEquipment_EquipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEquipments_EmployeeId",
                table: "EmployeeEquipment",
                newName: "IX_EmployeeEquipment_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEquipment",
                table: "EmployeeEquipment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipment_Employees_EmployeeId",
                table: "EmployeeEquipment",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEquipment_Equipments_EquipmentId",
                table: "EmployeeEquipment",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
