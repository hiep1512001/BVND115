using BVND115.Model;
using BVND115.Service;
using BVND115.View.TrangChu;

namespace BVND115.View.Home;

public partial class TabThongBao : ContentPage
{
	public TabThongBao()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    protected override bool OnBackButtonPressed()
    {
        Task<bool> answer = DisplayAlert("Thông báo", "Bạn muốn thoát khỏi ứng dụng", "Có", "Không");
        answer.ContinueWith(task =>
        {
            if (task.Result)
            {
                Application.Current.Quit();
            }
        });
        return true;
    }

    private async void Btn_DatKhamBacSi_Clicked(object sender, EventArgs e)
    {


    }
}