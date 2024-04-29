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
    public int Cantidad { get; set; }

    // Constructor
    public Producto(string numero, string nombre, string precioSTR, string tipo)
    {
        Numero = numero;
        Nombre = nombre;
        Precio = precioSTR;
        Tipo   = tipo;
        Cantidad = 1;
    }

    // Method to display product information
    public void informacion()
    {
        Console.WriteLine("Numero:"+Numero);
        
        Console.WriteLine("Nombre:"+Nombre);
        
        Console.WriteLine("Precio:"+Precio);
        
        Console.WriteLine("Tipo:"+Tipo);
        Console.WriteLine("//////////////////////////////////");
    }
      public void informacionFACTURA()
    {
        Console.WriteLine(Nombre+"  Cant: "+Cantidad+"  $"+Precio);
    }
}
}
