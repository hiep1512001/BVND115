using BVND115.View.Home;
using BVND115.View.HoSo;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;

namespace BVND115
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TabHoSo), typeof(TabHoSo));
            Routing.RegisterRoute(nameof(ThemHoSo), typeof(ThemHoSo));

        }


    }
}
