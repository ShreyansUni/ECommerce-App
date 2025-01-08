using ECommerce_App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_App.ViewModel
{
    public class DiscountViewModel
    {
        public ObservableCollection<DiscountItem> Discounts { get; set; }

        public DiscountViewModel()
        {
            Discounts = new ObservableCollection<DiscountItem>
            {
                new DiscountItem { Image = "discount_image1.jpg", Title = "Discount 1", Description = "Get 20% off on your first purchase." },
                new DiscountItem { Image = "discount_image2.jpg", Title = "Discount 2", Description = "Save 15% on selected items." },
                new DiscountItem { Image = "discount_image3.jpg", Title = "Discount 3", Description = "Exclusive offer: 10% off on printers." },
                new DiscountItem { Image = "discount_image4.jpg", Title = "Discount 4", Description = "Special: 30% off on electronics." }
            };
        }
    }
}
