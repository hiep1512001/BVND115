using BVND115.Model;

using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BVND115.View.TrangChu;

public partial class ChonNgayKham : ContentPage
{
    private int ktra=0;
    private List<PropertyCollectionViewNgay> Lst_Ngay;
    private int month;
    private int year;
    private string[] arraymonth = { "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };
    private DateTime dateTimeNow = DateTime.Now;
    public ChonNgayKham()
	{
		InitializeComponent();
        KhoiTao();
    }
    public void XuLyLbl_NgayThang(DateTime datetime)
    {
        month = dateTimeNow.Month;
        year = dateTimeNow.Year;
        Lbl_ThangNam.Text = "Tháng " + month.ToString() + " - " + year.ToString();
    }
    private List<PropertyCollectionViewNgay> KhoiTaoNgay( DateTime dateTimeNow)
    {
        /*        List<DateTime> list = new List<DateTime>();*/
        month = dateTimeNow.Month;
        year = dateTimeNow.Year;
        List<PropertyCollectionViewNgay> lstNgay = new List<PropertyCollectionViewNgay>();  
        DateTime date = new DateTime(year, month, 1);
        string Thu = date.ToString("dddd", new CultureInfo("en-us")).ToLower().Trim();
        for(int i = 0; i < arraymonth.Length; i++)
        {
            if (arraymonth[i].ToLower().Trim().Equals(Thu))
            {
                if (i != 0)
                {
                    for(int j=0; j<i; j++)
                    {
                        PropertyCollectionViewNgay propertyCollectionViewNgay = new PropertyCollectionViewNgay();
                        propertyCollectionViewNgay.Text = "x";
                        propertyCollectionViewNgay.Isvisible = "false";
                        propertyCollectionViewNgay.Color = "#7BDDEF";
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
            propertyCollectionViewNgay.Color= "#7BDDEF";
            lstNgay.Add(propertyCollectionViewNgay);
            date = date.AddDays(1);
        }
        while (date.Month == month);
        return lstNgay;
    }
    private void KhoiTao()
    {
        XuLyLbl_NgayThang(dateTimeNow);
        Lst_Ngay = KhoiTaoNgay(dateTimeNow);         
        BindingContext = Lst_Ngay;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }

    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Imb_Previous_Clicked(object sender, EventArgs e)
    {

        dateTimeNow=dateTimeNow.AddMonths(-1);
        XuLyLbl_NgayThang(dateTimeNow);
        Lst_Ngay = KhoiTaoNgay(dateTimeNow);
        BindingContext = Lst_Ngay;
    }

    private void imb_Next_Clicked(object sender, EventArgs e)
    {
        AcI_load.IsVisible = true;
        AcI_load.IsRunning = true;
        dateTimeNow =dateTimeNow.AddMonths(1);
        XuLyLbl_NgayThang(dateTimeNow);
        Lst_Ngay = KhoiTaoNgay(dateTimeNow);
        BindingContext = Lst_Ngay;
        AcI_load.IsVisible = false;
        AcI_load.IsRunning = false;
    }
    protected override async void OnDisappearing()
    {
        if (ktra == 0)
        {
            base.OnDisappearing();
            await Navigation.PopToRootAsync();
        }
    }

    private  void Csv_Ngay_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string thu = (e.PreviousSelection.FirstOrDefault() as PropertyCollectionViewNgay)?.Text;
        if (thu != null)
        {
             App.Current.MainPage.DisplayAlert("Thông báo", "Ngày " + thu + " tháng " + month + " năm " + year,"Ok");
        }
    }
}