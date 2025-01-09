using ECommerce_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerce_App.ViewModel
{
    public class CardViewModel : BaseViewModel
    {
        public ObservableCollection<CardItem> CartItems { get; set; } = new ObservableCollection<CardItem>();
        public ICommand CheckoutCommand { get; set; }
        public int TotalItems => CartItems.Sum(item => item.Quantity);
        public decimal Subtotal => CartItems.Sum(item => item.Quantity * item.ProductPrice);
        public decimal Discount => 5; // Example static discount
        public decimal DeliveryCharges => 2; // Example static delivery charge
        public decimal Total => Subtotal - Discount + DeliveryCharges;

        public CardViewModel()
        {
            // Initialize with example data
            CartItems.Add(new CardItem
            {
                ProductImage = "watch.jpg",
                ProductName = "Watch",
                ProductBrand = "Rolex",
                ProductPrice = 40,
                Quantity = 2
            });
            CartItems.Add(new CardItem
            {
                ProductImage = "buds.jpg",
                ProductName = "Airpods",
                ProductBrand = "Apple",
                ProductPrice = 333,
                Quantity = 1
            });
            CartItems.Add(new CardItem
            {
                ProductImage = "hoodie.jpg",
                ProductName = "Hoodie",
                ProductBrand = "Puma",
                ProductPrice = 50,
                Quantity = 2
            });

            CheckoutCommand = new Command(OnCheckout);
        }

        private void OnCheckout()
        {
            // Implement your checkout logic here
            Application.Current.MainPage.DisplayAlert("Checkout", "Proceeding to Checkout", "OK");
        }
    }
}
