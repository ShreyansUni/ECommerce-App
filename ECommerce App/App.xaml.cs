using ECommerce_App.Pages;
using Microsoft.Maui.Devices;

namespace ECommerce_App;

public partial class App : Application
{
    //private readonly List<string> allowedDeviceIdentifiers = new List<string>
    //{
    //    "CPH1893"
    //};
    public App()
    {
        InitializeComponent();

        //string currentDeviceIdentifier = GetDeviceIdentifier();

        //if (IsDeviceAllowed(currentDeviceIdentifier))
        //{
        //    MainPage = new MainPage();
        //}
        //else
        //{
        //    MainPage = new RestrictedAccessPage();
        //}
    }

    //private string GetDeviceIdentifier()
    //{
    //    return DeviceInfo.Model;
    //}

    //private bool IsDeviceAllowed(string deviceIdentifier)
    //{
    //    return allowedDeviceIdentifiers.Contains(deviceIdentifier);
    //}
}
