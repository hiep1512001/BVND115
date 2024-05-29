
using BVND115.View.Home;
using BVND115.View.HoSo;
using BVND115.View.Login;

namespace BVND115
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXxccHZXQ2ldUUBxWEE=");
            InitializeComponent();
            NavigationPage NavPage = new NavigationPage(new Login());
            MainPage = NavPage;
            /*            MainPage = new AppShell();*/
            /*            MainPage = new HomeUserPage();*/

            /*            MainPage = new ListViewBacSi();*/
            /*            MainPage = new Login();*/
        }
    }
}
