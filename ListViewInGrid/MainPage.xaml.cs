namespace ListViewInGrid
{
	public partial class MainPage : ContentPage
	{
		ViewModel? _vm = null;

		public MainPage()
		{
			InitializeComponent();
			_vm = BindingContext as ViewModel;
			if (_vm != null)
			{
				_vm.ShouldRefresh += OnShouldRefresh;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (_vm != null)
			{
				_vm.ShouldRefresh += OnShouldRefresh;
			}
		}

		protected override void OnDisappearing()
		{
			if (_vm != null)
			{
				_vm.ShouldRefresh -= OnShouldRefresh;
			}

			base.OnDisappearing();
		}

		private void OnShouldRefresh(object? sender, EventArgs e)
		{
			var rowDefs = new RowDefinitionCollection();
			rowDefs.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
			rowDefs.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			MainGrid.RowDefinitions = rowDefs;
		}
	}

}
