using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Basket : BaseEntity
    {
        

        //INTREBARE: In tutorial declaratia este urmatoare:
        //public virtual ICollection<BasketItem> BasketItems { get; set; }
        //Dar primesc eroarea.
        //Error CS0053  Inconsistent accessibility: property type 'ICollection<BasketItem>' is less accessible than
        //property 'Basket.BasketItems'	
        //Merge doar private

        //Clasa BasketItem nu era public, am rezolvat
        //Dar atunci acest tip de eroare vine de la faptul ca doua clase au accesibilitati diferite?

        //public virtual ICollection<BasketItem> BasketItems { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
