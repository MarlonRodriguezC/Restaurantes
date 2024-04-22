using System;
using System.IO;
namespace Programa
{

public class Producto
{
    // Properties
    public string Numero { get; set; }
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public string Precio { get; set; }

    // Constructor
    public Producto(string numero, string nombre, string precio, string tipo)
    {
        Numero = numero;
        Nombre = nombre;
        Precio = precio;
        Tipo   = tipo;
    }

    // Method to display product information
    public void informacion()
    {
        Console.WriteLine("Numero:"+Numero);
        
        Console.WriteLine("Nombre:"+Nombre);
        
        Console.WriteLine("Precio:"+Precio);
        
        Console.WriteLine("Tipo:"+Tipo);
        Console.WriteLine("************************************");
    }
}
}
