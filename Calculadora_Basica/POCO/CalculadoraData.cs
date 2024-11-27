using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Basica.POCO
{
    public class CalculadoraData
    {
        public double valorUno { get; set; }
        public double valorDos { get; set; }
        public string operacion { get; set; }

        public double resultado { get; set; }
    }
}
