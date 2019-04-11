using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //CLASE CALCULADORA
    public static class Calculadora
    {
        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double something = double.MinValue;

            switch (ValidarOperador(operador))
            {
                case "+":
                    something = n1 + n2;
                    break;
                case "-":
                    something = n1 - n2;
                    break;
                case "*":
                    something = n1 * n2;
                    break;
                case "/":
                    something = n1 / n2;
                    break;
                default:
                    break;
            }

            return something;
        }

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

    //CLASE NUMERO
    public class Numero
    {

        private double _numero;

        private string SetNumero
        {
            set
            {
                _numero = ValidarNumero(value);
            }
        }


        #region CONSTRUCTORES (3)
        public Numero() : this(0)
        {

        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public Numero(double numero)
        {
            _numero = numero;
        }
        #endregion

        #region VALIDACION
        private double ValidarNumero(string strNumero)
        {
            double doubleNumber;

            //bool isNumeric = double.TryParse(strNumero, out doubleNumber);

            if (double.TryParse(strNumero, out doubleNumber))
            {
                doubleNumber = Convert.ToDouble(strNumero);
            }
            else
            {
                doubleNumber = 0;
            }

            return doubleNumber;
        }
        #endregion

        #region OPERATORS (4)
        ///////////////////////SUMA
        public static double operator +(Numero n1, Numero n2)
        {
            double something = 0;
            something = n1._numero + n2._numero;
            return something;
        }
        ///////////////////////RESTA
        public static double operator -(Numero n1, Numero n2)
        {
            double something = 0;
            something = n1._numero - n2._numero;
            return something;
        }
        ///////////////////////MULTIPLICACION
        public static double operator *(Numero n1, Numero n2)
        {
            double something = 0;
            something = n1._numero * n2._numero;
            return something;
        }
        ///////////////////////DIVISION
        public static double operator /(Numero n1, Numero n2)
        {
            double something = 0;
            if (n2._numero == 0)
            {
                something = double.MinValue;
            }
            else
            {
                something = n1._numero / n2._numero;
            }
            return something;
        }
        #endregion

        #region CONVERSORES BINARIO/DECIMAL (3)

        ///////////////////////BINARIO DECIMAL
        public string BinarioDecimal(string binario)
        {
            string something = "valor invalido";
            bool check = true;
            int fromBase = 2;
            int toBase = 10;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                    check = false;
            }

            if (check)
                something = Convert.ToString(Convert.ToDouble(Convert.ToString(Convert.ToInt32(binario, fromBase), toBase)));


            return something;
        }

        ///////////////////////DECIMAL BINARIO
        public string DecimalBinario(double numero)
        {
            string something = "valor invalido";

            string NumberAux = Convert.ToString(Math.Abs(numero));
            int fromBase = 10;
            int toBase = 2;

            if (numero >= 0)
                something = Convert.ToString(Convert.ToInt32(NumberAux, fromBase), toBase);

            return something;
        }

        public string DecimalBinario(string numero)
        {
            string something = "valor invalido";
            double aux;

            if (double.TryParse(numero, out aux))
            {
                if (aux >= 0)
                    something = DecimalBinario(aux);

            }
            return something;
        }
        #endregion
    }
}

