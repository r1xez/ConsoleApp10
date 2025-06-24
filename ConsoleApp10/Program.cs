using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


class Product<T>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime DateAdded { get; set; }
    public T Type { get; set; }

    public Product(string name, decimal price, DateTime dateAdded, T type)
    {
        Name = name;
        Price = price;
        DateAdded = dateAdded;
        Type = type;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Name} | Price: {Price} | Added: {DateAdded.ToShortDateString()} | Type: {Type}");
    }
}


class Category<T> : IEnumerable<Product<T>>
{
    private List<Product<T>> products = new List<Product<T>>();

    public void AddProduct(Product<T> product)
    {
        products.Add(product);
    }

    public IEnumerator<Product<T>> GetEnumerator()
    {
        return products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

  
    public IEnumerable<Product<T>> FilterByPrice(decimal minPrice, decimal maxPrice)
    {
        return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
    }

   
    public IEnumerable<Product<T>> FilterByRecentDate(int days = 30)
    {
        DateTime cutoff = DateTime.Now.AddDays(-days);
        return products.Where(p => p.DateAdded >= cutoff);
    }
}
class Program
{
    static void Main(string[] args)
    {
        var electronicsCategory = new Category<string>();

        electronicsCategory.AddProduct(new Product<string>("Smartphone", 350m, DateTime.Now.AddDays(-10), "Gadget"));
        electronicsCategory.AddProduct(new Product<string>("Laptop", 1200m, DateTime.Now.AddDays(-40), "Computer"));
        electronicsCategory.AddProduct(new Product<string>("Headphones", 90m, DateTime.Now.AddDays(-5), "Accessory"));

        Console.WriteLine("All products:");
        foreach (var product in electronicsCategory)
        {
            product.DisplayInfo();
        }

        Console.WriteLine("\nProducts priced between 100 and 500:");
        foreach (var product in electronicsCategory.FilterByPrice(100m, 500m))
        {
            product.DisplayInfo();
        }

        Console.WriteLine("\nProducts added in the last 30 days:");
        foreach (var product in electronicsCategory.FilterByRecentDate())
        {
            product.DisplayInfo();
        }
    }
}
