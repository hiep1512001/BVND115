namespace BVND115.View.Home;

public partial class Test : ContentPage
{
	public Test()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new TestNavigation());
    }
}