using System;

public class Producto
{
    private string nombre;
    private double costo;
    private double precioDeVenta;
    private int stock;

    public Producto(string nombre, int stock, double costo)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("Error: El nombre del producto no puede estar vacío");
            this.nombre = "NombreNoProporcionado";
        }
        else
        {
            this.nombre = nombre;
        }

        if (stock < 0)
        {
            Console.WriteLine("Error: El stock no puede ser negativo");
            this.stock = 0;
        }
        else
        {
            this.stock = stock;
        }

        if (costo < 0)
        {
            Console.WriteLine("Error: El costo no puede ser negativo");
            this.costo = 0;
            this.precioDeVenta = 0;
        }
        else
        {
            this.costo = costo;
            this.precioDeVenta = costo * 1.3;
        }
    }

    public string GetNombre()
    {
        return nombre;
    }

    public double GetCosto()
    {
        return costo;
    }

    public double GetPrecioDeVenta()
    {
        return precioDeVenta;
    }

    public int GetStock()
    {
        return stock;
    }

    public void SetStock(int stock)
    {
        if (stock < 0)
        {
            Console.WriteLine("Error: El stock no puede ser negativo");
        }
        else
        {
            this.stock = stock;
        }
    }

    public void SetPrecioDeVenta(double precioDeVenta)
    {
        this.precioDeVenta = precioDeVenta;
    }

    public Producto CopiarConCantidad(int cantidad)
    {
        Producto productoCopia = new Producto(nombre, cantidad, costo);
        return productoCopia;
    }
}
