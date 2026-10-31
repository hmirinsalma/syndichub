using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyndicHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntitiesPhase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Unit",
                newName: "UnitNumber");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Unit",
                newName: "Surface");

            migrationBuilder.RenameColumn(
                name: "FloorCount",
                table: "Building",
                newName: "FloorsCount");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Unit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Unit",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Unit",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Residence",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Residence",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Residence",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SyndicId",
                table: "Residence",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Residence",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Building",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                table: "Building",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Residence_SyndicId",
                table: "Residence",
                column: "SyndicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residence_User_SyndicId",
                table: "Residence",
                column: "SyndicId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residence_User_SyndicId",
                table: "Residence");

            migrationBuilder.DropIndex(
                name: "IX_Residence_SyndicId",
                table: "Residence");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Residence");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Residence");

            migrationBuilder.DropColumn(
                name: "SyndicId",
                table: "Residence");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Residence");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Building");

            migrationBuilder.RenameColumn(
                name: "UnitNumber",
                table: "Unit",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Surface",
                table: "Unit",
                newName: "Area");

            migrationBuilder.RenameColumn(
                name: "FloorsCount",
                table: "Building",
                newName: "FloorCount");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Unit",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Residence",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);
        }
    }
}
