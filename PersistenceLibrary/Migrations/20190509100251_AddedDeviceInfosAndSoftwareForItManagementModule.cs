using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersistenceLibrary.Migrations
{
    public partial class AddedDeviceInfosAndSoftwareForItManagementModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateOfPurchase = table.Column<DateTime>(nullable: false),
                    Owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameOfProgramm = table.Column<string>(nullable: true),
                    LicenseInfo = table.Column<string>(nullable: true),
                    DeviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Softwares_DeviceInfos_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "DeviceInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_DeviceId",
                table: "Softwares",
                column: "DeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Softwares");

            migrationBuilder.DropTable(
                name: "DeviceInfos");
        }
    }
}
