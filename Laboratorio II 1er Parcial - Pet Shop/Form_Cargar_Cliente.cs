using PetShopCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratorio_II_1er_Parcial___Pet_Shop
{
    public partial class Form_Cargar_Cliente : Form
    {
        private Cliente clienteEditar;

        /// <summary>
        /// Constructor por defecto del Form, dentro del mismo determino si esta o no activado el modo oscuro
        /// </summary>
        public Form_Cargar_Cliente()
        {
            InitializeComponent();

            if (Form_Administracion.modoOscuro)
            {
                //General
                BackColor = Color.FromArgb(20, 20, 20);

                txtNombre.BackColor = Color.FromArgb(50, 50, 50);
                txtNombre.ForeColor = Color.White;

                txtApellido.BackColor = Color.FromArgb(50, 50, 50);
                txtApellido.ForeColor = Color.White;

                txtSaldo.BackColor = Color.FromArgb(50, 50, 50);
                txtSaldo.ForeColor = Color.White;

                btnConfirmar.BackColor = Color.FromArgb(50, 50, 50);
                btnConfirmar.ForeColor = Color.White;

                btnCancelar.BackColor = Color.FromArgb(50, 50, 50);
                btnCancelar.ForeColor = Color.White;
            }
            else
            {
                //General
                BackColor = Color.FromArgb(200, 113, 113);

                txtNombre.BackColor = Color.White;
                txtNombre.ForeColor = Color.Black;

                txtApellido.BackColor = Color.White;
                txtApellido.ForeColor = Color.Black;

                txtSaldo.BackColor = Color.White;
                txtSaldo.ForeColor = Color.Black;

                btnConfirmar.BackColor = Color.White;
                btnConfirmar.ForeColor = Color.Black;

                btnCancelar.BackColor = Color.White;
                btnCancelar.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Constructor para el modo "editar cliente". Si se indico un cliente valido, se cargaran los datos del mismo en los campos
        /// </summary>
        public Form_Cargar_Cliente(Cliente cliente) : this()
        {
            if (cliente is not null)
            {
                //Seteamos el titulo de la ventana en "editar"
                Text = "Editar Cliente";

                //Cargamos al cliente en el formulario
                clienteEditar = cliente;

                //Cargamos los datos del cliente
                txtNombre.Text = clienteEditar.Nombre;
                txtApellido.Text = clienteEditar.Apellido;
                txtSaldo.Text = clienteEditar.Saldo.ToString();
            }
            else
                clienteEditar = null;
        }

        /// <summary>
        /// Intentaremos con los datos provistos, validar la informacion del cliente.
        /// Si alguna validacion falla, se esperan excepciones
        /// </summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Por defecto ningun warning se mostrara
            lblWarningNombre.Visible = false;
            lblWarningSaldo.Visible = false;

            try
            {
                Validaciones.Nombre(txtNombre.Text);
                Validaciones.Nombre(txtApellido.Text);

                //Chequeamos que el saldo haya sido especificado, caso contrario se seteara en 0
                if (txtSaldo.Text != string.Empty)
                    Validaciones.Double_Unsigned(txtSaldo.Text);
                else
                    txtSaldo.Text = "0";

                //Si estamos en modo editar, trabajamos sobre el cliente indicado, sino, se crea una nueva instancia de cliente
                if (clienteEditar is not null)
                {
                    clienteEditar.Nombre = txtNombre.Text;
                    clienteEditar.Apellido = txtApellido.Text;
                    clienteEditar.Saldo = double.Parse(txtSaldo.Text);
                }
                else
                    Tienda.clientes.Add(Tienda.clientes.Keys.Count + 1, new Cliente(txtNombre.Text, txtApellido.Text, double.Parse(txtSaldo.Text)));

                Exito();
            }
            catch (NombreInvalidoException excepcion)
            {
                MessageBox.Show("Nombre o Apellido invalidos");
                lblWarningNombre.Visible = true;
            }
            catch (ValorInvalidoException excepcion)
            {
                MessageBox.Show("Ese saldo no es valido");
                lblWarningSaldo.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Exito()
        {
            DialogResult = DialogResult.OK;
            MessageBox.Show("Cliente cargado exitosamente!", "Exito!");
            Close();
        }
    }
}
