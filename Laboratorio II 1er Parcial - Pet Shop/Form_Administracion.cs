using PetShopCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratorio_II_1er_Parcial___Pet_Shop
{
    public partial class Form_Administracion : Form
    {
        public static bool modoOscuro;
        Empleado empleadoLog;

        #region CONSTRUCTORES

        /// <summary>
        /// Al abrir el panel administrativo configuraremos ciertos aspectos como el nombre del empleado y su usuario en la parte superior
        /// Ademas, nombraremos la ventana del formulario con un "nombre de tienda - Administracion"
        /// Al final, cargaremos las listas de Clientes, Productos, Ventas y (Si el empleado es administrador, empleados)
        /// </summary>
        public Form_Administracion(Empleado empleadoLog)
        {
            InitializeComponent();

            //Copiamos al Empleado para tenerlo en una variable local
            this.empleadoLog = empleadoLog;

            //Por defecto el modo oscuro estara apagado
            modoOscuro = false;

            //Seteamos el nombre de la ventana como el nombre de la tienda seguido de "administracion"
            Text = $"{Tienda.nombreTienda} - Administracion";

            //Seteamos el Label con el nombre y usuario para mostrar en el menu de bienvenida
            lblNombre.Text = $"{empleadoLog.Nombre} {empleadoLog.Apellido}";
            lblUsername.Text = empleadoLog.User;

            //Cargamos las listas de clientes, productos y ventas
            Cargar_Clientes(Tienda.clientes);
            Cargar_Productos(Tienda.productos);
            Cargar_Ventas(Tienda.ventas);

            //Si el usuario logueado es Administrador, cargamos la lista de empleados tambien
            if (empleadoLog is Administrador)
            {
                btnVentanaEmpleados.Visible = true;
                Cargar_Empleados(Tienda.empleados);
            }
        }

        #endregion


        #region CARGA DE LISTAS

        /// <summary>
        /// Toma un diccionario de clientes y va cargando los datos de cada uno en las filas de la tabla
        /// </summary>
        public void Cargar_Clientes(Dictionary<int, Cliente> listaClientes)
        {
            int i;

            //Siempre que carguemos la lista vamos a primero limpiarla
            dataGridViewClientes.Rows.Clear();

            foreach (KeyValuePair<int, Cliente> clienteCargado in listaClientes)
            {
                i = dataGridViewClientes.Rows.Add();
                dataGridViewClientes.Rows[i].Cells[0].Value = clienteCargado.Value.IdCliente;
                dataGridViewClientes.Rows[i].Cells[1].Value = clienteCargado.Value.Nombre;
                dataGridViewClientes.Rows[i].Cells[2].Value = clienteCargado.Value.Apellido;
                dataGridViewClientes.Rows[i].Cells[3].Value = $"${clienteCargado.Value.Saldo}.-";
            }
        }

        /// <summary>
        /// Toma un diccionario de empleados y va cargando los datos de cada uno en las filas de la tabla
        /// </summary>
        public void Cargar_Empleados(List<Empleado> listaEmpleados)
        {
            int i;

            //Siempre que carguemos la lista vamos a primero limpiarla
            dataGridViewEmpleados.Rows.Clear();

            foreach (Empleado empleadoCargado in listaEmpleados)
            {
                i = dataGridViewEmpleados.Rows.Add();
                dataGridViewEmpleados.Rows[i].Cells[0].Value = empleadoCargado.IdEmpleado;
                dataGridViewEmpleados.Rows[i].Cells[1].Value = empleadoCargado.User;
                dataGridViewEmpleados.Rows[i].Cells[2].Value = empleadoCargado.Nombre;
                dataGridViewEmpleados.Rows[i].Cells[3].Value = empleadoCargado.Apellido;

                //Dependiendo si es administrador o no, le colocamos una etiqueta diferente
                if (empleadoCargado is Administrador)
                    dataGridViewEmpleados.Rows[i].Cells[4].Value = "ADMIN";
                else
                    dataGridViewEmpleados.Rows[i].Cells[4].Value = "EMPLEADO";
            }
        }

        /// <summary>
        /// Toma un diccionario de productos y va cargando los datos de cada uno en las filas de la tabla
        /// </summary>
        public void Cargar_Productos(List<Producto> listaProductos)
        {
            int i;

            //Siempre que carguemos la lista vamos a primero limpiarla
            dataGridViewProductos.Rows.Clear();

            foreach (Producto productoCargado in listaProductos)
            {
                i = dataGridViewProductos.Rows.Add();
                dataGridViewProductos.Rows[i].Cells[0].Value = productoCargado.IdProducto;
                dataGridViewProductos.Rows[i].Cells[1].Value = productoCargado.Nombre;
                dataGridViewProductos.Rows[i].Cells[2].Value = productoCargado.Categoria;
                dataGridViewProductos.Rows[i].Cells[3].Value = productoCargado.Stock;
                dataGridViewProductos.Rows[i].Cells[4].Value = $"${productoCargado.Precio}.-";
                dataGridViewProductos.Rows[i].Cells[5].Value = $"{productoCargado.Peso} gr";
            }
        }

        /// <summary>
        /// Toma un diccionario de ventas y va cargando los datos de cada uno en las filas de la tabla
        /// </summary>
        public void Cargar_Ventas(Stack<Venta> listaVentas)
        {
            Cliente clienteAux;
            Producto productoAux;
            int i;

            //Siempre que carguemos la lista vamos a primero limpiarla
            dataGridViewVentas.Rows.Clear();

            foreach (Venta ventaCargada in listaVentas)
            {
                //Conseguimos el Cliente y el Producto indicado en la venta
                clienteAux = Tienda.GetCliente(ventaCargada.IdCliente);
                productoAux = Tienda.GetProducto(ventaCargada.IdProducto);

                //Por seguridad corroboramos que ese cliente existe antes de listar la venta
                if (clienteAux is not null && productoAux is not null)
                {
                    i = dataGridViewVentas.Rows.Add();
                    dataGridViewVentas.Rows[i].Cells[0].Value = ventaCargada.IdProducto;
                    dataGridViewVentas.Rows[i].Cells[1].Value = productoAux.Nombre;
                    dataGridViewVentas.Rows[i].Cells[2].Value = clienteAux.Nombre;
                    dataGridViewVentas.Rows[i].Cells[3].Value = clienteAux.Apellido;
                    dataGridViewVentas.Rows[i].Cells[4].Value = ventaCargada.Cantidad;
                    dataGridViewVentas.Rows[i].Cells[5].Value = $"${ventaCargada.Costo}.-";
                    dataGridViewVentas.Rows[i].Cells[6].Value = ventaCargada.Fecha;
                }
            }
        }

        #endregion


        #region EVENTOS

        //NAVEGACION PANELES
        private void btnVentanaVentas_Click(object sender, EventArgs e)
        {
            Esconder_Paneles(sender, e);
            Mostrar_Panel_Ventas(sender, e);
        }

        private void btnVentanaProductos_Click(object sender, EventArgs e)
        {
            Esconder_Paneles(sender, e);
            Mostrar_Panel_Productos(sender, e);
        }

        private void btnVentanaClientes_Click(object sender, EventArgs e)
        {
            Esconder_Paneles(sender, e);
            Mostrar_Panel_Clientes(sender, e);
        }

        private void btnVentanaEmpleados_Click(object sender, EventArgs e)
        {
            Esconder_Paneles(sender, e);
            Mostrar_Panel_Empleados(sender, e);
        }

        private void cbxModoOscuro_CheckedChanged(object sender, EventArgs e)
        {
            if (modoOscuro)
            {
                //General
                BackColor = Color.FromArgb(200, 113, 113);

                //Panel Ventas
                btnCargarVenta.BackColor = Color.White;
                btnCargarVenta.ForeColor = Color.Black;
                dataGridViewVentas.BackgroundColor = Color.White;

                //Panel Productos
                btnCargarProducto.BackColor = Color.White;
                btnCargarProducto.ForeColor = Color.Black;
                btnEditarProducto.BackColor = Color.White;
                btnEditarProducto.ForeColor = Color.Black;
                dataGridViewProductos.BackgroundColor = Color.White;

                //Panel Clientes
                btnCargarCliente.BackColor = Color.White;
                btnCargarCliente.ForeColor = Color.Black;
                btnEditarCliente.BackColor = Color.White;
                btnEditarCliente.ForeColor = Color.Black;
                dataGridViewClientes.BackgroundColor = Color.White;

                //Panel Empleados
                btnCargarEmpleado.BackColor = Color.White;
                btnCargarEmpleado.ForeColor = Color.Black;
                btnEditarEmpleado.BackColor = Color.White;
                btnEditarEmpleado.ForeColor = Color.Black;
                dataGridViewEmpleados.BackgroundColor = Color.White;

                modoOscuro = false;
            }
            else
            {
                //General
                BackColor = Color.FromArgb(20, 20, 20);

                //Panel Ventas
                btnCargarVenta.BackColor = Color.FromArgb(50, 50, 50);
                btnCargarVenta.ForeColor = Color.White;
                dataGridViewVentas.BackgroundColor = Color.FromArgb(50, 50, 50);

                //Panel Productos
                btnCargarProducto.BackColor = Color.FromArgb(50, 50, 50);
                btnCargarProducto.ForeColor = Color.White;
                btnEditarProducto.BackColor = Color.FromArgb(50, 50, 50);
                btnEditarProducto.ForeColor = Color.White;
                dataGridViewProductos.BackgroundColor = Color.FromArgb(50, 50, 50);

                //Panel Clientes
                btnCargarCliente.BackColor = Color.FromArgb(50, 50, 50);
                btnCargarCliente.ForeColor = Color.White;
                btnEditarCliente.BackColor = Color.FromArgb(50, 50, 50);
                btnEditarCliente.ForeColor = Color.White;
                dataGridViewClientes.BackgroundColor = Color.FromArgb(50, 50, 50);

                //Panel Empleados
                btnCargarEmpleado.BackColor = Color.FromArgb(50, 50, 50);
                btnCargarEmpleado.ForeColor = Color.White;
                btnEditarEmpleado.BackColor = Color.FromArgb(50, 50, 50);
                btnEditarEmpleado.ForeColor = Color.White;
                dataGridViewEmpleados.BackgroundColor = Color.FromArgb(50, 50, 50);

                modoOscuro = true;
            }
        }

        private void Form_Administracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show($"¿Seguro que desea salir, {empleadoLog.Nombre}?", "Close Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //Si el usuario indica que no quiere salir, se cancela el evento y se continua la ejecucion del programa
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        //FORMULARIOS DE CARGAS
        private void btnCargarVenta_Click(object sender, EventArgs e)
        {
            Form_Cargar_Venta form = new Form_Cargar_Venta();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
                Cargar_Ventas(Tienda.ventas);
        }

        private void btnCargarEmpleado_Click(object sender, EventArgs e)
        {
            Form_Cargar_Empleado form = new Form_Cargar_Empleado();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
                Cargar_Empleados(Tienda.empleados);
        }

        private void btnCargarCliente_Click(object sender, EventArgs e)
        {
            Form_Cargar_Cliente form = new Form_Cargar_Cliente();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
                Cargar_Clientes(Tienda.clientes);
        }

        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            Form_Cargar_Producto form = new Form_Cargar_Producto();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
                Cargar_Productos(Tienda.productos);
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            //Tomamos el ID de la fila seleccionada y lo pasamos al metodo que nos consigue el cliente
            int idCliente = int.Parse(dataGridViewClientes.CurrentRow.Cells[0].Value.ToString());
            Cliente cliente = Tienda.GetCliente(idCliente);
            Form_Cargar_Cliente form;

            //Si se consiguio al cliente indicado, llamamos a abrir el formulario con sus datos
            if (cliente is not null)
            {
                form = new Form_Cargar_Cliente(cliente);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                    Cargar_Clientes(Tienda.clientes);
            }
        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            //Tomamos el ID de la fila seleccionada y lo pasamos al metodo que nos consigue el empleado
            int idEmpleado = int.Parse(dataGridViewEmpleados.CurrentRow.Cells[0].Value.ToString());
            Empleado empleado = Tienda.GetEmpleado(idEmpleado);
            Form_Cargar_Empleado form;

            //Si se consiguio al cliente indicado, llamamos a abrir el formulario con sus datos
            if (empleado is not null)
            {
                form = new Form_Cargar_Empleado(empleado);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                    Cargar_Empleados(Tienda.empleados);
            }
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            //Tomamos el ID de la fila seleccionada y lo pasamos al metodo que nos consigue el empleado
            int idProducto = int.Parse(dataGridViewProductos.CurrentRow.Cells[0].Value.ToString());
            Producto producto = Tienda.GetProducto(idProducto);
            Form_Cargar_Producto form;

            //Si se consiguio al cliente indicado, llamamos a abrir el formulario con sus datos
            if (producto is not null)
            {
                form = new Form_Cargar_Producto(producto);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                    Cargar_Productos(Tienda.productos);
            }
        }

        #endregion


        #region METODOS


        /// <summary>
        /// Esconde todos los paneles del formulario, se utiliza cada vez que se cambia de "seccion"
        /// </summary>
        private void Esconder_Paneles(object sender, EventArgs e)
        {
            dataGridViewVentas.Visible = false;
            btnCargarVenta.Visible = false;
            btnVentanaVentas.BackColor = Color.FromArgb(30, 30, 30);

            dataGridViewProductos.Visible = false;
            btnCargarProducto.Visible = false;
            btnEditarProducto.Visible = false;
            btnVentanaProductos.BackColor = Color.FromArgb(30, 30, 30);

            dataGridViewClientes.Visible = false;
            btnCargarCliente.Visible = false;
            btnEditarCliente.Visible = false;
            btnVentanaClientes.BackColor = Color.FromArgb(30, 30, 30);

            dataGridViewEmpleados.Visible = false;
            btnCargarEmpleado.Visible = false;
            btnEditarEmpleado.Visible = false;
            btnVentanaEmpleados.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void Mostrar_Panel_Ventas(object sender, EventArgs e)
        {
            dataGridViewVentas.Visible = true;
            btnCargarVenta.Visible = true;
            btnVentanaVentas.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void Mostrar_Panel_Productos(object sender, EventArgs e)
        {
            dataGridViewProductos.Visible = true;
            btnCargarProducto.Visible = true;
            btnEditarProducto.Visible = true;
            btnVentanaProductos.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void Mostrar_Panel_Clientes(object sender, EventArgs e)
        {
            dataGridViewClientes.Visible = true;

            //Solo el admin puede editar o dar de alta clientes
            if (empleadoLog is Administrador)
            {
                btnCargarCliente.Visible = true;
                btnEditarCliente.Visible = true;
            }

            btnVentanaClientes.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void Mostrar_Panel_Empleados(object sender, EventArgs e)
        {
            dataGridViewEmpleados.Visible = true;
            btnCargarEmpleado.Visible = true;
            btnEditarEmpleado.Visible = true;
            btnVentanaEmpleados.BackColor = Color.FromArgb(100, 100, 100);
        }

        #endregion

        
    }
}
