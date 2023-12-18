using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class ImpostoProdutoTest
    {
        [Theory]
        [InlineData("MG", 100, 107)]
        [InlineData("SP", 100, 112)]
        [InlineData("RJ", 100, 115)]
        [InlineData("MS", 100, 108)]
        [InlineData("ES", 100, 112)]
        [InlineData("SC", 100, 118)]
        public void CalcularPrecoFinal_EstadosValidos_RetornaPrecoFinal(
            [Display(Name = "Estado")] string estado,
            [Display(Name = "Preço do Produto")] decimal precoProduto,
            [Display(Name = "Preço Esperado")] decimal precoEsperado)
        {
            // Arrange
            ImpostoProduto impostoProduto = new ImpostoProduto();

            // Act
            decimal resultado = impostoProduto.CalcularPrecoFinal(estado, precoProduto);

            // Assert
            Assert.Equal(precoEsperado, resultado, 2); 
        }

        [Fact]
        public void CalcularPrecoFinal_EstadoInvalido_LancaExcecao()
        {
            // Arrange
            ImpostoProduto impostoProduto = new ImpostoProduto();

            // Act
            // Assert
            Assert.Throws<ArgumentException>(() => impostoProduto.CalcularPrecoFinal("XYZ", 100));
        }


        [Fact]
        public void CalcularPrecoFinal_EstadoInvalido_LancaExcecao_ComMensagemCorreta()
        {
            // Arrange
            ImpostoProduto impostoProduto = new ImpostoProduto();

            // Act
            // Assert
            var excecao = Assert.Throws<ArgumentException>(() => impostoProduto.CalcularPrecoFinal("XYZ", 100));
            Assert.Equal("Estado inválido. Por favor, insira um estado válido.", excecao.Message);
        }
    }
}
