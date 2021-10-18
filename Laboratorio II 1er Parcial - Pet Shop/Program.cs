using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetShopCore;

namespace Laboratorio_II_1er_Parcial___Pet_Shop
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Clientes
            Tienda.clientes.Add(Tienda.clientes.Keys.Count + 1, new Cliente("Trent", "Reznor", 45000.67));
            Tienda.clientes.Add(Tienda.clientes.Keys.Count + 1, new Cliente("Michael", "Scott"));
            Tienda.clientes.Add(Tienda.clientes.Keys.Count + 1, new Cliente("Till", "Lindemann", 62306.10));
            Tienda.clientes.Add(Tienda.clientes.Keys.Count + 1, new Cliente("James", "Kent", 10054.70));
            Tienda.clientes.Add(Tienda.clientes.Keys.Count + 1, new Cliente("Trent", "Reznor", 45000.67));
            Tienda.clientes.Add(Tienda.clientes.Keys.Count + 1, new Cliente("Doom", "Guy", 666));
            Tienda.clientes.Add(Tienda.clientes.Keys.Count + 1, new Cliente("Andrew", "Hulshult", 4000.20));

            //Empleados
            Tienda.empleados.Add(new Empleado("Kirk", "Douglas", "spartacus60", "123456"));
            Tienda.empleados.Add(new Empleado("Christian", "Bale", "imBatm4n", "123456"));
            Tienda.empleados.Add(new Empleado("Michael", "Biehn", "kyle2029", "123456"));

            //Administradores
            Tienda.empleados.Add(new Administrador("Alfred", "Hitchcock", "psycho.OldMan1899", "123456"));
            Tienda.empleados.Add(new Administrador("Stanley", "Kubrick", "Stan_The_Man", "123456"));
            Tienda.empleados.Add(new Administrador("Sigourney", "Weaver", "Ripley8", "123456"));

            //Productos
            Tienda.productos.Add(new Producto("Cucha para Perros", 3, 8999, Producto.ECategoria.Casa, 5000));
            Tienda.productos.Add(new Producto("Soga para Morder", 10, 850.25, Producto.ECategoria.Juguete, 2000));
            Tienda.productos.Add(new Producto("Alimento Balanceado 5KG", 2, 4220.75, Producto.ECategoria.Alimento, 1500));
            Tienda.productos.Add(new Producto("Suplemento Vitaminico", 5, 1250, Producto.ECategoria.Medicina, 200));
            Tienda.productos.Add(new Producto("Correa para Gatos", 7, 980, Producto.ECategoria.Correa, 150));
            Tienda.productos.Add(new Producto("Alimento para Conejos", 9, 800, Producto.ECategoria.Alimento, 1000));

            //Ventas
            Tienda.ventas.Push(new Venta(2, 3, 1, 4220.75, "11/10/2021 10:02"));
            Tienda.ventas.Push(new Venta(3, 2, 2, 1700.5, "11/10/2021 14:24"));
            Tienda.ventas.Push(new Venta(1, 4, 3, 3750, "12/10/2021 15:07"));
            Tienda.ventas.Push(new Venta(1, 3, 1, 4220.75, "13/10/2021 18:58"));
            Tienda.ventas.Push(new Venta(5, 6, 2, 1600));

            //Generamos y abrimos el Form de Logueo
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Login());
        }
    }
}
