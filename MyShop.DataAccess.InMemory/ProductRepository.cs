using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        //INTREBARE: (Sectiune 61) De ce folosim ObjectCache si nu facem conexiune cu o baza de date?
        //Cache-ul nu se sterge la fiecare rulaj?

        //Initializare cache
        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if (products == null)
            {
                products= new List<Product>();
            }
        }

        //Metoda salvare cache
        public void Commit()
        {
            cache["products"] = products;
        }

        //Metoda inserare produs in lista
        public void Insert(Product product)
        {
            products.Add(product);
        }

        //Metoda update produs in lista
        public void Update(Product product)
        {
            Product productToUpdate=products.Find(p=>p.Id==product.Id);

            if (productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }

        //Metoda gasire produs in lista
        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }

        //Metoda returnare lista
        //INTREBARE: Ce inseamna IQueryable si cum se foloseste?
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        //Metoda delete
        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }
    }
}
