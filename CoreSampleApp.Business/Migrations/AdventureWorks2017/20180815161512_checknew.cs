using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreSampleApp.Business.Migrations.AdventureWorks2017
{
    public partial class checknew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "UserName",
            //    columns: table => new
            //    {
            //        UserName = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserName", x => x.UserName);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "UserName");
        }
    }
}
