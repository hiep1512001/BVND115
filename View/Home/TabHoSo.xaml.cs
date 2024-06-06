
using BVND115.Model;
using BVND115.View.HoSo;

namespace BVND115.View.Home;

public partial class TabHoSo : ContentPage
{
    private int ktra = 0;
    private string TrangThaiDatKham = "datkham";
    private string TrangThai="";
    public List<HoSoKhamBenh> lstHoSoKhamBenh;
    public TabHoSo()
    {
        InitializeComponent();
        LoadHoSoKhamBenh();

    }
    public TabHoSo( string trangthai)
	{
		InitializeComponent();
        this.TrangThai=trangthai;       
        LoadHoSoKhamBenh();

    }
    protected override void OnAppearing()
    {
        
        base.OnAppearing();
        ktra = 0;
        EditXml();
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
        Lsv_HoSo.SelectedItems.Clear(); 
    }
    public void EditXml()
    {
        if (TrangThai.Equals(TrangThaiDatKham))
        {
            Lbl_TieuDe.Text = "VUI LÒNG CHỌN HỒ SƠ KHÁM";
        }
        else
        {
            Lbl_TieuDe.Text = "HỒ SƠ KHÁM BỆNH";
        }
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
        for(int i=0; i<3; i++)
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
        if (TrangThai.Equals(TrangThaiDatKham))
        {
            Navigation.PopAsync();
            return true;
            
        }
        else
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
    private  async void Imb_ThemHoSo_Clicked(object sender, EventArgs e)
    {
        ktra = 1;
        AcI_load.IsVisible = true;
        AcI_load.IsRunning=true;
       await Navigation.PushAsync(new ThemHoSo());
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ktra = 1;
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        await Navigation.PushAsync(new ThemHoSo());
    }

    private async void Lsv_HoSo_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        ktra = 1;
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        await Navigation.PushAsync(new ThongTinHoSo(TrangThai));
    }
    protected override async void OnDisappearing()
    {
        if (TrangThai.Equals(TrangThaiDatKham))
        {
            if (ktra == 0)
            {
                base.OnDisappearing();
                await Navigation.PopToRootAsync();
            }
        }
    }
}