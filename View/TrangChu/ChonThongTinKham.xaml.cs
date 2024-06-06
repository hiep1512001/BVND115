using BVND115.View.Home;

namespace BVND115.View.TrangChu;

public partial class ChonThongTinKham : ContentPage
{
    private string TrangThaiDatKham = "datkham";
    private int ktra = 0;
	public ChonThongTinKham()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ktra = 0;
        Btn_BacSi.Text = "Chọn bác sĩ\nNguyễn Hoàng Hiệp\nNội tổng quát";
        Btn_DichVu.Text = "Chọn dịch vụ\nNgoại tổng quát";
        Btn_NgayKham.Text = "Chọn ngày khám\n04/06/2024";
        Btn_GioiKham.Text = "Chọn ngày đăng ký tiếp nhận\n08:00 - 09:00";
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
    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Btn_BacSi_Clicked(object sender, EventArgs e)
    {

    }

    private void Btn_TiepTuc_Clicked(object sender, EventArgs e)
    {
        ktra = 1;
        Navigation.PushAsync(new TabHoSo(TrangThaiDatKham));
    }
}