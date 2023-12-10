using btg_testes_auto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

/*ImpostoProduto
* Uma empresa vende o mesmo produto para diferentes estados.
* Cada estado possui uma taxa diferente de imposto sobre o produto
* (MG 7%; SP 12%; RJ 15%; MS 8%; ES 12%; SC 18%;).
*Faça um programa que retorne o preço final do produto acrescido do imposto do estado em que ele será vendido.
* Se o estado digitado não for válido, estoure uma exception.
*/

namespace btg_testes_auto
{
    public class ImpostoProduto
    {
        public decimal CalcularPrecoFinal(string estado, decimal precoProduto)
        {
            decimal taxaImposto;

            switch (estado.ToUpper())
            {
                case "MG":
                    taxaImposto = 0.07M; 
                    break;
                case "SP":
                    taxaImposto = 0.12M; 
                    break;
                case "RJ":
                    taxaImposto = 0.15M; 
                    break;
                case "MS":
                    taxaImposto = 0.08M; 
                    break;
                case "ES":
                    taxaImposto = 0.12M; 
                    break;
                case "SC":
                    taxaImposto = 0.18M; 
                    break;
                default:
                    throw new ArgumentException("Estado inválido. Por favor, insira um estado válido.");
            }

            decimal precoFinal = precoProduto * (1 + taxaImposto);
            return precoFinal;
        }
    }
}