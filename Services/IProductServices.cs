using System.Collections.Generic;
using XamarinCapstoneProj.Models;

namespace MobileEcommerce.Services
{
	public interface IProductServices : IService<Products>
	{
		List<Products> GetSortedAll(int Id);
		string Add();
		string ProdCount();
	}
}
