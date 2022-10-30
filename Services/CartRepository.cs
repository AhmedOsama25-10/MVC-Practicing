using Mobi__Shop.Models;
using Mobi_Shop.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Services
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext Context;

        public CartRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public int Add(Cart cart)
        {
            if (cart != null)
            {
                Product P = Context.Products.FirstOrDefault(p => p.Name == cart.ProductName);
                if (P != null)
                {
                    
                    Context.Carts.Add(cart);
                    return Context.SaveChanges();
                }

            }
            return Context.SaveChanges();
        }
        public List<Cart> GetAll(string username)
        {
            List<Cart> carts = Context.Carts.Where(C => C.UserName == username).ToList();
            if (carts != null)
            {
                return (carts);

            }

            return new List<Cart>();
        }
        public int Remove(int id , string ProductName)
        {
                Product P = Context.Products.FirstOrDefault(p => p.Name == ProductName);
            if (P !=null)
            {
                if (P.Stock >0)
                {
                    P.Stock -= 1;
                }

            }


            Cart cart = Context.Carts.FirstOrDefault(c => c.ID == id);
            if (cart != null)
            {
                Context.Carts.Remove(cart);
            }
            return Context.SaveChanges();


        }


    }
}
