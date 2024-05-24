using BVND115.Model;
using CommunityToolkit.Maui.Views;

namespace BVND115.View.TrangChu;

public partial class PopUpPage : Popup
{
	public PopUpPage()
	{
		InitializeComponent();
	}

    private  void Imb_DatKhamBacSi_Clicked(object sender, EventArgs e)
    {
        /*        MainThread.BeginInvokeOnMainThread(() => {

                    BacSi bacSi = new BacSi();
                    bacSi.TenBS = "Đây là bac soi";
                    this.Close(bacSi);

                });*/
        /*        Navigation.PushAsync(new DatKhamBacSi());*/
        BacSi bacSi = new BacSi();
        bacSi.TenBS = "True";
        this.CloseAsync(bacSi);
    }

    private void Imb_Thoat_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}