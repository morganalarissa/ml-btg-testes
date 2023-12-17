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
        [Fact]
        [Trait("Perfil", "Estudante")]
        public void VerificarMeiaCinema_Estudante_DeveRetornarTrue()
        {
            // Arrange
            
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(true, false, false, false);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        [Trait("Perfil", "Doador de Sangue")]
        public void VerificarMeiaCinema_DoadorDeSangue_DeveRetornarTrue()
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(false, true, false, false);

            // Assert
            Assert.True(resultado);
        }

        [Fact]        
        [Trait("Perfil", "TrabalhadorPrefeituraComContrato")]
        public void VerificarMeiaCinema_TrabalhadorPrefeituraComContrato_DeveRetornarTrue()
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(false, false, true, true);

            // Assert
            Assert.True(resultado);
        }

        [Fact]        
        [Trait("Perfil", "TrabalhadorPrefeituraSemContrato")]
        public void VerificarMeiaCinema_TrabalhadorPrefeituraSemContrato_DeveRetornarFalse()
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(false, false, true, false);

            // Assert
            Assert.False(resultado);
        }

        [Fact]        
        [Trait("Perfil", "NenhumPerfil")]
        public void VerificarMeiaCinema_NenhumPerfil_DeveRetornarFalse()
        {
            // Arrange
            MeiaCinema meiaCinema = new MeiaCinema();

            // Act
            bool resultado = meiaCinema.VerificarMeiaCinema(false, false, false, false);

            // Assert
            Assert.False(resultado);
        }
    }
}

