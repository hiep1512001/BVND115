namespace BVND115.View.HoSo;

public partial class ThongTinHoSo : ContentPage
{
	public ThongTinHoSo()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await Navigation.PopToRootAsync();

    }
}