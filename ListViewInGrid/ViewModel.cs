using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ListViewInGrid;

public class ViewModel : INotifyPropertyChanged
{
	private ObservableCollection<Item> _items = [];

	private void AddItem()
	{
		int index = Items.Count + 1;
		Items.Add(new Item { Name = $"Item {index}", Description = $"Description {index}" });
	}

	private void RemoveItem()
	{
		if (Items.Count > 0)
		{
			Items.RemoveAt(Items.Count - 1);
		}
	}

	private void Refresh()
	{
		ShouldRefresh?.Invoke(this, EventArgs.Empty);
	}

	public ObservableCollection<Item> Items
	{
		get => _items;

		set
		{
			if (_items != value)
			{
				_items = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
			}
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public event EventHandler? ShouldRefresh;

	public ICommand AddItemCommand { get; private set; }

	public ICommand RemoveItemCommand { get; private set; }

	public ICommand RefreshCommand { get; private set; }

	public ViewModel()
	{
		AddItemCommand = new Command(AddItem);
		RemoveItemCommand = new Command(RemoveItem);
		RefreshCommand = new Command(Refresh);
	}
}
