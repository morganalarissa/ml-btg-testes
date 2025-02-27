﻿using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test
{
    public class LucroTest
    {
        [Fact]
        public void Calcular_LucroMenorQue20_DeveRetornarValorCom45PorCentoDeLucro()
        {
            // Arrange
            Lucro lucro = new Lucro();
            decimal valorProduto = 15.0M;
            decimal esperado = 15.0M * 1.45M;

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void Calcular_LucroMaiorOuIgualA20_DeveRetornarValorCom30PorCentoDeLucro()
        {
            // Arrange
            Lucro lucro = new Lucro();
            decimal valorProduto = 25.0M;
            decimal esperado = 25.0M * 1.30M;

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void Calcular_LucroIgualA20_DeveRetornarValorCom30PorCentoDeLucro()
        {
            // Arrange
            Lucro lucro = new Lucro();
            decimal valorProduto = 20.0M;
            decimal esperado = 20.0M * 1.30M;

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void Calcular_LucroDecimalMenorQue20_DeveRetornarValorCom45PorCentoDeLucro()
        {
            // Arrange
            Lucro lucro = new Lucro();
            decimal valorProduto = 19.99M;
            decimal esperado = 19.99M * 1.45M;

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            // Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void Calcular_LucroDecimalMaiorOuIgualA20_DeveRetornarValorCom30PorCentoDeLucro()
        {
            // Arrange
            Lucro lucro = new Lucro();
            decimal valorProduto = 20.01M;
            decimal esperado = 20.01M * 1.30M;

            // Act
            decimal resultado = lucro.Calcular(valorProduto);

            // Assert
            Assert.Equal(esperado, resultado);
        }
    }
}
