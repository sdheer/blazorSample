using Microsoft.EntityFrameworkCore.Migrations;

namespace APIService.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Orders_OrderId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Stores_StoreId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserEntityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserEntityId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Item_StoreId",
                table: "Items",
                newName: "IX_Items_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_OrderId",
                table: "Items",
                newName: "IX_Items_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "StoreID",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Orders_OrderId",
                table: "Items",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Orders_OrderId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Stores_StoreId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StoreID",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Items_StoreId",
                table: "Item",
                newName: "IX_Item_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_OrderId",
                table: "Item",
                newName: "IX_Item_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "Orders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserEntityId",
                table: "Orders",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Orders_OrderId",
                table: "Item",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Stores_StoreId",
                table: "Item",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserEntityId",
                table: "Orders",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
