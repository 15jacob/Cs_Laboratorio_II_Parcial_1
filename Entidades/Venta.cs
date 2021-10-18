using System;

namespace PetShopCore
{
    public class Venta
    {
        //Atributos
        int idCliente;
        int idProducto;
        int cantidad;
        double costo;
        DateTime fecha;


        #region CONSTRUCTORES

        /// <summary>
        /// Constructor sin fecha (Se utiliza para todas las ventas que son creadas en tiempo de ejecucion)
        /// De esa forma la fecha se coloca como un timestamp del momento en que se efectua la compra
        /// </summary>
        public Venta(int idCliente, int idProducto, int cantidad, double costo)
        {
            this.idCliente = idCliente;
            this.idProducto = idProducto;
            this.cantidad = cantidad;
            this.costo = costo;
            fecha = DateTime.Now;
        }

        /// <summary>
        /// Constructor con fecha (Se utiliza para las ventas de un registro pasado o hardcodeadas, podria utilizarse para cargar ventas desde un archivo)
        /// </summary>
        public Venta(int idCliente, int idProducto, int cantidad, double costo, string fecha) : this(idCliente, idProducto, cantidad, costo)
        {
            Fecha = DateTime.Parse(fecha);
        }

        #endregion


        #region PROPIEDADES

        public int IdProducto
        {
            get
            {
                return idProducto;
            }
        }

        public int IdCliente
        {
            get
            {
                return idCliente;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
        }

        public double Costo
        {
            get
            {
                return costo;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                if (Validaciones.Fecha(value.ToString()))
                    fecha = value;
            }
        }

        #endregion
    }
}
