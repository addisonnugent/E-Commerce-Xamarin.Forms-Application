using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MobileEcommerce.ViewModels
{
    public class CartViewModel

    {
        public ObservableCollection<ProductsViewModel> _cart { get; set; } = new ObservableCollection<ProductsViewModel>();
        private CartService cartService;
        public ProductsViewModel SelectedProduct { get; set; }
        public double Size { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Fname { get; set; }


        public CartViewModel()
        {
            cartService = CartService.Current;
        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ObservableCollection<ProductsViewModel> Cart
        {
            get
            {
                if (cartService == null)
                {
                    return new ObservableCollection<ProductsViewModel>();
                }
                return new ObservableCollection<ProductsViewModel>();
            }
        }

        public void Add(ProductsViewModel pt)
        {
            ContentPage context = new ProductCreatePage();
            NotifyPropertyChanged("Inventory");
        }


        public async Task Load()
        {
            cartService.Load(SelectedCart.CartName);
            NotifyPropertyChanged("Inventory");
        }

        public async Task New()
        {
            ContentPage context = new HomePage();
            NotifyPropertyChanged("Cart");
        }

        public async Task AddD()
        {
            ContentPage context = new HomePage();
            NotifyPropertyChanged("Inventory");
        }

        public async Task LoadD()
        {
            ContentPage context = new HomePage();
            NotifyPropertyChanged("Cart");
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(Cart);
        }
    }
}
