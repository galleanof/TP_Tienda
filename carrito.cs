using System;
using System.Collections.Generic;

public class Carrito
{
    private List<Producto> ListaDeElementosCarrito = new List<Producto>();
    private double ValorTotal = 0;

    public void Agregar(Producto elemento, int cantidad)
    {
        var productoExistente = ListaDeElementosCarrito.Find(p => p.GetNombre() == elemento.GetNombre());
        if (productoExistente != null)
        {
            productoExistente.SetStock(productoExistente.GetStock() + cantidad);
        }
        else
        {
            Producto nuevoProducto = elemento.CopiarConCantidad(cantidad);
            ListaDeElementosCarrito.Add(nuevoProducto);
        }
    }

    public void EliminarDelCarrito(string nombreProducto, int cantidad)
    {
        var productoExistente = ListaDeElementosCarrito.Find(p => p.GetNombre() == nombreProducto);
        if (productoExistente != null)
        {
            if (cantidad >= productoExistente.GetStock())
            {
                ListaDeElementosCarrito.Remove(productoExistente);
            }
            else
            {
                productoExistente.SetStock(productoExistente.GetStock() - cantidad);
            }
        }
        else
        {
            Console.WriteLine("El producto no se encuentra en el carrito.");
        }
    }

    public void VaciarCarrito()
    {
        ListaDeElementosCarrito.Clear();
        ValorTotal = 0;
        Console.WriteLine("El carrito ha sido vaciado.");
    }

    public void GetListaDeProductosCarrito()
    {
        if (ListaDeElementosCarrito.Count == 0)
        {
            Console.WriteLine("El carrito está vacío.");
        }
        else
        {
            Console.WriteLine("Los productos en el carrito son:");
            Console.WriteLine("========================================");
            foreach (var producto in ListaDeElementosCarrito)
            {
                Console.WriteLine(producto.GetNombre() + " - $" + producto.GetPrecioDeVenta() + " - Cantidad: " + producto.GetStock());
            }
            Console.WriteLine("========================================");
        }
    }

    public double CostoTotal()
    {
        ValorTotal = 0;
        foreach (var producto in ListaDeElementosCarrito)
        {
            ValorTotal += producto.GetPrecioDeVenta() * producto.GetStock();
        }
        return ValorTotal;
    }
}
