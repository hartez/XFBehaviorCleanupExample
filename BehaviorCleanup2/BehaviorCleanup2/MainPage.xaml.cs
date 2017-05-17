using System.Collections.Generic;
using Xamarin.Forms;

namespace BehaviorCleanup2
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			var list = new List<string>
			{
				"ein",
				"zwei",
				"drei",
				"vier"
			};

			MyListView.ItemsSource = list;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			// This will trigger behavior cleanup
			MyListView.ItemsSource = null;
		}
	}
}