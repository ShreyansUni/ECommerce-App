using ECommerce_App.Model;
using ECommerce_App.ViewModel;

namespace ECommerce_App.Pages;

public partial class ProductDetailsPage : ContentPage
{
    private Printer _selectedPrinter;
    private CardViewModel _cartViewModel;

    public ProductDetailsPage(Printer selectedPrinter, CardViewModel cardViewModel)
    {
        InitializeComponent();
        _selectedPrinter = selectedPrinter;
        _cartViewModel = cardViewModel;
        BindingContext = selectedPrinter;
    }

    public Printer SelectedPrinter
    {
        get => _selectedPrinter;
        set
        {
            _selectedPrinter = value;
            OnPropertyChanged();
        }
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        if (BindingContext is Printer selectedPrinter)
        {
            _cartViewModel.AddToCart(selectedPrinter);
            Application.Current.MainPage.DisplayAlert("Success", $"{selectedPrinter.Name} added to cart.", "OK");
            await Navigation.PushAsync(new CardPage(_cartViewModel));
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "The BindingContext is not a Printer.", "OK");
        }
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}
