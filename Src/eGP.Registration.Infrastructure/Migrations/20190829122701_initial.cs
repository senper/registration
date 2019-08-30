using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eGP.Registration.Persistance.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "registration");

            migrationBuilder.CreateTable(
                name: "OrganizationStructures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    Profile = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationStructures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Placements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    StructureId = table.Column<Guid>(nullable: false),
                    PersonnelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                schema: "registration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    date_modified = table.Column<DateTime>(type: "timestamptz", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    code = table.Column<string>(type: "varchar(50)", nullable: false),
                    name = table.Column<string>(type: "varchar(500)", nullable: false),
                    short_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    version = table.Column<string>(type: "varchar(50)", nullable: true),
                    profile = table.Column<string>(type: "jsonb", nullable: true),
                    root_structure_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "registration",
                table: "organizations",
                columns: new[] { "Id", "code", "created_by", "date_created", "date_modified", "modified_by", "name", "profile", "root_structure_id", "short_name", "StatusId", "version" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "axy0{i}", new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2019, 8, 29, 12, 27, 0, 131, DateTimeKind.Utc).AddTicks(7904), null, null, "Ministry of ABC", null, new Guid("00000000-0000-0000-0000-000000000100"), "ABC", 0, "0.0.1" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "axy0{i}", new Guid("00000000-0000-0000-0000-000000000020"), new DateTime(2019, 8, 29, 12, 27, 0, 131, DateTimeKind.Utc).AddTicks(9520), null, null, "Ministry of ACB", null, new Guid("00000000-0000-0000-0000-000000000200"), "ACB", 0, "0.0.1" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "axy0{i}", new Guid("00000000-0000-0000-0000-000000000030"), new DateTime(2019, 8, 29, 12, 27, 0, 131, DateTimeKind.Utc).AddTicks(9556), null, null, "Ministry of BAC", null, new Guid("00000000-0000-0000-0000-000000000300"), "BAC", 0, "0.0.1" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "axy0{i}", new Guid("00000000-0000-0000-0000-000000000040"), new DateTime(2019, 8, 29, 12, 27, 0, 131, DateTimeKind.Utc).AddTicks(9579), null, null, "Ministry of BCA", null, new Guid("00000000-0000-0000-0000-000000000400"), "BCA", 0, "0.0.1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationStructures");

            migrationBuilder.DropTable(
                name: "Placements");

            migrationBuilder.DropTable(
                name: "organizations",
                schema: "registration");
        }
    }
}
