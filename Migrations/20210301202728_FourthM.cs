using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsAndCategories.Migrations
{
    public partial class FourthM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Categories_CategoryID",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Products_ProductID",
                table: "Associations");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Associations",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Associations",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_ProductID",
                table: "Associations",
                newName: "IX_Associations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_CategoryID",
                table: "Associations",
                newName: "IX_Associations_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Categories_CategoryId",
                table: "Associations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Products_ProductId",
                table: "Associations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Categories_CategoryId",
                table: "Associations");

            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Products_ProductId",
                table: "Associations");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Associations",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Associations",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_ProductId",
                table: "Associations",
                newName: "IX_Associations_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Associations_CategoryId",
                table: "Associations",
                newName: "IX_Associations_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Categories_CategoryID",
                table: "Associations",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Products_ProductID",
                table: "Associations",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
