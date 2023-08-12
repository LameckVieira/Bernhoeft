using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BernhoeftApi.Migrations
{
    public partial class CriacaoDoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoUsusario = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TipoUsua__03006BFF9F10B88B", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    senha = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A63FAD6D07", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__idTipoU__5165187F",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    idCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    situacao = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioNavigationIdUsuario = table.Column<int>(type: "int", nullable: false),
                    ProdutoIdProduto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__8A3D240C1D055149", x => x.idCategoria);
                    table.ForeignKey(
                        name: "FK_Categorias_Usuario_IdUsuarioNavigationIdUsuario",
                        column: x => x.IdUsuarioNavigationIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    nome = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    descricao = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    preco = table.Column<double>(type: "float", nullable: false),
                    situacao = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuarioNavigationIdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdCategoriaNavigationIdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Produtos__5EEDF7C3597F0F45", x => x.idProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_IdCategoriaNavigationIdCategoria",
                        column: x => x.IdCategoriaNavigationIdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Usuario_IdUsuarioNavigationIdUsuario",
                        column: x => x.IdUsuarioNavigationIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_IdUsuarioNavigationIdUsuario",
                table: "Categorias",
                column: "IdUsuarioNavigationIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProdutoIdProduto",
                table: "Categorias",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoriaNavigationIdCategoria",
                table: "Produtos",
                column: "IdCategoriaNavigationIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdUsuarioNavigationIdUsuario",
                table: "Produtos",
                column: "IdUsuarioNavigationIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idTipoUsuario",
                table: "Usuario",
                column: "idTipoUsuario");

            migrationBuilder.CreateIndex(
                name: "UQ__Usuario__AB6E61647E77A90A",
                table: "Usuario",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Produtos_ProdutoIdProduto",
                table: "Categorias",
                column: "ProdutoIdProduto",
                principalTable: "Produtos",
                principalColumn: "idProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Produtos_ProdutoIdProduto",
                table: "Categorias");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
