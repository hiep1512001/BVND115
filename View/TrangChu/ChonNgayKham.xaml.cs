using BVND115.Model;

using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BVND115.View.TrangChu;

public partial class ChonNgayKham : ContentPage
{
    private int ktra = 0;
    DateTime NgayDangKyKham=new DateTime(0001,01,01);
/*    private List<PropertyCollectionViewNgay> Lst_Ngay;
    private int month;
    private int year;
    private string[] arryday = { "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };
    private DateTime dateTimeNow = DateTime.Now;*/
    public ChonNgayKham()
	{
		InitializeComponent();
        
        
    }
    protected override void OnAppearing()
    {
       
        base.OnAppearing();
        ktra = 0;
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }

    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    protected override async void OnDisappearing()
    {
        if (ktra == 0)
        {
            base.OnDisappearing();
            await Navigation.PopToRootAsync();
        }
    }

    private void Calendar_Tapped(object sender, Syncfusion.Maui.Calendar.CalendarTappedEventArgs e)
    {
        NgayDangKyKham = e.Date;  
    }

    private void Btn_TiepTuc_Clicked(object sender, EventArgs e)
    {
        if (NgayDangKyKham == new DateTime(0001, 01, 01))
        {
            App.Current.MainPage.DisplayAlert("Thông báo", "Bạn chưa chọn ngày đăng ký khám, vui lòng chọn ngày", "Đồng ý");
        }
        else
        {
            ktra = 1;
            Navigation.PushAsync(new ChonGioKham());
/*            Task<bool> answer = DisplayAlert("Thông báo", "Bạn chọn ngày đăng ký khám " + NgayDangKyKham.Date.ToShortDateString(), "Có", "Không");
            answer.ContinueWith(task =>
            {
                if (task.Result)
                {
                    ktra = 1;
                    Navigation.PushAsync(new ChonHoSoKham());
                }
            });*/
        }
    }



    /*    private void Lsv_BacSi_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
        {
            PropertyCollectionViewNgay propertyCollectionViewNgay = e.DataItem as PropertyCollectionViewNgay;
            App.Current.MainPage.DisplayAlert("Thông báo", "Ngày " + propertyCollectionViewNgay.Text + " tháng " + month + " năm " + year, "Ok");
        }*/
    /*    public void XuLyLbl_NgayThang(DateTime datetime)
        {
            month = dateTimeNow.Month;
            year = dateTimeNow.Year;
            Lbl_ThangNam.Text = "Tháng " + month.ToString() + " - " + year.ToString();
        }*/
    /*    private List<PropertyCollectionViewNgay> KhoiTaoNgay( DateTime dateTimeNow)
        {
            *//*        List<DateTime> list = new List<DateTime>();*//*
            month = dateTimeNow.Month;
            year = dateTimeNow.Year;
            List<PropertyCollectionViewNgay> lstNgay = new List<PropertyCollectionViewNgay>();  
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(year, month, 1);
            string Thu = date.ToString("dddd", new CultureInfo("en-us")).ToLower().Trim();
            for(int i = 0; i < arryday.Length; i++)
            {
                if (arryday[i].ToLower().Trim().Equals(Thu))
                {
                    if (i != 0)
                    {
                        for(int j=0; j<i; j++)
                        {
                            PropertyCollectionViewNgay propertyCollectionViewNgay = new PropertyCollectionViewNgay();
                            propertyCollectionViewNgay.Text = "x";
                            propertyCollectionViewNgay.Isvisible = "false";
                            propertyCollectionViewNgay.Color = Colors.White;
                            lstNgay.Add(propertyCollectionViewNgay);
                        }
                    }
                }
            }
            do
            {
                PropertyCollectionViewNgay propertyCollectionViewNgay = new PropertyCollectionViewNgay();
                propertyCollectionViewNgay.Text = date.Day.ToString();
                propertyCollectionViewNgay.Isvisible = "true";
                int result = DateTime.Compare(now.Date, date.Date);
                if (result == 0)
                {
                    propertyCollectionViewNgay.Color = Color.FromHex("#4ccac9");
                }
                else
                {
                    propertyCollectionViewNgay.Color = Colors.White;
                }          
                lstNgay.Add(propertyCollectionViewNgay);
                date = date.AddDays(1);
            }
            while (date.Month == month);
            return lstNgay;
        }*/
    /*    private void KhoiTao()
        {
            XuLyLbl_NgayThang(dateTimeNow);
            Lst_Ngay = KhoiTaoNgay(dateTimeNow);         
            BindingContext = Lst_Ngay;
        }*/

    /*    private void Imb_Previous_Clicked(object sender, EventArgs e)
        {

            dateTimeNow=dateTimeNow.AddMonths(-1);
            XuLyLbl_NgayThang(dateTimeNow);
            Lst_Ngay = KhoiTaoNgay(dateTimeNow);
            BindingContext = Lst_Ngay;
        }*/

    /*   private void imb_Next_Clicked(object sender, EventArgs e)
       {
           AcI_load.IsVisible = true;
           AcI_load.IsRunning = true;
           dateTimeNow =dateTimeNow.AddMonths(1);
           XuLyLbl_NgayThang(dateTimeNow);
           Lst_Ngay = KhoiTaoNgay(dateTimeNow);
           BindingContext = Lst_Ngay;
           AcI_load.IsVisible = false;
           AcI_load.IsRunning = false;
       }*/

}