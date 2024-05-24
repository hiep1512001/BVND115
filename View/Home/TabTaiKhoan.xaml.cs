

namespace BVND115.View.Home;
public partial class TabTaiKhoan : ContentPage
{
	public TabTaiKhoan()
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

    private async void Imb_DangXuat_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Thông báo", "Bạn muốn đăng xuất tài khoản", "Có", "Không");
        if (result)
        {
            NavigationPage NavPage = new NavigationPage(new BVND115.View.Login.Login());
            App.Current.MainPage = NavPage;
        }   
    }
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Thông báo", "Chức năng đang phát triển", "OK");
    }
}