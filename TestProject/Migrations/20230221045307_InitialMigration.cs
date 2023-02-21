using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = "CREATE PROCEDURE [dbo].[spcustomer]\r\n  " +
                "  @Firstname nvarchar(50),\r\n  " +
                "  @Lastname nvarchar(100),\r\n   " +
                " @Phone nvarchar(15)\r\nAS\r\nBEGIN\r\n  " +
                "  INSERT INTO [dbo].[customers]\r\n         " +
                "  ([Firstname],\r\n\t\t   [Lastname]\r\n     " +
                "      ,[contact])\r\n     VALUES\r\n       " +
                "    (@Firstname\r\n           ,@Lastname\r\n  " +
                "         ,@Phone)\r\nEND\r\n\r\n";
               
            string updateSp = "\"CREATE PROCEDURE [dbo].[spUpdateData]\\r\\n  \" +\r\n     " +
                " \"  @Id int,\\r\\n" +
                "@Firstname nvarchar(50),\\r\\n \" +\r\n\" " +
                "@Lastname nvarchar(100),\\r\\n  \" +\r\n " +
                "\" @Phone nvarchar(15)\\r\\nAS\\r\\nBEGIN\\r\\n  \" +\r\n" +
                " \"  UPDATE [dbo].[customers]\\r\\n   \" +\r\n " +
                " \" SET [Firstname] = @Firstname\\r\\n  \" +\r\n  " +
                "  \"    ,[Lastname] = @Lastname\\r\\n    \" +\r\n " +
                " \",[contact] = @Phone\\r\\n   \" +\r\n\" WHERE [id] = @Id\\r\\nEND\\r\\n\\r\\n\"";

            string deleteSp = "\r\nCREATE PROCEDURE [dbo].[DeleteData]\r\n  " +
                "  @Id int\r\nAS\r\nBEGIN\r\n  " +
                "  DELETE FROM [dbo].[customers]\r\n  " +
                "  WHERE [id] = @Id\r\nEND\r\n\r\n" +
                "\r\nCREATE PROCEDURE [dbo].[ListData]\r\n" +
                "AS\r\nBEGIN\r\n    SELECT [id]\r\n     " +
                "  ,[Firstname]\r\n " +
                ",[Lastname]\r\n " +
                ",[contact]\r\n" +
                "FROM [dbo].[customers]\r\nEND\r\n";

            migrationBuilder.Sql(deleteSp);
            migrationBuilder.Sql(procedure);
            migrationBuilder.Sql(updateSp);


            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = "Drop PROCEDURE [dbo].[spcustomer]\r\n  " +
                "  @Firstname nvarchar(50),\r\n  " +
                "  @Lastname nvarchar(100),\r\n   " +
                " @Phone nvarchar(15)\r\nAS\r\nBEGIN\r\n  " +
                "  INSERT INTO [dbo].[customers]\r\n         " +
                "  ([Firstname],\r\n\t\t   [Lastname]\r\n     " +
                "      ,[contact])\r\n     VALUES\r\n       " +
                "    (@Firstname\r\n           ,@Lastname\r\n  " +
                "         ,@Phone)\r\nEND\r\n\r\n";
            string updateSp = "\"DROP PROCEDURE [dbo].[UpdateData]\\r\\n  \" +\r\n     " +
               " \"  @Id int,\\r\\n" +
               "@Firstname nvarchar(50),\\r\\n \" +\r\n\" " +
               "@Lastname nvarchar(100),\\r\\n  \" +\r\n " +
               "\" @Phone nvarchar(15)\\r\\nAS\\r\\nBEGIN\\r\\n  \" +\r\n" +
               " \"  UPDATE [dbo].[customers]\\r\\n   \" +\r\n " +
               " \" SET [Firstname] = @Firstname\\r\\n  \" +\r\n  " +
               "  \"    ,[Lastname] = @Lastname\\r\\n    \" +\r\n " +
               " \",[contact] = @Phone\\r\\n   \" +\r\n\" WHERE [id] = @Id\\r\\nEND\\r\\n\\r\\n\"";
            string deleteSp = "\r\nCREATE PROCEDURE [dbo].[DeleteData]\r\n  " +
                "  @Id int\r\nAS\r\nBEGIN\r\n  " +
                "  DELETE FROM [dbo].[customers]\r\n  " +
                "  WHERE [id] = @Id\r\nEND\r\n\r\n" +
                "\r\nCREATE PROCEDURE [dbo].[ListData]\r\n" +
                "AS\r\nBEGIN\r\n    SELECT [id]\r\n     " +
                "  ,[Firstname]\r\n " +
                ",[Lastname]\r\n " +
                ",[contact]\r\n" +
                "FROM [dbo].[customers]\r\nEND\r\n";
            migrationBuilder.Sql(deleteSp);
            migrationBuilder.Sql(updateSp);
            migrationBuilder.Sql(procedure);

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
