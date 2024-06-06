namespace BVND115.View.HoSo;

public partial class ThongTinHoSo : ContentPage
{
    private string TrangThaiDatKham = "datkham";
    private string TrangThai="";
    public ThongTinHoSo()
	{
		InitializeComponent();
	}
    public ThongTinHoSo(string trangthai)
    {
        InitializeComponent();
        this.TrangThai=trangthai;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Edit_XML();
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
    public void Edit_XML()
    {
        if (this.TrangThai.Equals(TrangThaiDatKham))
        {
            Btn_Click.Text = "CHỌN HỒ SƠ";
            Imb_Xoa.IsVisible = false;
            Lbl_Xoa.IsVisible = false;
        }
        else
        {
            Btn_Click.Text = "CHỈNH SỬA HỒ SƠ";
            Imb_Xoa.IsVisible = true;
            Lbl_Xoa.IsVisible = true;
        }
    }
    private void Btn_Click_Clicked(object sender, EventArgs e)
    {
        if (this.TrangThai.Equals(TrangThaiDatKham))
        {
            App.Current.MainPage.DisplayAlert("Thông báo", "CHỌN HỒ SƠ", "OK");
        }
        else
        {
            App.Current.MainPage.DisplayAlert("Thông báo", "CHỈNH SỬA HỒ SƠ", "OK");          
        }
    }
}