using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_Job.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profile_Picture",
                table: "Applications");

            migrationBuilder.AddColumn<string>(
                name: "profile_Picture",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profile_Picture",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "profile_Picture",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
