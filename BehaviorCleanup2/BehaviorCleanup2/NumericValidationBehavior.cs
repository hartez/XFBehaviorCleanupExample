using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace BehaviorCleanup2
{
	public class NumericValidationBehavior : Behavior<Entry>
	{
		protected override void OnAttachedTo(Entry entry)
		{
			entry.TextChanged += OnEntryTextChanged;
			entry.BindingContextChanged += EntryOnBindingContextChanged;
			base.OnAttachedTo(entry);
		}

		private void EntryOnBindingContextChanged(object sender, EventArgs eventArgs)
		{
			var entry = sender as Entry;
			if (entry == null)
			{
				return;
			}

			if (entry.BindingContext == null)
			{
				OnDetachingFrom(entry);
			}
		}

		protected override void OnDetachingFrom(Entry entry)
		{
			Debug.WriteLine($">>>>> NumericValidationBehavior OnDetachingFrom");
			entry.TextChanged -= OnEntryTextChanged;
			entry.BindingContextChanged -= EntryOnBindingContextChanged;
			base.OnDetachingFrom(entry);
		}

		void OnEntryTextChanged(object sender, TextChangedEventArgs args)
		{
			double result;
			bool isValid = double.TryParse(args.NewTextValue, out result);
			((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
		}
	}
}