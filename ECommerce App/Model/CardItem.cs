using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ECommerce_App.Model
{
    public class CardItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _quantity;
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                    OnPropertyChanged(nameof(TotalPrice));
                    QuantityChanged?.Invoke(this, EventArgs.Empty);

                    if (_quantity <= 0)
                    {
                        OnDelete();
                    }
                }
            }
        }

        public decimal TotalPrice => Quantity * ProductPrice;

        public ICommand IncreaseQuantityCommand => new Command(() => Quantity++);
        public ICommand DecreaseQuantityCommand => new Command(() => Quantity--);
        public ICommand DeleteCommand => new Command(() => OnDelete());

        public event EventHandler QuantityChanged;
        public event EventHandler Deleted;

        private void OnDelete()
        {
            Deleted?.Invoke(this, EventArgs.Empty);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
