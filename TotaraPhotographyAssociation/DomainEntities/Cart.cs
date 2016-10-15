using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TotaraPhotographyAssociation.Models;

namespace TotaraPhotographyAssociation.DomainEntities
{
    public class Cart
    {
        private List<CartLine> lineCol = new List<CartLine>();

        public void AddItem(Product p, int q)
        {
            CartLine cl = this.lineCol.Where(r => r.Product.Id == p.Id).FirstOrDefault();
            if (cl == null)
            {
                this.lineCol.Add(
                        new CartLine
                        {
                            Product = p,
                            Quantity = q
                        }
                    );
            }
            else
            {
                cl.Quantity += q;
            }
        }

        public void RemoveLine(string prdID)
        {
            this.lineCol.RemoveAll(l => l.Product.Id == prdID);
        }

        public decimal ComputeTotalValue()
        {
            return this.lineCol.Sum(d => d.Product.Price * d.Quantity);
        }

        public void Clear()
        {
            this.lineCol.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return this.lineCol;
            }
        }


    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}