using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;

namespace MobileEcommerce.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public ProductViewModel(Product prod)
        {
            pn.Value = prod.Name;
            pd.Value = prod.Description;
            pp.Value = prod.Price;
            pq.Value = prod.Quantity;
            pb.Value = prod.Bogo;
         }
     }
}
