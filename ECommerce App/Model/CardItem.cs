using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerce_App.Model
{
    public class CardItem
    {
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public ICommand IncreaseQuantityCommand => new Command(() => Quantity++);
        public ICommand DecreaseQuantityCommand => new Command(() => { if (Quantity > 1) Quantity--; });
        public ICommand DeleteCommand => new Command(() => OnDelete());

        private void OnDelete()
        {
            Application.Current.MainPage.DisplayAlert("Deleted", $"{ProductName} removed from cart", "OK");
        }
    }
}
