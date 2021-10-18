using System;
using System.Text.RegularExpressions;

namespace PetShopCore
{
    public static class Validaciones
    {
        #region CONSTRUCTORES

        static Validaciones()
        {
        }

        #endregion


        #region METODOS

        public static bool Int(string strNumero)
        {
            int numero;

            if (int.TryParse(strNumero, out numero))
                return true;
            else
                throw new ValorInvalidoException();
        }

        public static bool Int_Unsigned(string strNumero)
        {
            int numero;

            if (int.TryParse(strNumero, out numero))
            {
                //Si se pudo parsear, chequeamos que sea positivo
                if (numero > 0)
                    return true;
            }

            throw new ValorInvalidoException();
        }

        public static bool Double(string strNumero)
        {
            double numero;

            if (double.TryParse(strNumero, out numero))
                return true;
            else
                throw new ValorInvalidoException();
        }

        public static bool Double_Unsigned(string strNumero)
        {
            double numero;

            if (double.TryParse(strNumero, out numero))
            {
                //Si se pudo parsear, chequeamos que sea positivo
                if (numero > 0)
                    return true;
            }

            throw new ValorInvalidoException();
        }

        public static bool Nombre(string strNombre)
        {
            if (Regex.Match(strNombre, "^[A-Za-z ]+$").Success)
                return true;

            throw new NombreInvalidoException();
        }

        public static bool Nombre_Producto(string strNombre)
        {
            if (Regex.Match(strNombre, "^[a-zA-Z0-9 ]*$").Success)
                return true;

            throw new NombreInvalidoException();
        }

        public static bool Username(string strUser)
        {
            if (Regex.Match(strUser, "^(?=.{5,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$").Success)
                return true;

            throw new UsuarioInvalidoException();
        }

        public static bool Fecha(string strFecha)
        {
            DateTime fecha;
            return DateTime.TryParse(strFecha, out fecha);
        }

        #endregion

    }

    public class ValorInvalidoException : Exception
    {
    }

    public class NombreInvalidoException : Exception
    {
    }

    public class UsuarioInvalidoException : Exception
    {
    }

    public class PasswordInvalidoException : Exception
    {
    }

    public class CategoriaInvalidaException : Exception
    {
    }

    public class ClienteSinDineroExcepcion : Exception
    {
    }
}
