using System;

namespace TecnoPunto
{
    public class Producto
    //Aquí guardo los datos de cada producto del inventario ya sea privado o simple

    {
        private string codigo;
        private string nombre;
        private double precio;
        private int cantidad;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Nombre
        //Ahora quiero validar que no me metan un nombre vacío
        {
            get { return nombre; }
            set
            {
                // Si está vacío,solo espacios o nulo avisará y pondrá uno por defecto
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine(" [AVISO] El nombre no puede estar vacío.");
                    Console.WriteLine(" [AVISO] Se guardó el producto como 'Sin nombre'.");
                    nombre = "Sin nombre";
                }
                else
                {
                    nombre = value;
                }
            }
        }
        public double Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine(" [AVISO] El precio debe ser mayor que 0.");
                    Console.WriteLine(" [AVISO] Se guardó un precio mínimo de 0.01 para no dañar el inventario.");
                    precio = 0.01;
                }
                else
                {
                    precio = value;
                }
            }
        }

        //Para que la cantidad no sea negativa
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine(" [AVISO] La cantidad no puede ser negativa.");
                    Console.WriteLine(" [AVISO] Se guardó la cantidad en 0.");
                    cantidad = 0;
                }
                else
                {
                    cantidad = value;
                    // Si es negativa, avisamos y la dejamos en 0
                }
            }
        }
        public double ValorTotal
        {
            get { return Precio * Cantidad; }
        }
        public Producto(string codigo, string nombre, double precio, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
        // Método para imprimir los datos del producto de forma ordenada
        public void MostrarInfo()
        {
            Console.WriteLine("  ----------------------------------------");
            Console.WriteLine("  Código      : " + Codigo);
            Console.WriteLine("  Nombre      : " + Nombre);
            Console.WriteLine("  Precio      : $" + Precio.ToString("F2"));
            Console.WriteLine("  Cantidad    : " + Cantidad);
            Console.WriteLine("  Valor total : $" + ValorTotal.ToString("F2"));
            Console.WriteLine("  ----------------------------------------");
        }
    }
}
