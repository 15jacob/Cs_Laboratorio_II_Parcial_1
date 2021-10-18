using PetShopCore;
using System;
using System.Windows.Forms;

namespace Laboratorio_II_1er_Parcial___Pet_Shop
{
    public partial class Form_Login : Form
    {
        #region CONSTRUCTORES

        public Form_Login()
        {
            InitializeComponent();

            //Seteamos el nombre de la ventana como el nombre de la tienda seguido de "administracion"
            Text = $"{Tienda.nombreTienda} - Login";
        }

        #endregion


        #region EVENTOS

        /// <summary>
        /// Al clickear el boton de login, tomaremos el usuario y password indicados e intentaremos loguear al usuario
        /// Una excepcion es esperada en caso de que los datos sean incorrectos
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Empleado empleado;
            Form_Administracion formAdministracion;

            //Intentamos loguear al usuario con los datos provistos
            try
            {
                empleado = Tienda.Log_Empleado(txtUser.Text, txtPassword.Text);

                formAdministracion = new Form_Administracion(empleado);
                formAdministracion.Show();

                //Escondemos el Form Login
                Hide();
            }
            catch(UsuarioInvalidoException excepcion)
            {
                MessageBox.Show("Usuario o Contraseña invalidos, revisa los datos");
                lblLoginError.Visible = true;
            }
        }

        /// <summary>
        /// Al clickear el boton de autologin empleado, se llenaran los campos de usuario y password con aquellos de un empleado
        /// </summary>
        private void btnAutoLoginEmpleado_Click(object sender, EventArgs e)
        {
            txtUser.Text = "kyle2029";
            txtPassword.Text = "123456";
        }

        /// <summary>
        /// Al clickear el boton de autologin administrador, se llenaran los campos de usuario y password con aquellos de un administrador
        /// </summary>
        private void btnAutoLoginAdministrador_Click(object sender, EventArgs e)
        {
            txtUser.Text = "Ripley8";
            txtPassword.Text = "123456";
        }

        #endregion
    }
}
