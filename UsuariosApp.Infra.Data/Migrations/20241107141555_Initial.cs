using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PERFIL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERMISSAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERMISSAO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PERFIL_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_USUARIO_TB_PERFIL_PERFIL_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "TB_PERFIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERFIL_PERMISSAO",
                columns: table => new
                {
                    PERFIL_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PERMISSAO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIL_PERMISSAO", x => new { x.PERFIL_ID, x.PERMISSAO_ID });
                    table.ForeignKey(
                        name: "FK_TB_PERFIL_PERMISSAO_TB_PERFIL_PERFIL_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "TB_PERFIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_PERFIL_PERMISSAO_TB_PERMISSAO_PERMISSAO_ID",
                        column: x => x.PERMISSAO_ID,
                        principalTable: "TB_PERMISSAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_NOME",
                table: "TB_PERFIL",
                column: "NOME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERFIL_PERMISSAO_PERMISSAO_ID",
                table: "TB_PERFIL_PERMISSAO",
                column: "PERMISSAO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_EMAIL",
                table: "TB_USUARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_PERFIL_ID",
                table: "TB_USUARIO",
                column: "PERFIL_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERFIL_PERMISSAO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_PERMISSAO");

            migrationBuilder.DropTable(
                name: "TB_PERFIL");
        }
    }
}
