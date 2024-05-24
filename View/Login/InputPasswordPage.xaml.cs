using BVND115.View.Home;

namespace BVND115.View.Login;

public partial class InputPasswordPage : ContentPage
{
	public InputPasswordPage()
	{
		InitializeComponent();
	}
    public InputPasswordPage(string sdt)
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    public void BtnShowPass_Click(object sender, EventArgs e)
    {
        if (EtrPassword.IsPassword == true)
        {
            EtrPassword.IsPassword = false;
            Img_Password.Source = "icon_hide_pass";
        }
        else
        {
            EtrPassword.IsPassword = true;
            Img_Password.Source = "icon_showpassword";
        }
    }
    public void LblForgetPas_Tap(object sender, EventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Thông báo", "Bạn quên mật khẩu", "Ok");
    }
    public void LblExitAccount_Tap(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Btn_Nhap_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (EtrPassword.Text == null)
            {
                EtrPassword.Text = null;
                App.Current.MainPage = new HomeUserPage();

            }
            else
            {
                EtrPassword.Text = null;
                App.Current.MainPage = new AppShell();
            }

        }
        catch
        {

        }
    }

    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}