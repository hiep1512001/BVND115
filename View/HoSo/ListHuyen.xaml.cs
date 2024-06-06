using BVND115.Model;

namespace BVND115.View.HoSo;

public partial class ListHuyen : ContentPage
{
    TaskCompletionSource<Huyen> _taskCompletionSource;
    public Task<Huyen> PopupDismissedTask => _taskCompletionSource.Task;
    private Huyen ReturnValue;
    private int ktra = 0;
    public List<Huyen> LstHuyen = new List<Huyen>();
    public ListHuyen()
	{
		InitializeComponent();
        EidtWidthSearchBar();
        LoadHuyen();
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
    private void LoadHuyen()
    {
        LstHuyen.Clear();
        for (int i = 0; i < 63; i++)
        {
            Huyen huyen= new Huyen();
            huyen.MaTinh = "1" ;
            huyen.MaHuyen = i.ToString();
            huyen.TenHuyen= "Tên huyện "+ i.ToString();
            LstHuyen.Add(huyen);
        }
        BindingContext = LstHuyen;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _taskCompletionSource = new TaskCompletionSource<Huyen>();
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    public void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Sb_TimKiem_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (LstHuyen != null)
        {
            try
            {
                SearchBar searchBar = (SearchBar)sender;
                Lsv_Huyen.ItemsSource = LstHuyen.Where(a => a.TenHuyen.ToLower().Contains(searchBar.Text.ToLower())).ToList();
            }
            catch
            {

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
    private async void Lsv_Huyen_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        ReturnValue = new Huyen();
        ReturnValue = e.DataItem as Huyen;
        await Navigation.PopAsync();
    }
}