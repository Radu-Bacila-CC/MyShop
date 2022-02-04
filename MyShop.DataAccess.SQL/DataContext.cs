using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext():base("DefaultConnection")
        {
            
        }

        //INTREBARE: Daca variabilele sunt publice, de ce folosim get, set?
        //Nu ar trebui sa facem ca variabilele sa fie private si sa folosim metodele?

        //INTREBARE: Comenzile Enable-Migrations / Add-Migration din Package Manager Console
        //realizeaza conexiunea cu baza de date?
        //Comenzile:
        //Enable-Migration
        //Add-Migration Initial
        //Update-Database
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
