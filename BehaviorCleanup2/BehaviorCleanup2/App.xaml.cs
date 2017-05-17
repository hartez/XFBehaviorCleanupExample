using Xamarin.Forms;

namespace BehaviorCleanup2
{
	public partial class App : Application
	{
		private readonly NavigationPage _nav;

		public App()
		{
			InitializeComponent();
			_nav = new NavigationPage(SetupRootPage("Root Page"));
			MainPage = _nav;
		}

		private ContentPage SetupRootPage(string title)
		{
			var button = new Button {Text = "Back"};
			button.Clicked += (sender, args) => _nav.PopAsync();

			var showListPageButton = new Button {Text = "Navigate To List Page"};
			showListPageButton.Clicked += (sender, args) => _nav.PushAsync(new MainPage());

			return new ContentPage
			{
				Title = title,
				Content = new StackLayout {Children = {new Label {Text = title}, button, showListPageButton}}
			};
		}
	}
}