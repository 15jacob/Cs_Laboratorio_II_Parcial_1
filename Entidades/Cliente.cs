using System;

namespace PetShopCore
{
    public class Cliente : Usuario
    {
        //Atributos
        private int idCliente;
        private double saldo;
        private int kmDistancia;

        //Ultimo id Utilizado
        private static int lastId = 1;

        //Kilometros de Distancia para Randomizar
        private static Random numeroRandom = new Random();

        #region CONSTRUCTORES

        public Cliente(string nombre, string apellido) : base(nombre, apellido)
        {
            idCliente = lastId++;
            Saldo = 0;
            kmDistancia = numeroRandom.Next(0, 200);
        }

        public Cliente(string nombre, string apellido, double saldo) : this(nombre, apellido)
        {
            Saldo = saldo;
        }

        #endregion


        #region PROPIEDADES

        public int IdCliente
        {
            get
            {
                return idCliente;
            }
        }

        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                if (Validaciones.Double(value.ToString()))
                    saldo = value;
            }
        }

        public int KmDistancia
        {
            get
            {
                return kmDistancia;
            }
            set
            {
                if (Validaciones.Int_Unsigned(value.ToString()))
                    kmDistancia = value;
            }
        }

        #endregion


        #region METODOS

        /// <summary>
        ///  Se utiliza principalmente para, al cargar el cliente en un combobox, que este se muestre en el formato "id. nombre"
        /// </summary>
        public override string ToString()
        {
            return $"{IdCliente}. {Nombre} {Apellido}";
        }

        #endregion


        #region SOBRECARGA DE OPERADORES

        /// <summary>
        ///  Un cliente es igual a otro si sus identificadores son identicos
        /// </summary>
        public static bool operator ==(Cliente clienteA, Cliente clienteB)
        {
            return (clienteA.idCliente == clienteB.idCliente);
        }

        /// <summary>
        ///  Un cliente es distinto de otro si sus identificadores son diferentes
        /// </summary>
        public static bool operator !=(Cliente clienteA, Cliente clienteB)
        {
            return (clienteA.idCliente == clienteB.idCliente);
        }

        #endregion
    }
}
