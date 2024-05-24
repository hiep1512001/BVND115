using BVND115.View.Home;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using System.Xml.XPath;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using static System.Net.WebRequestMethods;

namespace BVND115.View.Login;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
        this.Behaviors.Add(new StatusBarBehavior
        {
            StatusBarColor = Colors.Black,
            StatusBarStyle = StatusBarStyle.LightContent
        });
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    int Kt()
    {
        int i = 1;
        if (EtrCCCD.Text == null)
        {
            i = 0;
            EtrCCCD.PlaceholderColor = Colors.Red;
            EtrCCCD.Placeholder = "Chưa nhập số điện thoại";
        }
        else
        {

        }
        return i;
    }
    public void BtnLogin_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new InputPasswordPage());
/*            if (EtrCCCD.Text != null)
            {
                AcI_load.IsVisible = true;
                AcI_load.IsRunning = true;
                EtrCCCD.Text = null;
                App.Current.MainPage = new HomeUserPage();

            }
            else
            {
                AcI_load.IsVisible = true;
                AcI_load.IsRunning = true;
                EtrCCCD.Text = null;
                App.Current.MainPage = new AppShell();
            }*/

        }
        catch
        {

        }
    }
    public void BtnFLogin_Clicked (object sender, EventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Thông báo", "Chức năng đang phát triển", "Ok");
    }
    public void BtnGLogin_Clicked(Object sender, EventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Thông báo", "Chức năng đang phát triển", "Ok");
    }
    public void BtnZLogin_Clicked(object obj, EventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Thông báo", "Chức năng đang phát triển", "Ok");
    }

}