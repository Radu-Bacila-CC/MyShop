using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {

        //INTREBARE: DbSet reprezinta tabelul din baza de date?
        //INTRBARE: DataContext este defapt baza de date si are metode de salvare din cauza ca implementeaza clasa DbContext?
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext dataContext)
        {
            this.context = dataContext;
            this.dbSet = context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            //INTREBARE: context.Entry cauta in baza de date iar EntityState.Detached?
            //Defapt cautam in baza de date obiectul, il atasam la tabelul din clasa asta (dbSet) si dupa il stergem?
            //Dar atunci, fiindca dbSet=context.Set<T> (extragem din baza de date setul de valori) si noi efectuam modificari pe
            //DbSet, de ce pe partea de commit putem folosit context.SaveChanges()?
            //Nu trebuie sa adaugam datele din DbSet inapoi in context?
            var t = Find(Id);
            if (context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }

            dbSet.Remove(t);
        }
        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            //INTREBARE: Ce fac aceste metode? Cauta si modifica automat campurile?
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
