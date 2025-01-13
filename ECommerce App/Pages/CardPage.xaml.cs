using ECommerce_App.Model;
using ECommerce_App.ViewModel;

namespace ECommerce_App.Pages;

public partial class CardPage : ContentPage
{
    private CardViewModel _viewModel;

    public CardPage(CardViewModel cardViewModel)
	{
		InitializeComponent();
        _viewModel = cardViewModel;
        BindingContext = _viewModel;
    }

    private void OnClickedCardButton(object sender, EventArgs e)
    {
        var product = (Product)BindingContext;

        _viewModel.CartItems.Add(new CardItem
        {
            ProductImage = product.Image,
            ProductName = product.Name,
            ProductPrice = decimal.TryParse(product.Price, out var price) ? price : 0m,
            Quantity = 1
        });

        Application.Current.MainPage.DisplayAlert("Added to Cart", $"{product.Name} has been added to your cart.", "OK");
    }

    private async void OnBackCardButton(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}