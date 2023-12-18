using btg_testes_auto;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class MotoristaTest
    {
        [Fact]
        public void EncontrarMotoristas_DeveRetornarMotoristasQuandoDisponiveis()
        {
            // Arrange
            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Morgana", Idade = 20, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 25, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Pedro", Idade = 17, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Ana", Idade = 22, PossuiHabilitaçãoB = false },
        };

            // Act
            var resultado = motorista.EncontrarMotoristas(pessoas);

            // Assert
            Assert.Contains("Uhuu! Os motoristas são ", resultado);
        }

        [Fact]
        public void EncontrarMotoristas_DeveLancarExcecaoQuandoNaoHaMotoristas()
        {
            // Arrange
            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Morgana", Idade = 15, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 17, PossuiHabilitaçãoB = false },
        };

            // Act & Assert
            Assert.Throws<Exception>(() => motorista.EncontrarMotoristas(pessoas));
        }


        [Fact]
        public void EncontrarMotoristas_DeveLancarExcecaoQuandoNenhumaPessoaTemHabilitacao()
        {
            // Arrange
            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Carlos", Idade = 25, PossuiHabilitaçãoB = false },
            new Pessoa { Nome = "Fernanda", Idade = 22, PossuiHabilitaçãoB = false },
        };

            // Act & Assert
            Assert.Throws<Exception>(() => motorista.EncontrarMotoristas(pessoas));
        }

        [Fact]
        public void EncontrarMotoristas_DeveIgnorarPessoasMenoresDeIdade()
        {
            // Arrange
            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Morgana", Idade = 20, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 25, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Pedro", Idade = 17, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Ana", Idade = 22, PossuiHabilitaçãoB = false },
        };

            // Act
            var resultado = motorista.EncontrarMotoristas(pessoas);

            // Assert
            Assert.Contains("Uhuu! Os motoristas são ", resultado);
            Assert.DoesNotContain("Pedro", resultado); 
        }

        [Fact]
        public void EncontrarMotoristas_DeveIncluirPessoaCom18Anos()
        {
            // Arrange
            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
        {
            new Pessoa { Nome = "Morgana", Idade = 20, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Maria", Idade = 18, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Pedro", Idade = 17, PossuiHabilitaçãoB = true },
            new Pessoa { Nome = "Ana", Idade = 22, PossuiHabilitaçãoB = false },
        };

            // Act
            var resultado = motorista.EncontrarMotoristas(pessoas);

            // Assert
            Assert.Contains("Uhuu! Os motoristas são ", resultado);
            Assert.Contains("Maria", resultado);
        }

    }
}
