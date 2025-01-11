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

        public int TotalItems => CartItems.Sum(item => item.Quantity);
        public decimal Subtotal => CartItems.Sum(item => item.Quantity * item.ProductPrice);
        public decimal Discount => 5;
        public decimal DeliveryCharges => 2;
        public decimal Total => Subtotal - Discount + DeliveryCharges;

        public void AddToCart(Printer printer)
        {
            var existingItem = CartItems.FirstOrDefault(item => item.ProductName == printer.Name);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                CartItems.Add(new CardItem
                {
                    ProductImage = printer.Img,
                    ProductName = printer.Name,
                    ProductPrice = decimal.TryParse(printer.Rate.ToString(), out var price) ? price : 0,
                    Quantity = 1
                });
            }

            OnPropertyChanged(nameof(CartItems));
            OnPropertyChanged(nameof(TotalItems));
            OnPropertyChanged(nameof(Subtotal));
            OnPropertyChanged(nameof(Total));
        }
    }
}
