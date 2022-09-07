using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileEcommerce.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateCartPage : ContentPage
    {


        CartService cartService = new CartService();

        public Cart c { get; set; }
        public Action a { get; set; }

        public UpdateCartPage(Cart cart, Action action = null)
        {
            InitializeComponent();
            
            c = cart;
            CartUpdateLoad();
            a = action;

        }

        public void CartUpdateLoad()
        {

            pn.Text = c.Count.ToString();
            
            pp.Text = c.product.Price;
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {
           
            await Navigation.PopModalAsync();
        }

       

        
        private void Minus_Clicked(object sender, EventArgs e)
        {
            var number = int.Parse(pn.Text);
            if (number != 0)
            {
                n = n-1;
                pn.Text = number.ToString();
            }

        }
        
        private void Plus_Clicked(object sender, EventArgs e)
        {
            var n = int.Parse(pn.Text);
            n = n+1;
            
            
            pn.Text = number.ToString();
        }


 private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
    }
}
