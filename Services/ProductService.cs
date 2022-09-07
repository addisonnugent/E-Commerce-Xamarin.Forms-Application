using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobileEcommerce.Services
{
    public class ProductService : Service<Products>, IProductService
    {
        
        public List<Products> GetSortAll(int CategoryId)
        {
             var _result = Task.Run(() => client.GetStringAsync(Url + CategoryId)).Result;

            entities = JsonConvert.DeserializeObject<List<Products>>(_result, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return e;
        }


      List<Products> e;

        public string ProdCount()
        {
        }

        public string Add()
        {
        
        }
    }
}
