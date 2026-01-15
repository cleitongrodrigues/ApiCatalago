using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
                   "Values ('Jhony Walker', 'Whisky', 175.50, 'walkerwhisky.jpg', 8, now(), 1)");

            mb.Sql("Insert Into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) " +
                    "Values ('Royal Salut', 'Whisky', 585.50, 'salut.jpg', 3, now(), 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete From Produtos");
        }
    }
}
