using System;
using System.IO;

namespace Programa
{
    internal class Programa
    {

    static void Main()
    {
        bool ejecucion= true; 
        // Ejemplo de uso de la función leerCsv
        string[][] productos = leerCsv("Menu.csv");

        Producto[]  menu = cargarMenu(productos);

        while(ejecucion){
            Console.WriteLine("Escoja una opcion de gestion");
            Console.WriteLine("- Opcion 1: [MENU]");
            Console.WriteLine("- Opcion 2: Salir");
            Console.WriteLine("------------------------");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    opciones_menu(menu);
                    break;
                case 2:
                    ejecucion = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    break;
            }
        }
        
        
    }

    static void opciones_menu(Producto[]  menu){
        bool ejecucion_menu= true; 
        while(ejecucion_menu){
            Console.WriteLine("Escoja una opcion [MENU]:");
            Console.WriteLine("- Opcion 1: Ver menu");
            Console.WriteLine("- Opcion 2: Buscar producto en menu");
            Console.WriteLine("- Opcion 3: Editar producto en menu");
            Console.WriteLine("- Opcion 4: Eliminar producto en menu");     // PENDIENTE
            Console.WriteLine("- Opcion 5: Agregar producto en menu");      // PENDIENTE
            Console.WriteLine("- Opcion 6: Guardar menu");                  // PENDIENTE
            Console.WriteLine("- Opcion 7: Salir");
            Console.WriteLine("------------------------");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    imprimirMenu(menu);
                    break;
                case 2:
                    buscarProducto(menu);
                    break;
                case 3:
                    editarProducto(menu);
                    break;
                case 7:
                    ejecucion_menu = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    break;
            }

        }
    }

    static string[][] leerCsv(string filePath)
    {
        // Lee todas las líneas del archivo CSV
        string[] lines = File.ReadAllLines(filePath);

        // Inicializa la matriz para almacenar los datos CSV
        string[][] data = new string[lines.Length][];

        // Recorre cada línea y divide los valores por comas para crear las filas de la matriz
        for (int i = 0; i < lines.Length; i++)
        {
            data[i] = lines[i].Split(',');
        }

        return data;
    }

    static Producto[] cargarMenu(string[][] productos)
    {
        
        int numero_productos = productos.GetLength(0);
        Producto[] menu = new Producto[numero_productos];
        for (int i = 0; i < numero_productos; i++)
        {
                menu[i] = new Producto(productos[i][0], productos[i][1], productos[i][2], productos[i][3]); 
        }
        return menu; 
    }

    static void imprimirMenu(Producto[] menu){
        Console.WriteLine("------------------------ IMPRIMIENDO MENU ------------------------");
        int numero_productos = menu.Length;
        for (int i = 0; i < numero_productos; i++)
        {
            menu[i].informacion();
        }
    }

    static void buscarProducto(Producto[] menu){
        Console.WriteLine("BUSCANDO PRODUCTO ...");
        Console.WriteLine("ESCRIBA EL NUMERO DEL PRODUCTO:");
        Console.WriteLine("------------------------");
        string numero = Console.ReadLine();
        int numero_productos = menu.Length;
        bool encontrado = false;
        for (int i = 0; i < numero_productos; i++)
        {
            if(menu[i].Numero == numero ){
                menu[i].informacion();
                encontrado = true;
            }
        }
        if(encontrado == false){
            Console.WriteLine("---------- PRODUCTO NO ENCONTRADO---------------" );
        }

    }


    static void editarProducto(Producto[] menu){
        Console.WriteLine("BUSCANDO PRODUCTO ...");
        Console.WriteLine("ESCRIBA EL NUMERO DEL PRODUCTO:");
        Console.WriteLine("------------------------");
        string numero = Console.ReadLine();
        int numero_productos = menu.Length;
        bool encontrado = false;
        for (int i = 0; i < numero_productos; i++)
        {
            if(menu[i].Numero == numero ){
                menu[i].informacion();
                Console.WriteLine("NOMBRE DEL PRODUCTO:");
                string nuevo_nombre = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevo_nombre)){
                    menu[i].Nombre = nuevo_nombre;
                }
                Console.WriteLine("NUMERO DEL PRODUCTO:");
                string nuevo_numero = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevo_numero)){
                    menu[i].Numero = nuevo_numero;
                }
                Console.WriteLine("PRECIO DEL PRODUCTO:");
                string nuevo_precio = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevo_precio)){
                    menu[i].Precio = nuevo_precio;
                }
                Console.WriteLine("TIPO DEL PRODUCTO:");
                string nuevo_tipo = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevo_tipo)){
                    menu[i].Tipo = nuevo_tipo;
                }
                Console.WriteLine("// INFORMACION ACTUALIZADA //");
                menu[i].informacion();
                encontrado = true;
            }
        }
        if(encontrado == false){
            Console.WriteLine("---------- PRODUCTO NO ENCONTRADO---------------" );
        }

    }

    }
}

