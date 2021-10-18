using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCore
{
    public class Administrador : Empleado
    {
        public Administrador(string nombre, string apellido, string user, string password) : base(nombre, apellido, user, password)
        {

        }
        public Administrador(int idEmpleado, string nombre, string apellido, string user, string password) : base(idEmpleado, nombre, apellido, user, password)
        {

        }
    }
}
