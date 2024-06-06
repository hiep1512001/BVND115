

using BVND115.View.Home;

namespace BVND115.View.TrangChu;

public partial class ChonGioKham : ContentPage
{
    private string TrangThaiDatKham = "datkham";
    private int ktra =0;
	public ChonGioKham()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ktra = 0;
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    protected override async void OnDisappearing()
    {
        if (ktra == 0)
        {
            base.OnDisappearing();
            await Navigation.PopToRootAsync();
        }
    }
    public void DatGioiKham( int i)
    {
        ktra = 1;

        Navigation.PushAsync(new TabHoSo(TrangThaiDatKham));
    }
    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Btn_Gioi7_Clicked(object sender, EventArgs e)
    {
        DatGioiKham(1);
    }

    private void Btn_Gioi8_Clicked(object sender, EventArgs e)
    {
        DatGioiKham(1);
    }

    private void Btn_Gioi9_Clicked(object sender, EventArgs e)
    {
        DatGioiKham(1);
    }

    private void Btn_Gioi10_Clicked(object sender, EventArgs e)
    {
        DatGioiKham(1);
    }

    private void Btn_Gioi11_Clicked(object sender, EventArgs e)
    {
        DatGioiKham(1);
    }

    private void Btn_Gioi13_Clicked(object sender, EventArgs e)
    {
        DatGioiKham(1);
    }

    private void Btn_Gioi14_Clicked(object sender, EventArgs e)
    {
        DatGioiKham(1);
    }

    private void Btn_Gioi15_Clicked(object sender, EventArgs e)
    {
        DatGioiKham(1);
    }
}