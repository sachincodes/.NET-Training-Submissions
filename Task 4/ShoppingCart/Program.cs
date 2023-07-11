using System;
using System.Collections.Generic;

// Interface for a product
public interface IProduct
{
    string Name { get; }
    decimal Price { get; }
}

// Interface for a customer
public interface ICustomer
{
    string Name { get; }
}

// Product class implementing the IProduct interface
public class Product : IProduct
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

// Shopping cart class
public class ShoppingCart
{
    private List<IProduct> products;
    private ICustomer customer;

    public ShoppingCart(ICustomer customer)
    {
        products = new List<IProduct>();
        this.customer = customer;
    }
     
    public void AddProduct(IProduct product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;

        foreach (var product in products)
        {
            totalPrice += product.Price;
        }

        return totalPrice;
    }

    public decimal CalculateTotalPriceWithDiscount()
    {
        decimal totalPrice = CalculateTotalPrice();

        // Apply discount based on certain condition (e.g., total price greater than $100)
        if (totalPrice > 100)
        {
            totalPrice *= 0.9m; // 10% discount
        }

        return totalPrice;
    }
}

// Customer class implementing the ICustomer interface
public class Customer : ICustomer
{
    public string Name { get; private set; }

    public Customer(string name)
    {
        Name = name;
    }
}

// Example usage
public class Program
{
    public static void Main()
    {
        // Create some products
        Product product1 = new Product("Product 1", 50);
        Product product2 = new Product("Product 2", 75);
        Product product3 = new Product("Product 3", 120);

        // Create a customer
        Customer customer = new Customer("John");

        // Create a shopping cart for the customer
        ShoppingCart cart = new ShoppingCart(customer);

        // Add products to the cart
        cart.AddProduct(product1);
        cart.AddProduct(product2);
        cart.AddProduct(product3);

        // Calculate the total price
        decimal totalPrice = cart.CalculateTotalPrice();
        Console.WriteLine($"Total price: {totalPrice}");

        // Calculate the total price with discount
        decimal totalPriceWithDiscount = cart.CalculateTotalPriceWithDiscount();
        Console.WriteLine($"Total price with discount: {totalPriceWithDiscount}");
    }
}

