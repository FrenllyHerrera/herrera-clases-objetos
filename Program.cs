using System;

namespace TecnoPunto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("      TECNOPUNTO - CONTROL DE INVENTARIO");
            Console.WriteLine("==================================================");
            Console.WriteLine("  Programa para registrar 3 productos.");
            Console.WriteLine("==================================================");

            //Aquí voy a guardar los 3 productos, pero sin arreglo sería tres variables separadas.
            Producto producto1 = null;
            Producto producto2 = null;
            Producto producto3 = null;

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine();
                Console.WriteLine(">> INGRESO DEL PRODUCTO #" + i);
                Console.WriteLine("--------------------------------------------------");

                Console.Write("  Código   : ");
                string codigo = Console.ReadLine();
                Console.Write("  Nombre   : ");
                string nombre = Console.ReadLine();
                double precio = LeerPrecio();
                int cantidad = LeerCantidad();

                //Creamos el objeto
                Producto nuevoProducto = new Producto(codigo, nombre, precio, cantidad);
                if (i == 1)
                {
                    producto1 = nuevoProducto;
                }
                else if (i == 2)
                {
                    producto2 = nuevoProducto;
                }
                else
                {
                    producto3 = nuevoProducto;
                }

                Console.WriteLine("  [OK] Producto registrado correctamente.");
            }

            //Luego mostrar los productos guardados
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("        PRODUCTOS REGISTRADOS EN EL INVENTARIO");
            Console.WriteLine("==================================================");

            producto1.MostrarInfo();
            producto2.MostrarInfo();
            producto3.MostrarInfo();

            double totalInventario = producto1.ValorTotal + producto2.ValorTotal + producto3.ValorTotal;

            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("  VALOR TOTAL DEL INVENTARIO: $" + totalInventario.ToString("F2"));
            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("Presione ENTER para salir...");
            Console.ReadLine();
        }
        static double LeerPrecio()
        {
            double precio = 0;
            bool datoValido = false;

            //Se repite hasta que se escriba un número de verdad
            while (datoValido == false)
            {
                Console.Write("  Precio   : ");
                try
                {
                    precio = double.Parse(Console.ReadLine());
                    datoValido = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("  [ERROR] Eso no es un número válido. Intente de nuevo.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("  [ERROR] No escribió nada. Intente de nuevo.");
                }
            }

            return precio;
        }
        static int LeerCantidad()
        {
            int cantidad = 0;
            bool datoValido = false;

            while (datoValido == false)
            {
                Console.Write("  Cantidad : ");
                try
                {
                    cantidad = int.Parse(Console.ReadLine());
                    datoValido = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("  [ERROR] La cantidad debe ser un número entero. Intente de nuevo.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("  [ERROR] No escribió nada. Intente de nuevo.");
                }
            }

            return cantidad;
        }
    }
}