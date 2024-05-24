using BVND115.Model;

namespace BVND115.View.HoSo;

public partial class ListHuyen : ContentPage
{
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

        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);
    }
    public void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void Lsv_Huyen_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        ThemHoSo.huyen = new Huyen();
        ThemHoSo.huyen = e.SelectedItem as Huyen;
        await Navigation.PopAsync();
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
        base.OnDisappearing();
            await Navigation.PopToRootAsync();

    }
}