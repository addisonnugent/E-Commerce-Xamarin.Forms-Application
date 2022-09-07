using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Essentials;

namespace MobileEcommerce.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
  
    public partial class ProductCreatePage : ContentPage
    {
        public ProductCreatePage()
        {
            InitializeComponent();
        }
        

        private async void NewProduct_Clicked(object sender, EventArgs e)
        {
            int ProductId = Convert.ToInt32(pi.Text);
            string ProductName = pn.Text;
            string ProductDesc = pd.Text;
            
            Decimal ProductPrice = Convert.ToDecimal(pp.Value);
            Decimal ProductQuantity = Convert.ToDecimal(pq.Value);
           
          
                Products newProd = new Products()
                {
                    Id = ProductId,
                    Name = ProductName,
                    Price = ProductPrice,
                    Description = ProductDesc,
                    Quantity = (double)ProductQuantity
                };

               
                string dataFilePath = Path.Combine(FileSystem.AppDataDirectory, "ProductData.json");
                
                List<Products> productList = new List<Products>();

                if (File.Exists(dataFilePath))
                {
                    string cData = File.ReadAllText(dataFilePath);
                   productList = JsonConvert.DeserializeObject<List<Products>>(cData);

                    productList.Add(newProd);
                }
                else
                {
                    productList.Add(newProd);
                }

                File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(productList));

                await this.Navigation.PopAsync();
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var product = new Products();

            this.BindingContext = new ProductsViewModel(product);
        }

    }
}
