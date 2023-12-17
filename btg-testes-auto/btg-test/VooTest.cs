using btg_testes_auto;
using FluentAssertions;
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
        public void ProximoLivre_DeveRetornarPosicaoDoProximoAssentoLivre()
        {
            // Arrange
            var dataHora = DateTime.Now;
            var voo = new Voo("A320", "V123", dataHora);

            // Act
            var proximoLivre = voo.ProximoLivre();

            // Assert
            proximoLivre.Should().Be(1); 
        }

        [Fact]
        public void AssentoDisponivel_DeveRetornarTrueSeAssentoEstiverDisponivel()
        {
            // Arrange
            var dataHora = DateTime.Now;
            var voo = new Voo("A320", "V123", dataHora);

            // Act
            var assentoDisponivel = voo.AssentoDisponivel(1);

            // Assert
            assentoDisponivel.Should().BeTrue();
        }

        [Fact]
        public void QuantidadeVagasDisponivel_DeveRetornarQuantidadeCorreta()
        {
            // Arrange
            var dataHora = DateTime.Now;
            var voo = new Voo("A320", "V123", dataHora);

            // Act
            var quantidadeVagas = voo.QuantidadeVagasDisponivel();

            // Assert
            quantidadeVagas.Should().Be(100); 
        }

        [Fact]
        public void ExibeInformacoesVoo_DeveRetornarInformacoesCorretas()
        {
            // Arrange
            var dataHora = DateTime.Now;
            var voo = new Voo("A320", "V123", dataHora);

            // Act
            var informacoesVoo = voo.ExibeInformacoesVoo();

            // Assert
            informacoesVoo.Should().Be($"Aeronave A320 registrada sob voo de número V123 para o dia e hora {dataHora}");
        }

        [Fact]
        public void OcupaAssento_DeveRetornarFalseSeAssentoNaoEstiverDisponivel()
        {
            // Arrange
            var dataHora = DateTime.Now;
            var voo = new Voo("A320", "V123", dataHora);

            // Act
            var ocupouAssento = voo.OcupaAssento(101); 

            // Assert
            ocupouAssento.Should().BeFalse();
        }


        [Fact]
        public void QuantidadeVagasDisponivel_DeveAtualizarAoOcuparAssento()
        {
            // Arrange
            var dataHora = DateTime.Now;
            var voo = new Voo("A320", "V123", dataHora);

            // Act
            voo.OcupaAssento(1);
            var quantidadeVagas = voo.QuantidadeVagasDisponivel();

            // Assert
            quantidadeVagas.Should().Be(99);
        }

    }
}

