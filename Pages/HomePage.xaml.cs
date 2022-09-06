using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Xamarin.Essentials;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;

namespace MobileEcommerce
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public List<Cart> carts = new List<Cart>();

       

        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string dataPath = Path.Combine(FileSystem.AppDataDirectory, "ProductData.json");

            if (File.Exists(dataPath))
            {
                List<Products> productList = new List<Products>();
                string cData = File.ReadAllText(dataPath);
                productList = JsonConvert.DeserializeObject<List<Products>>(cData);

                ProductListCollectionView.ItemsSource = productList;
            }

        }

        private async void Product_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductListPage());
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductCreatePage());
        }

        

        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Products selectedProduct = (Products)e.CurrentSelection.First();

            this.Navigation.PushAsync(new ProductViewPage(selectedProduct));
        }


        private void CartList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cart selectedCart = (Cart)e.CurrentSelection.First();
          
            this.Navigation.PushAsync(new UpdateCartPage(selectedCart));
        }

        private async void LoadCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductListPage());
        }

        private async void SaveCart_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductListPage());
        }
    }

}
