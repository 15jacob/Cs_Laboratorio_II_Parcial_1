using PetShopCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratorio_II_1er_Parcial___Pet_Shop
{
    public partial class Form_Cargar_Venta : Form
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto del Form, dentro del mismo determino si esta o no activado el modo oscuro
        /// </summary>
        public Form_Cargar_Venta()
        {
            InitializeComponent();

            //Cargamos el ComboBox de Clientes y de Productos
            Cargar_Clientes(Tienda.clientes);
            Cargar_Productos(Tienda.productos);

            if (Form_Administracion.modoOscuro)
            {
                //General
                BackColor = Color.FromArgb(20, 20, 20);

                txtPrecio.BackColor = Color.FromArgb(50, 50, 50);
                txtPrecio.ForeColor = Color.White;

                txtSaldo.BackColor = Color.FromArgb(50, 50, 50);
                txtSaldo.ForeColor = Color.White;

                txtStock.BackColor = Color.FromArgb(50, 50, 50);
                txtStock.ForeColor = Color.White;

                txtTotal.BackColor = Color.FromArgb(50, 50, 50);
                txtTotal.ForeColor = Color.White;

                lblEnvio.ForeColor = Color.White;
                cbxEnvioMiniflete.ForeColor = Color.White;
                cbxEnvioMoto.ForeColor = Color.White;

                txtDistancia.BackColor = Color.FromArgb(50, 50, 50);
                txtDistancia.ForeColor = Color.White;

                btnConfirmar.BackColor = Color.FromArgb(50, 50, 50);
                btnConfirmar.ForeColor = Color.White;

                btnCancelar.BackColor = Color.FromArgb(50, 50, 50);
                btnCancelar.ForeColor = Color.White;
            }
            else
            {
                //General
                BackColor = Color.FromArgb(200, 113, 113);

                txtPrecio.BackColor = Color.White;
                txtPrecio.ForeColor = Color.Black;

                txtSaldo.BackColor = Color.White;
                txtSaldo.ForeColor = Color.Black;

                txtStock.BackColor = Color.White;
                txtStock.ForeColor = Color.Black;

                txtTotal.BackColor = Color.White;
                txtTotal.ForeColor = Color.Black;

                lblEnvio.ForeColor = Color.White;
                cbxEnvioMiniflete.ForeColor = Color.Black;
                cbxEnvioMoto.ForeColor = Color.Black;

                txtDistancia.BackColor = Color.White;
                txtDistancia.ForeColor = Color.Black;

                btnConfirmar.BackColor = Color.White;
                btnConfirmar.ForeColor = Color.Black;

                btnCancelar.BackColor = Color.White;
                btnCancelar.ForeColor = Color.Black;
            }
        }

        #endregion


        #region CARGAS

        /// <summary>
        /// Toma un diccionario de clientes los carga en el combobox
        /// </summary>
        private void Cargar_Clientes(Dictionary<int, Cliente> listaClientes)
        {
            foreach (KeyValuePair<int, Cliente> clienteCargado in listaClientes)
            {
                cmbCliente.Items.Add(clienteCargado.Value);
            }
        }

        /// <summary>
        /// Toma una lista de productos los carga en el combobox
        /// </summary>
        private void Cargar_Productos(List<Producto> listaProductos)
        {
            foreach (Producto productoCargado in listaProductos)
            {
                cmbProducto.Items.Add(productoCargado);
            }
        }

        #endregion


        #region EVENTOS

        /// <summary>
        /// Cada vez que se cambie de cliente, se actualizaran los datos
        /// y se recalculara el envio llamando al evento numCantidad_ValueChanged
        /// </summary>
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = (Cliente)cmbCliente.SelectedItem;
            txtSaldo.Text = clienteSeleccionado.Saldo.ToString();
            txtDistancia.Text = clienteSeleccionado.KmDistancia.ToString();

            //Reseteamos los checkbox del medio de envio
            cbxEnvioMoto.Checked = false;
            cbxEnvioMiniflete.Checked = false;

            //Y marcamos unicamente el que corresponda en base a la distancia
            if (clienteSeleccionado.KmDistancia > 50)
                cbxEnvioMiniflete.Checked = true;
            else
                cbxEnvioMoto.Checked = true;

            if (cmbProducto.SelectedIndex != -1)
            {
                numCantidad.Enabled = true;
                numCantidad_ValueChanged(sender, e);
            }
        }

        /// <summary>
        /// Cada vez que se cambie de producto, se actualizaran los datos
        /// y se recalculara el envio llamando al evento numCantidad_ValueChanged
        /// </summary>
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;
            txtPrecio.Text = productoSeleccionado.Precio.ToString();
            txtStock.Text = productoSeleccionado.Stock.ToString();
            numCantidad.Maximum = productoSeleccionado.Stock;

            if (cmbCliente.SelectedIndex != -1)
            {
                numCantidad.Enabled = true;
                numCantidad_ValueChanged(sender, e);
            }
        }

        /// <summary>
        /// Cada vez que se cambie la cantidad, se recalculara el precio total
        /// y el tipo de transporte para el envio
        /// </summary>
        private void numCantidad_ValueChanged(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(numCantidad.Value);
            float precio = float.Parse(txtPrecio.Text);
            int stock = int.Parse(txtStock.Text);
            int kmDistancia = int.Parse(txtDistancia.Text);
            int costoTransporte = 0;

            if (cbxEnvioMoto.Checked)
                costoTransporte = 200;

            if (cbxEnvioMiniflete.Checked)
                costoTransporte = 500;

            //Si la cantidad es menor que el Stock y mayor a 0, podemos calcular un total
            if (cantidad > 0 && cantidad <= stock)
                txtTotal.Text = (cantidad * precio * (kmDistancia * 0.005) + costoTransporte).ToString("N2");
        }

        /// <summary>
        /// Intentaremos con los datos provistos, realizar la venta
        /// Esperamos una excepcion en caso de que el cliente no tenga dinero suficiente
        /// </summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Cliente clienteSeleccionado = (Cliente)cmbCliente.SelectedItem;
            Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;
            int cantidadSeleccionada = Convert.ToInt32(numCantidad.Value);
            double total = double.Parse(txtTotal.Text);

            try
            {
                if (cantidadSeleccionada > 0)
                {
                    if (Tienda.Vender_Producto(clienteSeleccionado, productoSeleccionado, cantidadSeleccionada, total))
                        Exito();
                    else
                        Error();
                }
            }
            catch(ClienteSinDineroExcepcion excepcion)
            {
                MessageBox.Show("El cliente no tiene suficiente dinero");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion


        #region METODOS

        private void Exito()
        {
            MessageBox.Show("Venta realizada!", "Exito!");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Error()
        {
            MessageBox.Show("No se ha podido realizar la venta!", "Error");
        }

        #endregion
    }
}
