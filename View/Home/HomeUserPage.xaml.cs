
namespace BVND115.View.Home;

public partial class HomeUserPage : TabbedPage
{
	public HomeUserPage()
	{
		InitializeComponent();
        ModifyTabbedPageHandler();
    }
    private void ModifyTabbedPageHandler()
    {
        Microsoft.Maui.Handlers.TabbedViewHandler.Mapper.AppendToMapping("FixMultiTab", (handler, view) =>
        {
#if ANDROID
            var viewPager = (AndroidX.ViewPager2.Widget.ViewPager2)handler.PlatformView;
            viewPager.OffscreenPageLimit = 5;
#endif
        });
    }
}