using System.Collections.Generic;

namespace PetShopCore
{
    public static class Tienda
    {
        //Atributos
        public static string nombreTienda = "El Perro Usurero";

        public static Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();
        public static List<Empleado> empleados = new List<Empleado>();
        public static List<Producto> productos = new List<Producto>();
        public static Stack<Venta> ventas = new Stack<Venta>();


        #region CONSTRUCTORES

        static Tienda()
        {
        }

        #endregion


        #region METODOS

        /// <summary>
        /// Toma un cliente, un producto, una cantidad y un total,
        /// si el usuario tiene saldo suficiente para comprar ese producto en base al total indicado,
        /// se efectua la compra y se descuentan del stock y saldos
        /// 
        /// Lanza una excepcion si el cliente no tiene dinero suficiente
        /// </summary>
        public static bool Vender_Producto(Cliente cliente, Producto producto, int cantidad, double total)
        {
            if (producto.Stock >= cantidad && cliente.Saldo >= total)
            {
                producto.Stock -= cantidad;
                cliente.Saldo -= total;
                ventas.Push(new Venta(cliente.IdCliente, producto.IdProducto, cantidad, total));

                return true;
            }

            throw new ClienteSinDineroExcepcion();
        }

        /// <summary>
        /// Toma un usuario y una contraseña, y trata de matchearla con algun empleado en la lista
        /// Si fue encontrado, devuelve al objeto empleado
        /// Sino, tirara una excepcion de usuario invalido
        /// </summary>
        public static Empleado Log_Empleado(string user, string password)
        {
            foreach (Empleado empleadoCargado in empleados)
            {
                if (empleadoCargado.User == user && empleadoCargado.Password == password)
                    return empleadoCargado;
            }

            throw new UsuarioInvalidoException();
        }

        /// <summary>
        /// Toma un id y lo busca en la lista de clientes, si fue encontrado lo devuelve
        /// Sino devuelve nulo
        /// </summary>
        public static Cliente GetCliente(int idCliente)
        {
            foreach (KeyValuePair<int, Cliente > clienteCargado in clientes)
            {
                if (clienteCargado.Value.IdCliente == idCliente)
                    return clienteCargado.Value;
            }

            return null;
        }

        /// <summary>
        /// Toma un id y lo busca en la lista de empleados, si fue encontrado lo devuelve
        /// Sino devuelve nulo
        /// </summary>
        public static Empleado GetEmpleado(int idEmpleado)
        {
            foreach (Empleado empleadoCargado in empleados)
            {
                if (empleadoCargado.IdEmpleado == idEmpleado)
                    return empleadoCargado;
            }

            return null;
        }

        /// <summary>
        /// Toma un id y lo busca en la lista de productos, si fue encontrado lo devuelve
        /// Sino devuelve nulo
        /// </summary>
        public static Producto GetProducto(int idProducto)
        {
            foreach (Producto productoCargado in productos)
            {
                if (productoCargado.IdProducto == idProducto)
                    return productoCargado;
            }

            return null;
        }

        public static bool CheckUsername(string user)
        {
            foreach (Empleado empleadoCargado in empleados)
            {
                if (empleadoCargado.User.ToLower() == user.ToLower())
                    return false;
            }

            return false;
        }

        /// <summary>
        /// Toma un objeto de tipo Empleado, crea a un administrador con sus datos (Incluido el ID)
        /// y borra al empleado original de la lista
        /// 
        /// Como chequeo, busca en la lista de empleados a un empleado con el id indicado,
        /// y si ahora es administrador, devuelve true
        /// </summary>
        public static bool ConvertirEmpleadoEnAdmin(Empleado empleado)
        {
            Administrador administradorAux;

            //Creamos al administrador con los datos del empleado
            empleados.Add(new Administrador(empleado.IdEmpleado, empleado.Nombre, empleado.Apellido, empleado.User, empleado.Password));

            //Sacamos al empleado de la lista
            empleados.Remove(empleado);

            //Obtengo a un empleado que tenga el mismo ID que el empleado que mandamos a ascender
            administradorAux = (Administrador)GetEmpleado(empleado.IdEmpleado);

            //Si existe y es un administrador, devolvemos true
            if (administradorAux is Administrador)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Toma un objeto de tipo Administrador, crea a un empleado con sus datos (Incluido el ID)
        /// y borra al Administrador original de la lista
        /// 
        /// Como chequeo, busca en la lista de empleados a un empleado con el id indicado,
        /// y si ahora no es administrador, devuelve true
        /// </summary>
        public static bool ConvertirAdminEnEmpleado(Administrador administrador)
        {
            Empleado empleadoAux;

            //Creamos al empleado con los datos del administrador
            empleados.Add(new Empleado(administrador.IdEmpleado, administrador.Nombre, administrador.Apellido, administrador.User, administrador.Password));

            //Sacamos al administrador de la lista
            empleados.Remove(administrador);

            //Obtengo a un empleado que tenga el mismo ID que el administrador que mandamos a degradar
            empleadoAux = GetEmpleado(administrador.IdEmpleado);

            //Si existe y es un empleado devolvemos true
            if (empleadoAux is not Administrador)
                return true;
            else
                return false;
        }

        #endregion
    }
}
