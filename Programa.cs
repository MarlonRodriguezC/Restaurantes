using System;
using System.IO;
using System.Collections.Generic;

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
        Mesa[] mesas= new Mesa[5];
        for(int i = 0; i < 5; i++){
            mesas[i] = new Mesa((i+1)+"", "disponible");
        }


        while(ejecucion){
            Console.WriteLine("  ___________________________________________________________________                                                                         /      ,                                      ,        /        ---/__----------__-----__-----------__-----__----------__-/-----__-   /   )  /    /___)  /   )  | /   /___)  /   )  /    /   /    /   ) _(___/__/____(___ __/___/___|/___(___ __/___/__/____(___/____(___/_ ");
            Console.WriteLine("Escoja una opcion de gestion");
            Console.WriteLine("- Opcion 1: [MENU]");
            Console.WriteLine("- Opcion 2: [MESAS]");
            Console.WriteLine("- Opcion 3: Salir");
            Console.WriteLine("------------------------");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    opciones_menu(menu);
                    break;
                case 2:
                    opciones_mesa(mesas, menu);
                    break;
                case 3:
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
            Console.WriteLine("- Opcion 4: Salir");
            Console.WriteLine("------------------------");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    imprimirMenu(menu);
                    break;
                case 2:
                    Producto productoEncontrado = buscarProducto(menu);
                    if (productoEncontrado != null){ productoEncontrado.informacion();}
                    break;
                case 3:
                    editarProducto(menu);
                    break;
                case 4:
                    ejecucion_menu = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    break;
            }

        }
    }

    static void opciones_mesa(Mesa[] mesas, Producto[]  menu){
        bool ejecucion_mesa= true; 
        while(ejecucion_mesa){
            Console.WriteLine("Escoja una opcion [MESA]:");
            Console.WriteLine("- Opcion 1: Ver mesas");
            Console.WriteLine("- Opcion 2: Ocupar mesa");
            Console.WriteLine("- Opcion 3: Desocupar mesa");
            Console.WriteLine("- Opcion 4: Agregar productos a mesa");    
            Console.WriteLine("- Opcion 5: Generar factura");    
            Console.WriteLine("- Opcion 6: Editar producto de mesa");    
            Console.WriteLine("-s de mesa");    
            
            Console.WriteLine("- Opcion 8: Salir");
            Console.WriteLine("------------------------");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    imprimirMesas(mesas);
                    break;
                case 2:
                    ocuparMesa(mesas);
                    break;
                case 3:
                    desocuparMesa(mesas);
                    break;
                case 4:
                    agregarProductosMesa(mesas, menu);
                    break;
                case 5:
                    generarFacturaMesa(mesas);
                    break;
                case 6:
                    editarProductoMesa(menu , mesas);
                    break;
                case 7:
                    break;
                case 8:
                    ejecucion_mesa = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    break;
            }

        }
    }

    static Mesa buscarMesa(Mesa[] mesas){
        Console.WriteLine("ESCRIBA EL NUMERO DE LA MESA:");
        Console.WriteLine("------------------------");
        string numero = Console.ReadLine();
        bool encontrada = false;
        for (int i = 0; i < mesas.Length; i++)
        {
            if (mesas[i].Numero == numero){
                encontrada = true;
                return mesas[i];
            }
        }
        if (!encontrada){
            Console.WriteLine("NO SE ENCONTRO LA MESA "+numero);
            return null;
        }
        return null;
    }

    static void generarFacturaMesa(Mesa[] mesas){
        Mesa mesaFactura = buscarMesa(mesas);
        if(mesaFactura != null ){
            mesaFactura.generarFactura();
        }else{
            Console.WriteLine("ERROR - NO FUE POSIBLE GENERAR LA FACTURA");
        }
    }

    static void imprimirMesas(Mesa[] mesas){
        for (int i = 0; i < mesas.Length; i++)
        {
            mesas[i].informacion();
        }
    }

    static void ocuparMesa(Mesa[] mesas){
        Mesa mesaFactura = buscarMesa(mesas);

        if(mesaFactura != null ){
            if(mesaFactura.Disponibilidad == "disponible"){
                mesaFactura.Disponibilidad = "ocupada";
                Console.WriteLine("LA MESA AHORA ESTA OCUPADA");
            }else{
                Console.WriteLine("LA MESA YA ESTA OCUPADA, SELECCIONE OTRA MESA");
            }
        }else{
            Console.WriteLine("ERROR - NO FUE POSIBLE OCUPAR LA MESA");
        }
    }

    static void desocuparMesa(Mesa[] mesas){
        Mesa mesaFactura = buscarMesa(mesas);
        if(mesaFactura != null ){
            if(mesaFactura.Disponibilidad == "ocupada"){
                    mesaFactura.Disponibilidad = "disponible";
                    Console.WriteLine("LA MESA AHORA ESTA DISPONIBLE");
                }else{
                    Console.WriteLine("LA MESA YA ESTA DISPONIBLE, SELECCIONE OTRA MESA");
                }
        }else{
            Console.WriteLine("ERROR - NO FUE POSIBLE OCUPAR LA MESA");
        }
    }

    static void agregarProductosMesa(Mesa[] mesas, Producto[] menu){
        Console.WriteLine("ESCRIBA EL NUMERO DE LA MESA PARA AGREGAR PRODUCTO:");
        Console.WriteLine("------------------------");
        string numero_mesa = Console.ReadLine();
        Mesa mesaAgregar = new Mesa("99", "disponible");

        Console.WriteLine("ESCRIBA EL NUMERO DEL PRODUCTO PARA AGREGAR:");
        Console.WriteLine("------------------------");
        string numero_producto = Console.ReadLine();
        Producto productoAgregar = new Producto("99", "excepcion", "0", "excepcion");

        // buscando el producto 
        bool encontrado = false;
        for (int i = 0; i < menu.Length; i++)
        {
            if(menu[i].Numero == numero_producto ){
                encontrado = true;
                productoAgregar = menu[i];
            }
        }
        if(encontrado == false){
            Console.WriteLine("---------- PRODUCTO NO ENCONTRADO---------------" );
            return;
        }


        // buscando la mesa
        bool encontrada = false;
        for (int i = 0; i < mesas.Length; i++)
        {
            if (mesas[i].Numero == numero_mesa){
                mesaAgregar = mesas[i];
                encontrada = true;
            }
        }
        if (!encontrada){
            Console.WriteLine("NO SE ENCONTRO LA MESA "+numero_mesa);
            return;
        }
        mesaAgregar.agregarProducto(productoAgregar);
        return;
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

    static Producto buscarProducto(Producto[] menu){
        Console.WriteLine("BUSCANDO PRODUCTO ...");
        Console.WriteLine("ESCRIBA EL NUMERO DEL PRODUCTO:");
        Console.WriteLine("------------------------");
        string numero = Console.ReadLine();
        bool encontrado = false;
        for (int i = 0; i < menu.Length; i++)
        {
            if(menu[i].Numero == numero ){

                encontrado = true;
                return menu[i];
            }
        }
        if(encontrado == false){
            Console.WriteLine("---------- PRODUCTO NO ENCONTRADO---------------" );
            return null;
        }
        return null;
    }


    static void editarProducto(Producto[] menu){
        Producto producto = buscarProducto(menu);
        if(producto != null){
            producto.informacion();
            Console.WriteLine("NOMBRE DEL PRODUCTO:");
            string nuevo_nombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevo_nombre)){
                producto.Nombre = nuevo_nombre;
            }
            Console.WriteLine("NUMERO DEL PRODUCTO:");
            string nuevo_numero = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevo_numero)){
                producto.Numero = nuevo_numero;
            }
            Console.WriteLine("PRECIO DEL PRODUCTO:");
            string nuevo_precio = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevo_precio)){
                producto.Precio = nuevo_precio;
            }
            Console.WriteLine("TIPO DEL PRODUCTO:");
            string nuevo_tipo = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevo_tipo)){
                producto.Tipo = nuevo_tipo;
            }
            Console.WriteLine("// INFORMACION ACTUALIZADA //");
            producto.informacion();
        }
        else
        {
            Console.WriteLine("ERROR - NO SE PUEDE ACTUALIZAR EL PRODUCTO");

        }

    }

    static void editarProductoMesa(Producto[] menu , Mesa[] mesas ){
        Console.WriteLine("DIGITE EL NUMERO DE LA MESA");
        Mesa mesaEditada = buscarMesa(mesas);
        Console.WriteLine("DIGITE EL PRODUCTO QUE QUIERE CAMBIAR DE LA MESA");
        Producto productoEliminar = buscarProducto(menu);
        Console.WriteLine("DIGITE EL NUEVO PRODUCTO");
        Producto productoAgregar = buscarProducto(menu);
        if(mesaEditada != null && productoEliminar != null && productoAgregar != null){
           mesaEditada.editarProducto(productoEliminar, productoAgregar);
        }else{
            Console.WriteLine("ERROR NO SE PUEDE EDITAR EL PRODUCTO DE LA MESA");
        }    
        
    }



    
    }
}

