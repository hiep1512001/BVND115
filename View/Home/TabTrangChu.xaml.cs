﻿
using BVND115.Model;
using BVND115.View.TrangChu;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Mopups.Pages;
using Mopups.Services;

namespace BVND115.View.Home;

public partial class TabTrangChu : ContentPage
{
	public TabTrangChu()
	{
		InitializeComponent();
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
    protected override void OnAppearing()
    {
        base.OnAppearing();

        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
        Scr_Noidung.IsVisible = true;
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Thông báo", "Đây là tư vấn khám bệnh", "OK");
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        App.Current.MainPage.DisplayAlert("Thông báo", "Đây là Nguyễn Hoàng Hiệp", "OK");
    }

 


    private async void Btn_DatKhamBacSi_Clicked(object sender, EventArgs e)
    {
        popup.Dismiss();
        Scr_Noidung.IsVisible=false;
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        await Navigation.PushAsync(new DatKhamBacSi());
    }

    private async void Btn_XemThem_Clicked(object sender, EventArgs e)
    {
        popup.Show();
/*        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        MopupsChucNang popup = new MopupsChucNang();
        await MopupService.Instance.PushAsync(popup);
        string rvalue = await popup.PopupDismissedTask;
        if(rvalue != null)
        {
            if(rvalue.Equals("DatKham")) {
                await Navigation.PushAsync(new DatKhamBacSi());
            }
        }
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;*/
    }

    private  void Btn_YTeTaiNha_Clicked(object sender, EventArgs e)
    {

    }

    private  void Btn_TraCuuKetQuaKhamBenh_Clicked(object sender, EventArgs e)
    {
/*        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        BacSi result = (BacSi)await this.ShowPopupAsync();
        if (result != null)
        {
            if (result.TenBS == "True")
            {

                await Navigation.PushAsync(new DatKhamBacSi());
            }
        }
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;*/
    }

    private void PopUp_Btn_Thoat_Clicked(object sender, EventArgs e)
    {
        popup.Dismiss();
    }
    /*    public static  void PopRootNavigationPage()
{
*//*        Navigation.PopToRootAsync();*//*
    }*/
}