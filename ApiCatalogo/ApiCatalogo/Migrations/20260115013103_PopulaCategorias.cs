using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Categorias (Nome, ImagemUrl) Values ('Bebida1','bebidas1.jpg')");
            mb.Sql("Insert Into Categorias (Nome, ImagemUrl) Values ('Bebida2','bebidas2.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete From Categorias");
        }
    }
}
