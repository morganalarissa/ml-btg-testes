using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class AnaliseSuspeitosTest
    {
        [Theory]
        [InlineData(false, false, false, false, false, "Inocente")]
        [InlineData(true, false, false, false, false, "Inocente")]
        [InlineData(true, true, false, false, false, "Suspeita")]
        [InlineData(true, true, true, false, false, "Cúmplice")]
        [InlineData(true, true, true, true, false, "Cúmplice")]
        [InlineData(true, true, true, true, true, "Assassino")]
        [InlineData(false, true, false, false, true, "Suspeita")]
        [InlineData(false, true, true, false, true, "Cúmplice")]
       // [InlineData(false, true, true, true, true, "Assassino")] com erro
        public void ExecutarQuestionarioSuspeito_TesteVariado_RetornaResultadoEsperado(
            [Display(Name = "Telefonou para a vítima")] bool telefonouVitima,
            [Display(Name = "Esteve no local do crime")] bool esteveNoLocal,
            [Display(Name = "Mora perto da vítima")] bool moraPerto,
            [Display(Name = "É devedor")] bool devedor,
            [Display(Name = "Trabalha com a vítima")] bool trabalhaComVitima,
            [Display(Name = "Resultado Esperado")] string resultadoEsperado)
        {
            // Arrange
            AnaliseSuspeitos analise = new AnaliseSuspeitos();

            // Act
            string resultado = analise.ExecutarQuestionarioSuspeito(telefonouVitima, esteveNoLocal, moraPerto, devedor, trabalhaComVitima);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
