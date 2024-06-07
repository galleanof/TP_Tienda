using System;

class Program
{
    static Tienda tienda = new Tienda();
    static Carrito carrito = new Carrito();

    static void Main(string[] args)
    {
        bool continuar = true;
        Console.WriteLine("========================================");
        Console.WriteLine("          BIENVENIDO A LA TIENDA        ");
        Console.WriteLine("========================================");
        Console.Clear();
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("¿Qué desea hacer?");
            Console.WriteLine("1. Agregar producto a la tienda");
            Console.WriteLine("2. Mostrar lista de productos y stock");
            Console.WriteLine("3. Retirar producto de la tienda");
            Console.WriteLine("4. Agregar producto al carrito");
            Console.WriteLine("5. Eliminar producto del carrito");
            Console.WriteLine("6. Mostrar carrito");
            Console.WriteLine("7. Vaciar carrito");
            Console.WriteLine("8. Mostrar monto del carrito");
            Console.WriteLine("9. Mostrar monto en caja registradora");
            Console.WriteLine("10. Agregar dinero a la caja");
            Console.WriteLine("11. Cobrar");
            Console.WriteLine("12. Salir");
            Console.WriteLine("========================================");
            Console.Write("Ingrese una opción: ");
            int opcion;

            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 12)
            {
                Console.Write("Opción no válida. Ingrese una opción entre 1 y 12: ");
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("AGREGAR PRODUCTO A LA TIENDA");
                    Console.WriteLine("========================================");
                    Console.Write("Ingrese el nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el costo del producto: ");
                    double costo = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese el stock del producto: ");
                    int stock = int.Parse(Console.ReadLine());
                    Producto producto = new Producto(nombre, stock, costo);
                    tienda.AgregarTienda(producto);
                    Console.WriteLine("Producto agregado correctamente.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("LISTA DE PRODUCTOS Y STOCK");
                    Console.WriteLine("========================================");
                    tienda.GetListaDeProductosTienda();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("RETIRAR PRODUCTO DE LA TIENDA");
                    Console.WriteLine("========================================");
                    Console.Write("Ingrese el nombre del producto a retirar: ");
                    string nombreProducto = Console.ReadLine();
                    Producto productoEliminar = tienda.ListaDeElementosTienda.Find(p => p.GetNombre() == nombreProducto);
                    if (productoEliminar != null)
                    {
                        tienda.BorrarTienda(productoEliminar);
                        Console.WriteLine("Producto retirado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("El producto no se encuentra en la tienda.");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("AGREGAR PRODUCTO AL CARRITO");
                    Console.WriteLine("========================================");
                
                    tienda.GetListaDeProductosTienda();
                Console.WriteLine("========================================");
                
                    Console.Write("Ingrese el nombre del producto: ");
                    string nombreProductoCarrito = Console.ReadLine();
                    Console.Write("Ingrese la cantidad: ");
                    int cantidad = int.Parse(Console.ReadLine());

                    Producto productoAgregar = tienda.ListaDeElementosTienda.Find(p => p.GetNombre() == nombreProductoCarrito);

                    if (productoAgregar != null)
                    {
                        tienda.AgregarACarrito(productoAgregar, carrito, cantidad);
                    }
                    else
                    {
                        Console.WriteLine("El producto no se encuentra en la tienda.");
                    }
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
            case     5:
                Console.Clear();
                Console.WriteLine("ELIMINAR PRODUCTO DEL CARRITO");
                Console.WriteLine("========================================");
                carrito.GetListaDeProductosCarrito();
                Console.Write("Ingrese el nombre del producto: ");
                string nombreProductoEliminar = Console.ReadLine();
                Console.Write("Ingrese la cantidad a eliminar: ");
                int cantidadEliminar = int.Parse(Console.ReadLine());
                carrito.EliminarDelCarrito(nombreProductoEliminar, cantidadEliminar);
                Console.WriteLine("Producto eliminado del carrito.");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                break;
            case     6:
                    Console.Clear();
                    Console.WriteLine("MOSTRAR CARRITO");
                    Console.WriteLine("========================================");
                    carrito.GetListaDeProductosCarrito();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

            case 7:
                    Console.Clear();
                    Console.WriteLine("VACIAR CARRITO");
                    Console.WriteLine("========================================");
                    carrito.VaciarCarrito();
                    Console.WriteLine("Carrito vaciado correctamente.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

            case 8:
                    Console.Clear();
                    Console.WriteLine("MONTO TOTAL DEL CARRITO");
                    Console.WriteLine("========================================");
                    Console.WriteLine("El monto total del carrito es: $" + carrito.CostoTotal());
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

            case 9:
                    Console.Clear();
                    Console.WriteLine("MONTO EN CAJA REGISTRADORA");
                    Console.WriteLine("========================================");
                    Console.WriteLine("El monto en la caja registradora es: $" + tienda.GetDineroEnCaja());
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

            case 10:
                    Console.Clear();
                    Console.WriteLine("AGREGAR DINERO A LA CAJA");
                    Console.WriteLine("========================================");
                    Console.Write("Ingrese la cantidad de dinero a agregar: ");
                    double dineroParaAgregar = double.Parse(Console.ReadLine());
                    tienda.AddDineroEnCaja(dineroParaAgregar);
                    Console.WriteLine("Dinero agregado correctamente.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

            case 11:
                    Console.Clear();
                    Console.WriteLine("COBRAR");
                    Console.WriteLine("========================================");
                    Console.WriteLine("El monto final sería: " + carrito.CostoTotal());
                    Console.Write("Ingrese el monto con el que va a pagar el cliente: ");
                    double dineroCliente = double.Parse(Console.ReadLine());
                    tienda.Cobrar(dineroCliente, carrito);
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

            case 12:
                    continuar = false;
                    break;
            }
        }
    }
}
