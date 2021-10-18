using PetShopCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratorio_II_1er_Parcial___Pet_Shop
{
    public partial class Form_Cargar_Empleado : Form
    {
        private Empleado empleadoEditar;

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto del Form, dentro del mismo determino si esta o no activado el modo oscuro
        /// </summary>
        public Form_Cargar_Empleado()
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

                txtUser.BackColor = Color.FromArgb(50, 50, 50);
                txtUser.ForeColor = Color.White;

                txtPassword.BackColor = Color.FromArgb(50, 50, 50);
                txtPassword.ForeColor = Color.White;

                txtPassword2.BackColor = Color.FromArgb(50, 50, 50);
                txtPassword2.ForeColor = Color.White;

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

                txtUser.BackColor = Color.White;
                txtUser.ForeColor = Color.Black;

                txtPassword.BackColor = Color.White;
                txtPassword.ForeColor = Color.Black;

                txtPassword2.BackColor = Color.White;
                txtPassword2.ForeColor = Color.Black;

                btnConfirmar.BackColor = Color.White;
                btnConfirmar.ForeColor = Color.Black;

                btnCancelar.BackColor = Color.White;
                btnCancelar.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Constructor para el modo "editar empleado". Si se indico un empleado valido, se cargaran los datos del mismo en los campos
        /// </summary>
        public Form_Cargar_Empleado(Empleado empleado) : this()
        {
            if (empleado is not null)
            {
                //Seteamos el titulo de la ventana en "editar"
                Text = "Editar Empleado";

                //Cargamos al empleado en el formulario
                empleadoEditar = empleado;

                //Cargamos los datos del empleado
                txtNombre.Text = empleadoEditar.Nombre;
                txtApellido.Text = empleadoEditar.Apellido;
                txtUser.Text = empleadoEditar.User;
                txtPassword.Text = empleadoEditar.Password;
                txtPassword2.Text = empleadoEditar.Password;

                //Si es administrador tildamos el checkbox
                if (empleado is Administrador)
                    cbxAdmin.Checked = true;
            }
            else
                empleadoEditar = null;
        }

        #endregion

        #region EVENTOS

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Intentaremos con los datos provistos, validar la informacion del empleado.
        /// Si alguna validacion falla, se esperan excepciones
        /// </summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Por defecto ningun warning se mostrara
            lblWarningNombre.Visible = false;
            lblWarningUser.Visible = false;
            lblWarningPassword.Visible = false;

            try
            {
                Validaciones.Nombre(txtNombre.Text);
                Validaciones.Nombre(txtApellido.Text);
                Validaciones.Username(txtUser.Text);

                if (txtPassword.Text == string.Empty || txtPassword.Text != txtPassword2.Text)
                    throw new PasswordInvalidoException();

                //Si estamos en modo editar, trabajaremos sobre el empleado indicado
                ////caso contrario se creara una nueva instancia de empleado o administrador segun se haya marcado
                if (empleadoEditar is not null)
                {
                    empleadoEditar.Nombre = txtNombre.Text;
                    empleadoEditar.Apellido = txtApellido.Text;
                    empleadoEditar.User = txtUser.Text;
                    empleadoEditar.Password = txtPassword.Text;

                    //Si el checkbox esta marcado y no es un administrador, lo convertimos en tal
                    if (cbxAdmin.Checked && empleadoEditar is not Administrador)
                        Tienda.ConvertirEmpleadoEnAdmin(empleadoEditar);

                    //Si caso contrario, el checkbox no esta marcado y si es un admin, le revocamos el privilegio
                    if (!cbxAdmin.Checked && empleadoEditar is Administrador)
                        Tienda.ConvertirAdminEnEmpleado((Administrador)empleadoEditar);
                }
                else
                {
                    //Si es un empleado nuevo, tengo que chequear que el usuario no lo este ocupando alguien mas
                    if (!Tienda.CheckUsername(txtUser.Text))
                    {
                        //Si el campo es admin es chequeado, lo creo como administrador, sino, como empleado
                        if (cbxAdmin.Checked)
                            Tienda.empleados.Add(new Administrador(txtNombre.Text, txtApellido.Text, txtUser.Text, txtPassword.Text));
                        else
                            Tienda.empleados.Add(new Empleado(txtNombre.Text, txtApellido.Text, txtUser.Text, txtPassword.Text));
                    }
                    else
                        throw new UsuarioInvalidoException();
                }

                Exito();
            }
            catch (NombreInvalidoException excepcion)
            {
                MessageBox.Show("Nombre o Apellido invalidos");
                lblWarningNombre.Visible = true;
            }
            catch (UsuarioInvalidoException excepcion)
            {
                MessageBox.Show("Ese nombre de usuario ya esta siendo utilizado");
                lblWarningUser.Visible = true;
            }
            catch (PasswordInvalidoException excepcion)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                lblWarningPassword.Visible = true;
            }
        }

        #endregion

        private void Exito()
        {
            DialogResult = DialogResult.OK;
            MessageBox.Show("Empleado cargado exitosamente!", "Exito!");
            Close();
        }
    }
}
