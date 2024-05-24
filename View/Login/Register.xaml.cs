using BVND115.View.Home;
using Camera.MAUI.ZXing;
using Camera.MAUI;


namespace BVND115.View.Login;

public partial class Register : ContentPage
{
    public Register()
    {
		InitializeComponent();
        cameraView.BarCodeDecoder = new ZXingBarcodeDecoder();
        cameraView.BarCodeOptions = new BarcodeDecodeOptions
        {
            AutoRotate = true,
            PossibleFormats = { BarcodeFormat.QR_CODE,BarcodeFormat.CODE_39 },
            ReadMultipleCodes = false,
            TryHarder = true,
            TryInverted = true
        };
        cameraView.ControlBarcodeResultDuplicate = true;
        cameraView.BarCodeDetectionEnabled = true;
    }
    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        /*            MainThread.BeginInvokeOnMainThread(() =>
                    {
                        barcodeResult.Text = $"{args.Result[0].BarcodeFormat}:{args.Result[0].Text}";

                    });
                    Debug.WriteLine("BarcodeText=" + args.Result[0].Text);*/
        barcodeResult.Text = args.Result[0].Text;
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
}