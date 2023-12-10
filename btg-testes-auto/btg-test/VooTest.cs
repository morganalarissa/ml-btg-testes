using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    
    public class VooTest
    {

        [Fact]
        public void AssentoDisponivel_DeveRetornarTrueQuandoAssentoLivre()
        {
            // Arrange
            var dataHora = DateTime.Now;
            var voo = new Voo("Airbus A320", "456", dataHora);
            var posicao = 5;

            // Act & Assert
            Assert.True(voo.AssentoDisponivel(posicao));
        }


        [Fact]
        public void ExibeInformacoesVoo_DeveRetornarStringCorreta()
        {
            // Arrange
            var dataHora = new DateTime(2023, 12, 1, 14, 30, 0);
            var voo = new Voo("Boeing 737", "202", dataHora);

            // Act
            var informacoesVoo = voo.ExibeInformacoesVoo();

            // Assert
            Assert.Contains("Aeronave Boeing 737", informacoesVoo);
            Assert.Contains("registrada sob voo de número 202", informacoesVoo);
            Assert.Contains("para o dia e hora 01/12/2023 14:30:00", informacoesVoo);
        }

    }
}
