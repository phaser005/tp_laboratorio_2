using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeroSpace
{
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
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Numero() : this(0)
        {

        }
        /// <summary>
        /// Constructor que recibe un string de numero
        /// </summary>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Constructor que recibe un double de numero
        /// </summary>
        public Numero(double numero)
        {
            _numero = numero;
        }
        #endregion

        #region VALIDACION
        /// <summary>
        /// Valida que el string pasado como parametro sea valido como numero
        /// </summary>
        /// <param name="strNumero">cadena de caracteres a ser convertida en numero</param>
        /// <returns>numero, en formato double</returns>
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

        /// <summary>
        /// Realiza una suma entre dos numeros
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero, primer operando</param>
        /// <param name="n2">Objeto de tipo Numero, segundo operando</param>
        /// <returns>resultado de la operacion de suma, de tipo double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double something = 0;
            something = n1._numero + n2._numero;
            return something;
        }

        /// <summary>
        /// Realiza una resta entre dos numeros
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero, primer operando</param>
        /// <param name="n2">Objeto de tipo Numero, segundo operando</param>
        /// <returns>resultado de la operacion de resta, de tipo double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double something = 0;
            something = n1._numero - n2._numero;
            return something;
        }

        /// <summary>
        /// Realiza una multiplicacion entre dos numeros
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero, primer operando</param>
        /// <param name="n2">Objeto de tipo Numero, segundo operando</param>
        /// <returns>resultado de la operacion de multiplicacion, de tipo double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double something = 0;
            something = n1._numero * n2._numero;
            return something;
        }

        /// <summary>
        /// Realiza una division entre dos numeros
        /// </summary>
        /// <param name="n1">Objeto de tipo Numero, primer operando</param>
        /// <param name="n2">Objeto de tipo Numero, segundo operando</param>
        /// <returns>resultado de la operacion de division, de tipo double</returns>
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

        /// <summary>
        /// Convierte un numero de Binario a Decimal, recibiendo este primero como string
        /// </summary>
        /// <param name="binario">Numero binario string a convertir a Decimal</param>
        /// <returns>Decimal en formato string</returns>
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

        /// <summary>
        /// Convierte un numero de Decimal a Binario, recibiendo este primero como double
        /// </summary>
        /// <param name="numero">Numero decimal double a convertir a binario</param>
        /// <returns>Binario string</returns>
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

        /// <summary>
        /// Convierte un numero de Decimal a Binario, recibiendo este primero como string
        /// </summary>
        /// <param name="numero">Numero decimal string a convertir a binario</param>
        /// <returns>Binario string</returns>
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
