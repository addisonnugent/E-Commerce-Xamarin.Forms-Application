using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Globalization;
using ObjCRuntime;

namespace Library.MobileEcommerce
{
    public class CartService : Service<Cart>, ICartService
    {
        private static object current;

        public List<Cart> Carts(int id)
        {
            List<Cart> entities = null;
            
            try
            {
                client.DefaultRequestHeaders.Add();
                var _result = Task.Run(() => client.GetStringAsync(Url + id)).Result;

                e = JsonConvert.DeserializeObject<List<Cart>>(_result, new JsonSerializerSettings
                {
                   NullValueHandling = NullValueHandling.Ignore
                });
            }
            catch (Exception ex)
            {throw ex;}
            return es;
        }

        
        internal Task UpdateAsync(Cart cart)
        {
            throw new NotImplementedException();
        }
     

        public string CartConfirm(int CartConfirm)
        {
            try
            {
                var response = Task.Run(() => client.GetAsync(Url + CartConfirm)).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string All(int id)
        {
            try
            {
                var r = Task.Run(() => client.GetAsync(Url + id)).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static CartService Current   // singletons
        {
            get
            {
                if (current == null)
                {
                    current = new CartService();
                }
                return (CartService)current;
            }
        }
}
