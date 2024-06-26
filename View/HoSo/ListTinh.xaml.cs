﻿
using BVND115.Model;
namespace BVND115.View.HoSo;

public partial class ListTinh : ContentPage
{
    TaskCompletionSource<Tinh> _taskCompletionSource;
    public Task<Tinh> PopupDismissedTask => _taskCompletionSource.Task;
    private Tinh ReturnValue;
    private int ktra = 0;
    public List<Tinh> LstTinh = new List<Tinh>();
	public ListTinh()
	{
		InitializeComponent();
        EidtWidthSearchBar();
        LoadTinh();
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
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _taskCompletionSource = new TaskCompletionSource<Tinh>();
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    public void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    public void LoadTinh()
    {
        LstTinh.Clear();
        for(int i=0; i<63; i++)
        {
            Tinh tinh=new Tinh();
            tinh.MaTinh = i.ToString();
            tinh.TenTinh = "Tên Tỉnh " + i;
            LstTinh.Add(tinh);
        }
        BindingContext =LstTinh;
    }

    private void Sb_TimKiem_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (LstTinh != null)
        {
            try
            {
                SearchBar searchBar = (SearchBar)sender;
                Lsv_Tinh.ItemsSource = LstTinh.Where(a => a.TenTinh.ToLower().Contains(searchBar.Text.ToLower())).ToList();
            }
            catch { 

            }
        }

    }
    protected override async void OnDisappearing()
    {
        if (ktra == 0)
        {
            base.OnDisappearing();
            await Navigation.PopToRootAsync();
        }
        base.OnDisappearing();
        _taskCompletionSource.SetResult(ReturnValue);
    }

    private async void Lsv_Tinh_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        ReturnValue = new Tinh();
        ReturnValue = e.DataItem as Tinh;
        await Navigation.PopAsync();

    }
}