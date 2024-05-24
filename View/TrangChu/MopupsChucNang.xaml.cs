using BVND115.Model;
using Mopups.Services;
using System.Threading.Tasks;

namespace BVND115.View.TrangChu;

public partial class MopupsChucNang 
{
    TaskCompletionSource<string> _taskCompletionSource;
    public Task<string> PopupDismissedTask => _taskCompletionSource.Task;

    public string ReturnValue { get; set; }
    public BacSi bacsi { get; set; }
	public MopupsChucNang( )
	{

        InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _taskCompletionSource = new TaskCompletionSource<string>();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        _taskCompletionSource.SetResult(ReturnValue);
    }

    private void Btn_DatKhamBacSi_Clicked(object sender, EventArgs e)
    {
        ReturnValue = "DatKham";
        MopupService.Instance.PopAsync();

    }

    private void Btn_Thoat_Clicked(object sender, EventArgs e)
    {
        MopupService.Instance.PopAsync();
    }
}