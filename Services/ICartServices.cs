using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library.MobileEcommerce.Services
{
	
	public interface ICartServices
	{
        	public List<CartService> SavedCartsList { get; }

        	ObservableCollection<Item> GetCartProds();
        	void SaveCart(ObservableCollection<Item> carts);

        	void AddToCart(Product myprod);

        	void RemoveFromCart(int id);

        	void Clear();
   	}
}
