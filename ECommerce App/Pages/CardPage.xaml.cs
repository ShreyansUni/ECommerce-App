using ECommerce_App.Model;
using ECommerce_App.ViewModel;

namespace ECommerce_App.Pages;

public partial class CardPage : ContentPage
{
    private CardViewModel _viewModel;

    public CardPage()
	{
		InitializeComponent();
        _viewModel = new CardViewModel();
        BindingContext = _viewModel;
    }

    private void OnClickedCardButton(object sender, EventArgs e)
    {
        // Assuming 'BindingContext' is the product that should be added
        var product = (Product)BindingContext; // Replace with actual product data model if needed

        // Add the selected product to the CartItems collection
        _viewModel.CartItems.Add(new CardItem
        {
            ProductImage = product.Image, // Use the actual property names from your product data model
            ProductName = product.Name,
            //ProductBrand = product.Brand,
            ProductPrice = decimal.TryParse(product.Price, out var price) ? price : 0m,
            Quantity = 1
        });

        // Optionally, display a message to indicate the product has been added
        Application.Current.MainPage.DisplayAlert("Added to Cart", $"{product.Name} has been added to your cart.", "OK");
    }

    private async void OnBackCardButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}