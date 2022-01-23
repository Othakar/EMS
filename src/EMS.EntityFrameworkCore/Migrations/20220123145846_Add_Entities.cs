using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EMS.Migrations
{
    public partial class Add_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMSCitizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Size = table.Column<decimal>(type: "numeric", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDoingDrug = table.Column<bool>(type: "boolean", nullable: false),
                    HaveInsurance = table.Column<bool>(type: "boolean", nullable: false),
                    PhoneNumber = table.Column<int>(type: "integer", nullable: false),
                    JobName = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMSCitizens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMSGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMSGrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMSCareStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GradeId = table.Column<int>(type: "integer", nullable: false),
                    CitizenId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMSCareStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMSCareStaffs_EMSCitizens_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "EMSCitizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMSCareStaffs_EMSGrades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "EMSGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMSRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdCareStaff = table.Column<int>(type: "integer", nullable: false),
                    IdCitizen = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMSRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMSRecords_EMSCareStaffs_IdCareStaff",
                        column: x => x.IdCareStaff,
                        principalTable: "EMSCareStaffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMSRecords_EMSCitizens_IdCitizen",
                        column: x => x.IdCitizen,
                        principalTable: "EMSCitizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMSActs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    RecordId = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMSActs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMSActs_EMSRecords_RecordId",
                        column: x => x.RecordId,
                        principalTable: "EMSRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMSActs_RecordId",
                table: "EMSActs",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_EMSCareStaffs_CitizenId",
                table: "EMSCareStaffs",
                column: "CitizenId");

            migrationBuilder.CreateIndex(
                name: "IX_EMSCareStaffs_GradeId",
                table: "EMSCareStaffs",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_EMSRecords_IdCareStaff",
                table: "EMSRecords",
                column: "IdCareStaff");

            migrationBuilder.CreateIndex(
                name: "IX_EMSRecords_IdCitizen",
                table: "EMSRecords",
                column: "IdCitizen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMSActs");

            migrationBuilder.DropTable(
                name: "EMSRecords");

            migrationBuilder.DropTable(
                name: "EMSCareStaffs");

            migrationBuilder.DropTable(
                name: "EMSCitizens");

            migrationBuilder.DropTable(
                name: "EMSGrades");
        }
    }
}
