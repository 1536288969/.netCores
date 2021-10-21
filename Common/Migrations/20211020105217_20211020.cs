using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class _20211020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logger",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Account = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    RealName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IPAddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logger", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevisedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevisedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerAccount = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ManagerPwd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RealName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevisedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Manager_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleToModule",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Flag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleToModule", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleToModule_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manager_RoleID",
                table: "Manager",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleToModule_RoleID",
                table: "RoleToModule",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logger");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "RoleToModule");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
