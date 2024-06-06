using BVND115.Model;
using System.Threading.Tasks;

namespace BVND115.View.HoSo;

public partial class ListXa : ContentPage
{
    TaskCompletionSource<Xa> _taskCompletionSource;
    public Task<Xa> PopupDismissedTask => _taskCompletionSource.Task;
    private Xa ReturnValue;
    private int ktra = 0;
    public List<Xa> LstXa = new List<Xa>();
    public ListXa()
	{
		InitializeComponent();
        EidtWidthSearchBar();
        LoadXa();
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
    private void LoadXa()
    {
        LstXa.Clear();
        for (int i = 0; i < 63; i++)
        {
            Xa xa = new Xa();
            xa.MaHuyen = "1";
            xa.MaXa = i.ToString();
            xa.TenXa = "Tên Xã " + i;
            LstXa.Add(xa);
        }
        BindingContext = LstXa;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _taskCompletionSource = new TaskCompletionSource<Xa>();
        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    public void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void Sb_TimKiem_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (LstXa != null)
        {
            try
            {
                SearchBar searchBar = (SearchBar)sender;
                Lsv_Xa.ItemsSource = LstXa.Where(a => a.TenXa.ToLower().Contains(searchBar.Text.ToLower())).ToList();
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

    private async void Lsv_Xa_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        ReturnValue= new Xa();
        ReturnValue = e.DataItem as Xa;
         await Navigation.PopAsync();
    }
}