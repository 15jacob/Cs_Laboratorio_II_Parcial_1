namespace PetShopCore
{
    public class Producto
    {
        //Atributos
        private int idProducto;
        private string nombre;
        private int stock;
        private double precio;
        private ECategoria categoria;
        private int peso;

        //Ultimo id Utilizado
        private static int lastId = 1;


        #region ENUMERADOS

        public enum ECategoria
        {
            Alimento,
            Juguete,
            Medicina,
            Cuidado,
            Jaula,
            Bolso,
            Correa,
            Cama,
            Casa
        }

        #endregion


        #region CONSTRUCTORES

        public Producto(string nombre, int stock, double precio, ECategoria categoria, int peso)
        {
            idProducto = lastId++;
            Nombre = nombre;
            Stock = stock;
            Precio = precio;
            this.categoria = categoria;
            Peso = peso;
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

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (Validaciones.Nombre_Producto(value.ToString()))
                    nombre = value.ToString();
                else
                {
                    NombreInvalidoException excepcion = new NombreInvalidoException();
                    throw excepcion;
                }
            }
        }

        public int Stock
        {
            get
            {
                return stock;
            }
            set
            {
                if (Validaciones.Int(value.ToString()))
                    stock = value;
                else
                {
                    ValorInvalidoException excepcion = new ValorInvalidoException();
                    throw excepcion;
                }
            }
        }

        public double Precio
        {
            get
            {
                return precio;
            }
            set
            {
                if (Validaciones.Double(value.ToString()))
                    precio = value;
                else
                {
                    ValorInvalidoException excepcion = new ValorInvalidoException();
                    throw excepcion;
                }
            }
        }

        public ECategoria Categoria
        {
            get
            {
                return categoria;
            }
            set
            {
                categoria = value;
            }
        }

        public int Peso
        {
            get
            {
                return peso;
            }
            set
            {
                if (Validaciones.Double(value.ToString()))
                    peso = value;
                else
                {
                    ValorInvalidoException excepcion = new ValorInvalidoException();
                    throw excepcion;
                }
            }
        }

        #endregion


        #region METODOS

        /// <summary>
        ///  Se utiliza principalmente para, al cargar el producto en un combobox, que este se muestre en el formato "id. nombre"
        /// </summary>
        public override string ToString()
        {
            return $"{IdProducto}. {Nombre}";
        }

        #endregion


        #region SOBRECARGA DE OPERADORES

        /// <summary>
        /// Un producto es igual a otro si sus identificadores son iguales
        /// </summary>
        public static bool operator ==(Producto productoA, Producto productoB)
        {
            return (productoA.IdProducto == productoB.IdProducto);
        }

        /// <summary>
        /// Un producto es distinto de otro si sus identificadores son distintos
        /// </summary>
        public static bool operator !=(Producto productoA, Producto productoB)
        {
            return (productoA.IdProducto == productoB.IdProducto);
        }

        #endregion
    }
}
