using System.Linq;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Controls
{
	[Preserve (AllMembers = true)]
	public class CheckBoxCellItem 
	{
		public string Label { get; set; }
		public bool CheckBoxOn { get; set; }
		public Color CheckedColor { get; set; }
		public Color UncheckedColor { get; set; }
	}

	public class CheckBoxCellListPage : ContentPage
	{
		public CheckBoxCellListPage ()
		{
			Title = "CheckBoxCell List Gallery - Legacy";

			if (Device.RuntimePlatform == Device.iOS && Device.Idiom == TargetIdiom.Tablet)
				Padding = new Thickness(0, 0, 0, 60);

			var dataTemplate = new DataTemplate (typeof (CheckBoxCell)) {
				Bindings = {
					{CheckBoxCell.TextProperty, new Binding ("Label")},
					{CheckBoxCell.IsCheckedProperty, new Binding ("CheckBoxOn")},
					{CheckBoxCell.CheckedColorProperty, new Binding ("CheckedColor")},
					{CheckBoxCell.UncheckedColorProperty, new Binding ("UncheckedColor")},
				}
			};

			var label = new Label { Text = "I have not been selected" };

			var listView = new ListView {
				AutomationId = CellTypeList.CellTestContainerId,
				ItemsSource = Enumerable.Range(0, 100).Select(i => new CheckBoxCellItem {
					Label = "Label " + i,
					CheckBoxOn = i % 2 == 0 ? false : true,
					CheckedColor = i % 2 == 0 ? Color.DeepPink : Color.Default,
					UncheckedColor = i % 2 == 0 ? Color.DeepPink : Color.Default
				}),
				ItemTemplate = dataTemplate
			};

			listView.ItemSelected += (sender, args) => label.Text = "I was selected.";

			Content = new StackLayout { Children = { label, listView } };
		}

	}
}