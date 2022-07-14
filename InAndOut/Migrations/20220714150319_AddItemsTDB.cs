using Microsoft.EntityFrameworkCore.Migrations;

namespace InAndOut.Migrations
{
    public partial class AddItemsTDB : Migration
    {

        /// <summary>
        /// This class was created using the entityframework core model. 
        /// It has taken the model class item and has created an instance of it from the AppDbContrext  
        ///
        /// add-migration was used in the Package manager console(view > other windows > package manager console
        /// Then gavbe it a meaning name "AddItemsTDB"
        /// Then used update-databse to update to the actual db. 
        /// 
        /// </summary>
        /// <param name="migrationBuilder"></param>
        /// 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Borrower = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
