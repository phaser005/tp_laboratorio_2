using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumeroSpace;

namespace CalculadoraSpace
{
    public static class Calculadora
    {
        /// <summary>
        /// Opera dos numeros, segun el operador pasado como parametro
        /// </summary>
        /// <param name="n1">Primer operando de tipo Numero</param>
        /// <param name="n2">Segundo operando de tipo Numero</param>
        /// <param name="operador">Caracter que indica el tipo de operacion a realizar</param>
        /// <returns>Double con el resultado</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double something = double.MinValue;

            switch (ValidarOperador(operador))
            {
                case "+":
                    something = num1 + num2;
                    break;
                case "-":
                    something = num1 - num2;
                    break;
                case "*":
                    something = num1 * num2;
                    break;
                case "/":
                    something = num1 / num2;
                    break;
                default:
                    break;
            }

            return something;
        }

        /// <summary>
        /// Valida que el operador pasado como parametro este en la lista de operadores permitidos, de lo contrario devuelve '+'
        /// </summary>
        /// <param name="operador">Operador a confirmar</param>
        /// <returns>Operador confirmado y listo para usarse</returns>
        private static string ValidarOperador(string operador)
        {
            string something = "";

            switch (operador)
            {
                case "-":
                    something = "-";
                    break;

                case "*":
                    something = "*";
                    break;

                case "/":
                    something = "/";
                    break;

                default:
                    something = "+";
                    break;
            }

            return something;
        }
    }    
}

