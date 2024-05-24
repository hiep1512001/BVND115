namespace BVND115.View.Home;

public partial class TabPhieuKham : ContentPage
{
	public TabPhieuKham()
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
}