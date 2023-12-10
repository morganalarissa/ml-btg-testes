using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class MeiaCinemaTest
    {
        [Theory]
        [InlineData(true, false, false, false)]
        [Trait("Perfil", "Estudante")]
        public void VerificarMeiaCinema_Estudante_DeveRetornarTrue(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData(false, true, false, false)]
        [Trait("Perfil", "Doador de Sangue")]
        public void VerificarMeiaCinema_DoadorDeSangue_DeveRetornarTrue(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData(false, false, true, true)]
        [Trait("Perfil", "TrabalhadorPrefeituraComContrato")]
        public void VerificarMeiaCinema_TrabalhadorPrefeituraComContrato_DeveRetornarTrue(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.True(resultado);
        }

        [Theory]
        [InlineData(false, false, true, false)]
        [Trait("Perfil", "TrabalhadorPrefeituraSemContrato")]
        public void VerificarMeiaCinema_TrabalhadorPrefeituraSemContrato_DeveRetornarFalse(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.False(resultado);
        }

        [Theory]
        [InlineData(false, false, false, false)]
        [Trait("Perfil", "NenhumPerfil")]
        public void VerificarMeiaCinema_NenhumPerfil_DeveRetornarFalse(bool estudante, bool doadorDeSangue, bool trabalhadorPrefeitura, bool contratoPrefeitura)
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(estudante, doadorDeSangue, trabalhadorPrefeitura, contratoPrefeitura);

            // Assert
            Assert.False(resultado);
        }
    }
}

