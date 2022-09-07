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

namespace MobileEcommerce.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListPage : ContentPage
    {
        public ProductListPage()
        {
            InitializeComponent();
        }

        
        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductCreatePage());
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (File.Exists(Path.Combine(FileSystem.AppDataDirectory, "ProductData.json")))
            {
                List<Products> productList = new List<Products>();
                
                string cd = File.ReadAllText(dfPath);
                productList = JsonConvert.DeserializeObject<List<Products>>(cd);

                ProductListCollectionView.ItemsSource = productList;
            }
        }


        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Products selectedProduct = (Products)e.CurrentSelection.First();
            this.Navigation.PushAsync(new ProductViewPage(selectedProduct));
        }
    }
}
