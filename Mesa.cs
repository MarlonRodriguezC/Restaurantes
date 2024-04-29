using System;
using System.IO;
using System.Collections.Generic;

namespace Programa
{

public class Mesa
{
    // Properties
    public string Numero { get; set; }
    public string Disponibilidad { get; set; }
    public List<Producto> Productos { get; set; }

    // Constructor
    public Mesa(string numero, string disponibilidad)
    {
        Numero = numero;
        Disponibilidad = disponibilidad;
        Productos = new List<Producto>();
    }

    // Method to display product information
    public void informacion()
    {
        Console.WriteLine("Numero de mesa: "+Numero);
        Console.WriteLine("Disponibilidad: "+Disponibilidad);
        Console.WriteLine("Listado de productos: ");
        foreach (Producto productoObj in Productos)
        {
            Console.WriteLine("======================");
            productoObj.informacion();
        }
        Console.WriteLine("************************************");
    }

    public void agregarProducto(Producto productoAgregar)
    {
        Productos.Add(productoAgregar);
        Console.WriteLine("{{ PRODUCTO AGREGADO  }}");
    }
    public void eliminarProducto(Producto productoEliminar)
    {
        Productos.Remove(productoEliminar);
        Console.WriteLine("{{ PRODUCTO ELIMINADO  }}");
    }

    public void editarProducto(Producto productoEliminar, Producto productoAgregar)
    {
        eliminarProducto(productoEliminar);
        agregarProducto(productoAgregar);
    }

    public void generarFactura(){
        Console.WriteLine("---------------- FATURA MESA #"+Numero+" ----------------");
        int total = 0;
        foreach (Producto item in Productos)
        {
            item.informacionFACTURA();
            total += int.Parse(item.Precio);
        }
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("TOTAL: "+total);
        Console.WriteLine("------------------------------------------------");

    }

    public string[] facturaCSV(){
        List<string> facturaCSV=new List<string>();
        int total = 0;
        foreach (Producto item in Productos)
        {
            facturaCSV.Add(item.Numero+","+item.Nombre+","+item.Precio+","+item.Tipo);
        }
        return facturaCSV.ToArray();
    }
}
}
