using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileEcommerce
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductEditPage : ContentPage
    {
        public ProductEditPage(Products p)
        {
            InitializeComponent();
            this.pi.Text = Convert.ToString(prod.Id);
            this.pp.Text = Convert.ToString(p.Price);
            this.pn.Text = p.Name;
            this.pd.Text = p.Description;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void Update_Clicked(object sender, EventArgs e)
        {
            int prodId = Convert.ToInt32(this.id.Text);
            string prodN = this.pn.Text;
            string prodDe= this.pd.Text;

            Decimal prodP = Convert.ToDecimal(this.pp.Text);

            var editedp = new Products
                {
                    Id = prodId,
                    Name = prodN,
                    Description = prodD,
                    Price = prodP    
                };

                helper(editedp);
        }

        private async void helper(Products prod)
        {
           string dh = Path.Combine(FileSystem.AppDataDirectory, "ProductData.json");
                if (File.Exists(dh))
                {
                    List<Products> productList = new List<Products>();
                 
                    string currentDataJson = File.ReadAllText(dataPath);
                    productList = JsonConvert.DeserializeObject<List<Products>>(cData);

                    productList.First(p => p.Id == prod.Id).Quantity = prod.Quantity;
                    productList.First(p => p.Id == prod.Id).Name = prod.Name;
                    productList.First(p => p.Id == prod.Id).Description = prod.Description;
                    productList.First(p => p.Id == prod.Id).Price = prod.Price;
                    string productL = JsonConvert.SerializeObject(productList);
                    File.WriteAllText(dataPath, productL);

                    Page vp = this.Navigation.NavigationStack.First(x => x.GetType() == typeof(ProductViewPage));
                    this.Navigation.RemovePage(vp);
                    await this.Navigation.PopAsync();
                }
            }
        }
    }
}
