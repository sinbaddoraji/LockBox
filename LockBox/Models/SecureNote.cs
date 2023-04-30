using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LockBox.Models;

public class SecureNote : INotifyPropertyChanged
{
	private string _title;
	public string Title
	{
		get { return _title; }
		set
		{
			if (_title != value)
			{
				_title = value;
				OnPropertyChanged();
			}
		}
	}

	private string _note;
	public string Note
	{
		get { return _note; }
		set
		{
			if (_note != value)
			{
				_note = value;
				OnPropertyChanged();
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}