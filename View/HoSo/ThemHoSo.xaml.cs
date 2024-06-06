
/*using Android.OS;*/

/*using AndroidX.AppCompat.Widget;*/
using BVND115.Model;
using BVND115.View.Home;
using Camera.MAUI;
using Camera.MAUI.ZXing;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Mopups.Pages;
using Mopups.Services;
using System.Collections.Generic;
using System.Globalization;

namespace BVND115.View.HoSo;

public partial class ThemHoSo : ContentPage
{
/*#if ANDROID
    AppCompatEditText nativeEditText;
#endif*/
    private int Ktra=0;
    public  string qrcodeResult="";
    public  Xa xa=null;
    public  Huyen huyen = null;
    public  Tinh tinh = null;
    private List<NgheNghiep> lstNgheNghiep ;

    private Boolean ngay=false;
    private Boolean thang=false;
    public ThemHoSo()
	{
		InitializeComponent();


    }
    private async void ScanQRCode(object sender, EventArgs e)
    {
        Ktra = 1;
        var popup = new MopupScanQR();
        await MopupService.Instance.PushAsync(popup);
        qrcodeResult = await popup.PopupDismissedTask;
        LoadValueScan();
    }
    public void LoadValueScan()
    {
        if (!qrcodeResult.Equals(""))
        {
            try
            {
                string[] words = qrcodeResult.Split('|');
                string CCCD = words[0];
                string CMND = words[1];
                string Ten = words[2];
                string NgaySinh = words[3];
                string GioiTinh = words[4];
                string DiaChi = words[5];
                Etr_CCCD.Text = CCCD;
                Etr_Ten.Text = Ten;
                Etr_NgaySinh.TextColor = Colors.Black;
                Etr_NgaySinh.Text = XuLyNgaySinh(NgaySinh) + "/" + XuLyThangSinh(NgaySinh) + "/" + XuLyNamSinh(NgaySinh);
                XuLyGioiTinh(GioiTinh);
                Etr_QuocGia.Text = "Việt Nam";
                Etr_Tinh.Text = XuLyTinh(DiaChi);
                Etr_Tinh.TextColor = Colors.Black;
                Etr_Huyen.Text = XuLyHuyen(DiaChi);
                Etr_Huyen.TextColor = Colors.Black;
                Etr_xa.Text = XuLyXa(DiaChi);
                Etr_xa.TextColor=Colors.Black;
                Etr_DiaChi.Text =XuLyDiaChi(DiaChi);
                qrcodeResult = "";
            }
            catch
            {
            }
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
    }
    private void Btn_ThemHoSo_Clicked(object sender, EventArgs e)
    {
       /* await Shell.Current.GoToAsync(nameof(TabHoSo));*/
    }
    public string XuLyNgaySinh(string ngaysinh)
    {
        string value = ngaysinh.Substring(0,2);
        return value;
    }
    public string XuLyThangSinh(string ngaysinh)
    {
        string value = ngaysinh.Substring(2, 2);
        return value;
    }
    public string XuLyNamSinh(string ngaysinh)
    {
        string value = ngaysinh.Substring(4, 4);
        return value;
    }
    public string XuLyTinh(string DiaChi)
    {
        string[] words = DiaChi.Split(',');
        string value= words[3];
        return value;
    }
    public string XuLyHuyen(string DiaChi)
    {
        string[] words = DiaChi.Split(',');
        string value = words[2];
        return value;
    }
    public string XuLyXa(string DiaChi)
    {
        string[] words = DiaChi.Split(',');
        string value = words[1];
        return value;
    }
    public string XuLyDiaChi(string DiaChi)
    {
        string[] words = DiaChi.Split(',');
        string value = words[0];
        return value;
    }
    public void XuLyGioiTinh(string GioiTinh)
    {
        if (!GioiTinh.Equals(""))
        {
            if (GioiTinh == "Nam")
            {
                Rdb_Nam.IsChecked = true;
            }
            else
            {
                Rdb_Nu.IsChecked = true;    
            }
        }
    }
    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    public async void Etr_Tinh_Click(object sender, TappedEventArgs e)
    {
        Ktra = 1;
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        ListTinh listTinh = new ListTinh();
        await Navigation.PushAsync(listTinh);
        var rvalue = await listTinh.PopupDismissedTask;
       
        if (rvalue != null)
        {
            Etr_Tinh.TextColor = Colors.Black;
            Etr_Tinh.Text = rvalue.TenTinh.ToString();
        }
       
    }
    public async void Etr_Huyen_Click(object sender, TappedEventArgs e)
    {
        Ktra = 1;
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        ListHuyen listHuyen= new ListHuyen();
        await Navigation.PushAsync(listHuyen);
        var rvalue = await listHuyen.PopupDismissedTask;
        
        if (rvalue != null)
        {
            Etr_Huyen.TextColor = Colors.Black;
            Etr_Huyen.Text = rvalue.TenHuyen.ToString();
        }
       

    }
    public async void Etr_Xa_Click(object sender, TappedEventArgs e)
    {
        Ktra = 1;
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        ListXa listxa= new ListXa();
        await Navigation.PushAsync(listxa);
        var rvalue = await listxa.PopupDismissedTask;
        
        if (rvalue != null)
        {
            Etr_xa.TextColor = Colors.Black;
            Etr_xa.Text = rvalue.TenXa.ToString();
        }
            
    }

/*    private void Etr_NgaySinh_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Etr_NgaySinh.Text != null ) { 
            if(Etr_NgaySinh.Text.Length ==  2 && ngay == false)
            {
                Etr_NgaySinh.Text = Etr_NgaySinh.Text + "/";
                Etr_NgaySinh.CursorPosition = Etr_NgaySinh.Text.Length;
                ngay = true;
*//*                var looper = Looper.MyLooper();
                if (looper != null)
                {
                    var handler = new Handler(looper);
                    handler.Post(() =>
                    {
                        Etr_NgaySinh.Text = Etr_NgaySinh.Text + "/";
                        Etr_NgaySinh.CursorPosition = Etr_NgaySinh.Text.Length;
                        ngay = true;
                    });
                }
                else
                {
                    Etr_NgaySinh.Text = Etr_NgaySinh.Text + "/";
                    Etr_NgaySinh.CursorPosition = Etr_NgaySinh.Text.Length;
                    ngay = true;
                }*//*
            }
            if (Etr_NgaySinh.Text.Length == 5 && thang == false)
            {
                Etr_NgaySinh.Text = Etr_NgaySinh.Text + "/";
                Etr_NgaySinh.CursorPosition = Etr_NgaySinh.Text.Length;
                thang = true;
*//*                var looper = Looper.MyLooper();
                if (looper != null)
                {
                    var handler = new Handler(looper);
                    handler.Post(() =>
                    {
                        Etr_NgaySinh.Text = Etr_NgaySinh.Text + "/";
                        Etr_NgaySinh.CursorPosition = Etr_NgaySinh.Text.Length;
                        thang = true;
                    });
                }
                else
                {
                    Etr_NgaySinh.Text = Etr_NgaySinh.Text + "/";
                    Etr_NgaySinh.CursorPosition = Etr_NgaySinh.Text.Length;
                    thang = true;
                }
*//*

            }
            if (Etr_NgaySinh.Text.Length < 2)
            {
                ngay = false;
            }
            if (Etr_NgaySinh.Text.Length < 5)
            {
                thang=false;
            }
        }
    }*/
    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        if (Ktra == 0)
        {
            await Navigation.PopToRootAsync();
        }

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        datepicker.IsOpen = true;
    }

    private void datepicker_OkButtonClicked(object sender, EventArgs e)
    {
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        Etr_NgaySinh.TextColor=Colors.Black;
        Etr_NgaySinh.Text= datepicker.SelectedDate.ToString("dd/MM/yyyy");
        datepicker.IsOpen = false;
    }

    private void datepicker_CancelButtonClicked(object sender, EventArgs e)
    {
        datepicker.IsOpen = false;
    }

    private void datepicker_Opened(object sender, EventArgs e)
    {
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
    }

    private void datepicker_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
    }
}