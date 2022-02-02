using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
            ObjectCache cache = MemoryCache.Default;
            List<ProductCategory> productCategories;

            //Initializare cache
            public ProductCategoryRepository()
            {
                productCategories = cache["productCategories"] as List<ProductCategory>;
                if (productCategories == null)
                {
                    productCategories = new List<ProductCategory>();
                }
            }

            //Metoda salvare cache
            public void Commit()
            {
                cache["productCategories"] = productCategories;
            }

            //Metoda inserare categorie produs in lista
        public void Insert(ProductCategory productCategory)
            {
                productCategories.Add(productCategory);
            }

            //Metoda update categorie produs in lista
            public void Update(ProductCategory productCategory)
            {
                ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

                if (productCategoryToUpdate != null)
                {
                    productCategoryToUpdate = productCategory;
                }
                else
                {
                    throw new Exception("Product Category not found!");
                }
            }

            //Metoda gasire categorie produs in lista
        public ProductCategory Find(string Id)
            {
                ProductCategory productCategory = productCategories.Find(p => p.Id == Id);

                if (productCategory != null)
                {
                    return productCategory;
                }
                else
                {
                    throw new Exception("Product category not found!");
                }
            }

            //Metoda returnare lista
            public IQueryable<ProductCategory> Collection()
            {
                return productCategories.AsQueryable();
            }

            //Metoda delete
            public void Delete(string Id)
            {
                ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);

                if (productCategoryToDelete != null)
                {
                productCategories.Remove(productCategoryToDelete);
                }
                else
                {
                    throw new Exception("Product category not found!");
                }
            }
        }
    }