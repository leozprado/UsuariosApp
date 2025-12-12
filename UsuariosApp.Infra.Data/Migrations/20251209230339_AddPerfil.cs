using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PERFIL_ID",
                table: "USUARIOS",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PERFIS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_PERFIL_ID",
                table: "USUARIOS",
                column: "PERFIL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIS_NOME",
                table: "PERFIS",
                column: "NOME",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PERFIS_PERFIL_ID",
                table: "USUARIOS",
                column: "PERFIL_ID",
                principalTable: "PERFIS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_PERFIS_PERFIL_ID",
                table: "USUARIOS");

            migrationBuilder.DropTable(
                name: "PERFIS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_PERFIL_ID",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "PERFIL_ID",
                table: "USUARIOS");
        }
    }
}
