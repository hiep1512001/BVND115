
using BVND115.Model;
using BVND115.View.HoSo;

namespace BVND115.View.Home;

public partial class TabHoSo : ContentPage
{
    public List<HoSoKhamBenh> lstHoSoKhamBenh;
	public TabHoSo()
	{
		InitializeComponent();
     
        LoadHoSoKhamBenh();

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }

    private  async void Lsv_HoSo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        HoSoKhamBenh hoSoKhamBenh = e.SelectedItem as HoSoKhamBenh;
        if (hoSoKhamBenh != null)
        {
            AcI_load.IsVisible = true;
            AcI_load.IsRunning = true;
            await Navigation.PushAsync(new ThongTinHoSo());
/*            App.Current.MainPage.DisplayAlert("Thông báo", hoSoKhamBenh.MaHS.ToString(), "OK");*/
        }

    }
    public  void LoadHoSoKhamBenh()
    {
        lstHoSoKhamBenh = new List<HoSoKhamBenh> ();
        for(int i=0; i<5; i++)
        {
            HoSoKhamBenh hoSoKhamBenh= new HoSoKhamBenh();
            hoSoKhamBenh.MaHS = i.ToString();
            hoSoKhamBenh.Ten = "Nguyễn Văn A" + i.ToString();
            hoSoKhamBenh.SDT = "0812356946";
            hoSoKhamBenh.NgaySinh = "15/01/2001";
            hoSoKhamBenh.DiaChi = "Ấp 3, Mỹ Yên, Bến Lức, Long An";
            lstHoSoKhamBenh.Add(hoSoKhamBenh);
        }
        BindingContext = lstHoSoKhamBenh;
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
    private  async void Imb_ThemHoSo_Clicked(object sender, EventArgs e)
    {
        AcI_load.IsVisible = true;
        AcI_load.IsRunning=true;
        Navigation.PushAsync(new ThemHoSo());
    }
}