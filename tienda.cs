using System;
using System.Collections.Generic;

public class Tienda
{
    public List<Producto> ListaDeElementosTienda = new List<Producto>();
    private double DineroEnCaja = 0;

    public void AgregarTienda(Producto nuevoProducto)
    {
        var productoExistente = ListaDeElementosTienda.Find(p => p.GetNombre() == nuevoProducto.GetNombre());
        if (productoExistente != null)
        {
            productoExistente.SetStock(productoExistente.GetStock() + nuevoProducto.GetStock());
            productoExistente.SetPrecioDeVenta(nuevoProducto.GetPrecioDeVenta());
        }
        else
        {
            ListaDeElementosTienda.Add(nuevoProducto);
        }
    }

    public void BorrarTienda(Producto producto)
    {
        ListaDeElementosTienda.Remove(producto);
    }

    public void AgregarACarrito(Producto producto, Carrito carrito, int cantidad)
    {
        if (ListaDeElementosTienda.IndexOf(producto) < 0)
        {
            Console.WriteLine("Error: El producto no existe en la tienda");
        }
        else
        {
            if (cantidad > producto.GetStock())
            {
                Console.WriteLine("Error: No hay suficiente stock");
            }
            else
            {
                carrito.Agregar(producto, cantidad);
                producto.SetStock(producto.GetStock() - cantidad);
                carrito.GetListaDeProductosCarrito();
            }
        }
    }

    public void GetListaDeProductosTienda()
    {
        Console.WriteLine("Los productos en la tienda son:");
        foreach (var producto in ListaDeElementosTienda)
        {
            Console.WriteLine(producto.GetNombre() + " - $" + producto.GetPrecioDeVenta() + " - Stock:" + producto.GetStock());
        }
    }

    public void AddDineroEnCaja(double dineroParaAgregar)
    {
        DineroEnCaja += dineroParaAgregar;
    }

    public void SacarDineroEnCaja(double dineroParaSacar)
    {
        DineroEnCaja -= dineroParaSacar;
    }

    public double GetDineroEnCaja()
    {
        return DineroEnCaja;
    }

    public void Cobrar(double dineroCliente, Carrito carrito)
    {
        double costoTotal = carrito.CostoTotal();
        if (dineroCliente >= costoTotal)
        {
            double vuelto = dineroCliente - costoTotal;
            DineroEnCaja += costoTotal;
            carrito.VaciarCarrito();

            Console.WriteLine("El vuelto es de: " + vuelto);
            Console.WriteLine("El dinero en caja actualmente es de:" + DineroEnCaja);
        }
        else
        {
            Console.WriteLine("El dinero del cliente no es suficiente para cubrir el costo del carrito.");
        }
    }
}
