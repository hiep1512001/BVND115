using BVND115.Model;
using BVND115.Service;
using System.Threading.Tasks;

namespace BVND115.View.TrangChu;

public partial class DatKhamBacSi : ContentPage
{
    public List<BacSi> lstBacSi;
    public List<BacSi> lstBacSi_KYC;
    public List<BacSi> lstBacSi_VIP;
    public List<BacSi> lstBacSi_BHYT;

    private int ktra = 0;
    private readonly string TrangThaiTatCa = "TatCa";
    private readonly string TrangThaiVip = "VIP";
    private readonly string TrangThaiKYC = "KYC";
    private readonly string TrangThaiBHYT = "BHYT";
    private string TrangThai;
    public DatKhamBacSi()
	{
        InitializeComponent();
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
        EidtWidthSearchBar();
        TrangThai = TrangThaiTatCa;
        KhoiTaoListBacSi();

    }
    private void EidtWidthSearchBar()
    {
#if ANDROID
Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping("FullWidth", (handler, control) =>
{
	handler.PlatformView.MaxWidth = int.MaxValue;
});
#endif
    }
    public void KhoiTaoListBacSi()
    {
        lstBacSi = new List<BacSi>();
        lstBacSi_KYC = new List<BacSi>();
        lstBacSi_VIP = new List<BacSi>();
        lstBacSi_BHYT = new List<BacSi>();
            for (int i = 0; i < 10; i++)
            {
                BacSi bacSi = new BacSi();
                bacSi.MaBS = i.ToString();
                bacSi.TenBS = "BS.CKI KYC " + i.ToString();
                bacSi.GioiTinh = "Nam";
                bacSi.ChuyenKhoa = "Răng hàm mặt";
                bacSi.LichKham = "2,4,6"; 
                bacSi.GiaKham = "200000";
                lstBacSi_KYC.Add(bacSi);
            }
            for (int i = 0; i < 10; i++)
            {
                BacSi bacSi = new BacSi();
                bacSi.MaBS = i.ToString();
                bacSi.TenBS = "BS.CKI VIP " + i.ToString();
                bacSi.GioiTinh = "Nam";
                bacSi.ChuyenKhoa = "Răng hàm mặt";
                bacSi.LichKham = "2,4,6";
                bacSi.GiaKham = "200000";
                lstBacSi_VIP.Add(bacSi);
            }
            for (int i = 0; i < 10; i++)
            {
                BacSi bacSi = new BacSi();
                bacSi.MaBS = i.ToString();
                bacSi.TenBS = "BS.CKI BHYT " + i.ToString();
                bacSi.GioiTinh = "Nam";
                bacSi.ChuyenKhoa = "Răng hàm mặt";
                bacSi.LichKham = "2,4,6";
                bacSi.GiaKham = "200000";
                lstBacSi_BHYT.Add(bacSi);
            }

            lstBacSi.AddRange(lstBacSi_VIP);
            lstBacSi.AddRange(lstBacSi_KYC);
            lstBacSi.AddRange(lstBacSi_BHYT);
            BindingContext = lstBacSi.ToList();
    }

    private async void Lsv_BacSi_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        BacSi bacSi = e.SelectedItem as BacSi;
        if (bacSi != null)
        {
            ktra = 1;
            /*App.Current.MainPage.DisplayAlert("Thông báo", bacSi.MaBS.ToString(), "OK");*/
            await Navigation.PushAsync(new ChonNgayKham());
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
        ktra = 0;
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
    }

    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Btn_TatCa_Clicked(object sender, EventArgs e)
    {
        Btn_TatCa.TextColor=Colors.White;
        Btn_TatCa.BackgroundColor = Color.FromHex("#28C2D1");

        Btn_BHYT.TextColor = Colors.Black;
        Btn_BHYT.BackgroundColor = Color.FromHex("#dcded9");

        Btn_KhamYeuCau.TextColor = Colors.Black;
        Btn_KhamYeuCau.BackgroundColor = Color.FromHex("#dcded9");

        Btn_KhamVip.TextColor = Colors.Black;
        Btn_KhamVip.BackgroundColor = Color.FromHex("#dcded9");

        TrangThai = TrangThaiTatCa;
        BindingContext = lstBacSi;
    }

    private async void Btn_KhamVip_Clicked(object sender, EventArgs e)
    {
/*
        RestService restService = new RestService();
        List<BacSi> lstBacsi = new List<BacSi>();
        lstBacsi = await restService.RefreshDataAsync(lstBacsi);
        string kiemtraconten = restService.kiemtra;*/
        Btn_KhamVip.TextColor = Colors.White;
        Btn_KhamVip.BackgroundColor = Color.FromHex("#28C2D1");

        Btn_TatCa.TextColor = Colors.Black;
        Btn_TatCa.BackgroundColor = Color.FromHex("#dcded9");

        Btn_KhamYeuCau.TextColor = Colors.Black;
        Btn_KhamYeuCau.BackgroundColor = Color.FromHex("#dcded9");

        Btn_BHYT.TextColor = Colors.Black;
        Btn_BHYT.BackgroundColor = Color.FromHex("#dcded9");
            TrangThai = TrangThaiVip;
/*           await App.Current.MainPage.DisplayAlert("Thông báo", kiemtraconten.ToString() + "" +lstBacsi.Count().ToString(), "PK");*/
            BindingContext = lstBacSi_VIP;
    }

    private void Btn_KhamYeuCau_Clicked(object sender, EventArgs e)
    {
        Btn_KhamYeuCau.TextColor = Colors.White;
        Btn_KhamYeuCau.BackgroundColor = Color.FromHex("#28C2D1");

        Btn_KhamVip.TextColor = Colors.Black;
        Btn_KhamVip.BackgroundColor = Color.FromHex("#dcded9");

        Btn_TatCa.TextColor = Colors.Black;
        Btn_TatCa.BackgroundColor = Color.FromHex("#dcded9");

        Btn_BHYT.TextColor = Colors.Black;
        Btn_BHYT.BackgroundColor = Color.FromHex("#dcded9");

        TrangThai = TrangThaiKYC;
        BindingContext = lstBacSi_KYC;
    }

    private void Btn_BHYT_Clicked(object sender, EventArgs e)
    {
       
        Btn_BHYT.TextColor = Colors.White;
        Btn_BHYT.BackgroundColor = Color.FromHex("#28C2D1");

        Btn_KhamYeuCau.TextColor = Colors.Black;
        Btn_KhamYeuCau.BackgroundColor = Color.FromHex("#dcded9");

        Btn_KhamVip.TextColor = Colors.Black;
        Btn_KhamVip.BackgroundColor = Color.FromHex("#dcded9");

        Btn_TatCa.TextColor = Colors.Black;
        Btn_TatCa.BackgroundColor = Color.FromHex("#dcded9");

        TrangThai = TrangThaiBHYT;
        BindingContext = lstBacSi_BHYT ;
    }

    private void Srb_Search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            SearchBar searchBar = (SearchBar)sender;
            if (TrangThai.Equals(TrangThaiTatCa))
            {
                BindingContext = lstBacSi.Where(a => a.TenBS.ToLower().Contains(searchBar.Text.ToLower())).ToList();
            }
            else if (TrangThai.Equals(TrangThaiKYC)){
                BindingContext = lstBacSi_KYC.Where(a => a.TenBS.ToLower().Contains(searchBar.Text.ToLower())).ToList();
            }
            else if (TrangThai.Equals(TrangThaiVip))
            {
                BindingContext = lstBacSi_VIP.Where(a => a.TenBS.ToLower().Contains(searchBar.Text.ToLower())).ToList();
            }
            else if (TrangThai.Equals(TrangThaiBHYT))
            {
                BindingContext = lstBacSi_BHYT.Where(a => a.TenBS.ToLower().Contains(searchBar.Text.ToLower())).ToList();
            }
        }
        catch { 
        
        }
    }
    protected override async void OnDisappearing()
    {
        if (ktra == 0)
        {
            base.OnDisappearing();
            await Navigation.PopToRootAsync();
        }
    }
}