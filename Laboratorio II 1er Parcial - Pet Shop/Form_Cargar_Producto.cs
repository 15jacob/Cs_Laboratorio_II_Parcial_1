using PetShopCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratorio_II_1er_Parcial___Pet_Shop
{
    public partial class Form_Cargar_Producto : Form
    {
        private Producto productoEditar;

        /// <summary>
        /// Constructor por defecto del Form, dentro del mismo determino si esta o no activado el modo oscuro
        /// </summary>
        public Form_Cargar_Producto()
        {
            InitializeComponent();

            //Cargamos el ComboBox de Categorias
            Cargar_Categorias();

            if (Form_Administracion.modoOscuro)
            {
                //General
                BackColor = Color.FromArgb(20, 20, 20);

                txtProducto.BackColor = Color.FromArgb(50, 50, 50);
                txtProducto.ForeColor = Color.White;

                txtPrecio.BackColor = Color.FromArgb(50, 50, 50);
                txtPrecio.ForeColor = Color.White;

                txtStock.BackColor = Color.FromArgb(50, 50, 50);
                txtStock.ForeColor = Color.White;

                txtPeso.BackColor = Color.FromArgb(50, 50, 50);
                txtPeso.ForeColor = Color.White;

                cmbCategoria.BackColor = Color.FromArgb(50, 50, 50);
                cmbCategoria.ForeColor = Color.White;

                btnConfirmar.BackColor = Color.FromArgb(50, 50, 50);
                btnConfirmar.ForeColor = Color.White;

                btnCancelar.BackColor = Color.FromArgb(50, 50, 50);
                btnCancelar.ForeColor = Color.White;
            }
            else
            {
                //General
                BackColor = Color.FromArgb(200, 113, 113);

                txtProducto.BackColor = Color.White;
                txtProducto.ForeColor = Color.Black;

                txtPrecio.BackColor = Color.White;
                txtPrecio.ForeColor = Color.Black;

                txtStock.BackColor = Color.White;
                txtStock.ForeColor = Color.Black;

                txtPeso.BackColor = Color.White;
                txtPeso.ForeColor = Color.Black;

                cmbCategoria.BackColor = Color.White;
                cmbCategoria.ForeColor = Color.Black;

                btnConfirmar.BackColor = Color.White;
                btnConfirmar.ForeColor = Color.Black;

                btnCancelar.BackColor = Color.White;
                btnCancelar.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Constructor para el modo "editar producto". Si se indico un producto valido, se cargaran los datos del mismo en los campos
        /// </summary>
        public Form_Cargar_Producto(Producto producto) : this()
        {
            if (producto is not null)
            {
                //Seteamos el titulo de la ventana en "editar"
                Text = "Editar Producto";

                //Cargamos al producto en el form
                productoEditar = producto;

                //Cargamos los datos del producto
                txtProducto.Text = productoEditar.Nombre;
                cmbCategoria.SelectedItem = productoEditar.Categoria;
                txtPrecio.Text = productoEditar.Precio.ToString();
                txtStock.Text = productoEditar.Stock.ToString();
                txtPeso.Text = productoEditar.Peso.ToString();
            }
        }

        /// <summary>
        /// Busca el Enumerado de Categorias de Productos y las carga en un combobox.
        /// Hace uso de un array auxiliar
        /// </summary>
        private void Cargar_Categorias()
        {
            //Conseguimos las categorias del enumerado y las metemos en un array
            Array arrayCategorias = Enum.GetValues(typeof(Producto.ECategoria));

            foreach (Producto.ECategoria categoria in arrayCategorias)
            {
                cmbCategoria.Items.Add(categoria);
            }
        }

        /// <summary>
        /// Intentaremos con los datos provistos, validar la informacion del producto.
        /// Si alguna validacion falla, se esperan excepciones
        /// </summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Por defecto ningun warning se mostrara
            lblWarningProducto.Visible = false;
            lblWarningCategoria.Visible = false;
            lblWarningStock.Visible = false;
            lblWarningPrecio.Visible = false;
            lblWarningPeso.Visible = false;

            try
            {
                Validaciones.Nombre(txtProducto.Text);

                if (cmbCategoria.SelectedIndex == -1)
                    throw new CategoriaInvalidaException();

                //Chequeamos que el stock haya sido especificado, caso contrario se seteara en 0
                if (txtStock.Text != string.Empty)
                    Validaciones.Double_Unsigned(txtStock.Text);
                else
                    txtStock.Text = "0";

                Validaciones.Double_Unsigned(txtPrecio.Text);
                Validaciones.Int_Unsigned(txtPeso.Text);

                if (productoEditar is not null)
                {
                    productoEditar.Nombre = txtProducto.Text;
                    productoEditar.Categoria = (Producto.ECategoria)cmbCategoria.SelectedItem;
                    productoEditar.Precio = double.Parse(txtPrecio.Text);
                    productoEditar.Stock = int.Parse(txtStock.Text);
                    productoEditar.Peso = int.Parse(txtPeso.Text);
                }
                else
                    Tienda.productos.Add(new Producto(txtProducto.Text, int.Parse(txtStock.Text), double.Parse(txtPrecio.Text), (Producto.ECategoria)cmbCategoria.SelectedItem, int.Parse(txtPeso.Text)));

                Exito();
            }
            catch(NombreInvalidoException excepcion)
            {
                MessageBox.Show("Nombre o Apellido invalidos");
                lblWarningProducto.Visible = true;
            }
            catch(CategoriaInvalidaException excepcion)
            {
                MessageBox.Show("Tenes que seleccionar una categoria");
                lblWarningCategoria.Visible = true;
            }
            catch(ValorInvalidoException excepcion)
            {
                MessageBox.Show("Revisa el stock, precio y peso por favor");
                lblWarningStock.Visible = true;
                lblWarningPrecio.Visible = true;
                lblWarningPeso.Visible = true;
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
            MessageBox.Show("Producto cargado exitosamente!", "Exito!");
            Close();
        }
    }
}
