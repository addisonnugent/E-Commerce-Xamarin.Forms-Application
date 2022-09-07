using System;
using System.Collections.Generic;
using System.IO;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MobileEcommerce.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
  
    public partial class ProductViewPage : ContentPage
    {
        public ProductViewPage(Products p)
        {
            InitializeComponent();
  
          pn.Text = p.Name;
            pd.Text= p.Description;
            pi.Text = p.Id.ToString();
         
            pp.Text = $"${p.Price};
            
            pq.Text =p.Quantity;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }

       
        private async void Remove(int p)
        {
            string dp = Path.Combine(FileSystem.AppDataDirectory, "ProductData.json");
            if (File.Exists(dp))
            {
                List<Products> productList = new List<Products>();
                string cd = File.ReadAllText(dp);
               productList = JsonConvert.DeserializeObject<List<Products>>(cd);

                var v = productList.Remove(productList.First(x => x.Id == ProdId));

                if (productList.Exists(x => x.Id == ProdId))
                {
                    return;
                }
               
              
                string prods = JsonConvert.SerializeObject(productList);
                File.WriteAllText(dp, prods);
          
                await this.Navigation.PopAsync();
                
            }
            else
            {
                await this.Navigation.PopAsync();
            }
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
           
        
                Remove(Convert.ToInt32(this.pi.Text));
          
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            var ep = new Products
            {
                Id = Convert.ToInt32(this.pi.Text),
                Name = this.pn.Text,
                Description = this.pd.Text,
                Price = Convert.ToDecimal(this.pp.Text.Replace("$", String.Empty))
                Quantity = this.pq.Text;
            };
            
            await this.Navigation.PushAsync(new ProductEditPage(ep));
        }
    }
}
