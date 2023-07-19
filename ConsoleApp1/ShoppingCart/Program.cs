using System;
using System.Collections.Generic;

public interface IProduct
{
    string Name { get; set; }
    decimal Price { get; set; }
}

public class Product : IProduct
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public interface IShoppingCart
{
    void AddProduct(IProduct product);
    decimal CalculateTotalPrice();
}

public class ShoppingCart : IShoppingCart
{
    private readonly List<IProduct> _products = new List<IProduct>();

    public void AddProduct(IProduct product)
    {
        _products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;

        foreach (var product in _products)
        {
            totalPrice += product.Price;
        }

        return totalPrice;
    }
}

public class Customer
{
    public string Name { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        var product1 = new Product { Name = "Product 1", Price = 10 };
        var product2 = new Product { Name = "Product 2", Price = 20 };
        var product3 = new Product { Name = "Product 3", Price = 30 };

        var shoppingCart = new ShoppingCart();
        shoppingCart.AddProduct(product1);
        shoppingCart.AddProduct(product2);
        shoppingCart.AddProduct(product3);

        Console.WriteLine("Total price: " + shoppingCart.CalculateTotalPrice());
    }
}
