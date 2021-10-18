namespace PetShopCore
{
    public class Empleado : Usuario
    {
        //Atributos
        protected int idEmpleado;
        protected string user;
        protected string password;

        //Ultimo id Utilizado
        protected static int lastId = 1;


        #region CONSTRUCTORES

        /// <summary>
        /// Constructor con id autoincremental
        /// </summary>
        public Empleado(string nombre, string apellido, string user, string password) : base(nombre, apellido)
        {
            idEmpleado = lastId++;
            User = user;
            Password = password;
        }

        /// <summary>
        /// Constructor con id indicado (Se utiliza para las transformaciones de admin a empleado y que este mantenga su ID)
        /// </summary>
        public Empleado(int idEmpleado, string nombre, string apellido, string user, string password) : base(nombre, apellido)
        {
            IdEmpleado = idEmpleado;
            User = user;
            Password = password;
        }

        #endregion


        #region PROPIEDADES

        public int IdEmpleado
        {
            get
            {
                return idEmpleado;
            }
            set
            {
                if (Validaciones.Int_Unsigned(value.ToString()))
                    idEmpleado = value;
            }
        }

        public string User
        {
            get
            {
                return user;
            }
            set
            {
                if (Validaciones.Username(value))
                    user = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (Validaciones.Username(value))
                    password = value;
            }
        }

        #endregion


        #region SOBRECARGA DE OPERADORES

        /// <summary>
        /// Un empleado es igual a otro si sus identificadores son iguales
        /// </summary>
        public static bool operator ==(Empleado empleadoA, Empleado empleadoB)
        {
            return (empleadoA.idEmpleado == empleadoB.idEmpleado);
        }

        /// <summary>
        /// Un empleado es distinto de otro si sus identificadores son distintos
        /// </summary>
        public static bool operator !=(Empleado empleadoA, Empleado empleadoB)
        {
            return (empleadoA.idEmpleado == empleadoB.idEmpleado);
        }

        #endregion
    }
}