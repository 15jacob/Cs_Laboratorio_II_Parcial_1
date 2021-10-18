using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore
{
    public abstract class Usuario
    {
        //Atributos
        protected string nombre;
        protected string apellido;


        #region CONSTRUCTORES

        protected Usuario(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        #endregion


        #region PROPIEDADES

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (Validaciones.Nombre(value))
                    nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
            set
            {
                if (Validaciones.Nombre(value))
                    apellido = value;
            }
        }

        #endregion
    }
}
