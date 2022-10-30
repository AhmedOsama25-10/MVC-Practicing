using Mobi__Shop.Models;
using System.Collections.Generic;

namespace Mobi__Shop.Services
{
    public interface ICartRepository
    {
        int Add(Cart cart);
        List<Cart> GetAll(string username);
        int Remove(int id,string ProductName);
    }
}