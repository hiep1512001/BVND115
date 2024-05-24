using Camera.MAUI.ZXing;
using Camera.MAUI;
using CommunityToolkit.Maui.Alerts;

namespace BVND115.View.HoSo;

public partial class ScanQRCodePage : ContentPage
{
	public ScanQRCodePage()
	{
        InitializeComponent();
        cameraView.BarCodeDecoder = new ZXingBarcodeDecoder();
        cameraView.BarCodeOptions = new BarcodeDecodeOptions
        {
            AutoRotate = true,
            PossibleFormats = { BarcodeFormat.QR_CODE, BarcodeFormat.CODE_39 },
            ReadMultipleCodes = false,
            TryHarder = true,
            TryInverted = true
        };
        cameraView.ControlBarcodeResultDuplicate = true;
        cameraView.BarCodeDetectionEnabled = true;
    }
    protected void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        string result;
        MainThread.BeginInvokeOnMainThread(async () =>
        {
/*            result = $"{args.Result[0].Text}";*/
            result = args.Result[0].Text.ToString();
            ThemHoSo.qrcodeResult = result;
            await Navigation.PopAsync();

        });
    }
    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
        if (cameraView.MaxZoomFactor >= 5f)
            cameraView.ZoomFactor = 5f;
    }
    private void ScanQRCode(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanQRCodePage());
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        NavigationPage.SetHasNavigationBar(this, false);
        Shell.SetNavBarIsVisible(this, false);

        if (!await CheckPermissions())
        {
            await Toast.Make("Bạn chưa bật quyền truy cập CAMERA").Show();
            await Navigation.PopAsync();
        }
    }
    private async Task<bool> CheckPermissions()
    {
        PermissionStatus cameraStatus = await CheckPermissions<Permissions.Camera>();

        return IsGranted(cameraStatus);
    }
    private async Task<PermissionStatus> CheckPermissions<TPermission>() where TPermission : Permissions.BasePermission, new()
    {
        PermissionStatus status = await Permissions.CheckStatusAsync<TPermission>();

        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<TPermission>();
        }

        return status;
    }
    private static bool IsGranted(PermissionStatus status)
    {
        return status == PermissionStatus.Granted || status == PermissionStatus.Limited;
    }
    private void Imb_GoBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await Navigation.PopToRootAsync();

    }
}