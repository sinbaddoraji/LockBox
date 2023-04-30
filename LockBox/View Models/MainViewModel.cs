using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LockBox.Data;
using LockBox.Data.Commands;
using LockBox.Models;

namespace LockBox.View_Models
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		
		private object _selectedItem;
		public object SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value;
				OnPropertyChanged(nameof(SelectedItem));
			}
		}

		public bool UnsavedChanges { get; set; } = false;
		
		public ICommand AddNoteCommand { get; private set; }
		public ICommand SaveCommand { get; private set; }
		public ICommand AddPasswordCommand { get; private set; }
		public ICommand RemoveNoteCommand { get; private set; }

		public DatabaseHandler DatabaseHandler { get; set; }

		public ObservableCollection<object> Secrets => DatabaseHandler.CurrentUser.Secrets;
		
		public MainWindowViewModel(DatabaseHandler databaseHandler)
		{
			AddNoteCommand = new RelayCommand(AddNote, () => true);
			SaveCommand = new RelayCommand(Save, () => true);
			AddPasswordCommand = new RelayCommand(AddPasswordNote, () => true);
			RemoveNoteCommand = new RelayCommand(RemoveNote, () => true);

			DatabaseHandler = databaseHandler;
		}

		public void Save()
		{
			DatabaseHandler.Update("Users", DatabaseHandler.CurrentUser);

		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		
		private void AddNote()
		{
			// Create a new SecureNote object
			SecureNote newNote = new SecureNote()
			{
				Note = "Empty Note",
				Title = "New Note Title"
			};

			// Add the new note to the Notes collection
			Secrets.Add(newNote);

			// Select the new note in the list
			SelectedItem = newNote;

			UnsavedChanges = true;
		}

		private void AddPasswordNote()
		{
			// Create a new SecureNote object
			PasswordEntry passwordEntry = new PasswordEntry()
			{
				Title = "New Password",
				UserName = "No Username",
			};

			// Add the new note to the Notes collection
			Secrets.Add(passwordEntry);
			Save();
			// Select the new note in the list
			SelectedItem = passwordEntry;

			UnsavedChanges = true;
		}

		private void RemoveNote()
		{
			SelectedItem ??= Secrets.FirstOrDefault();

			if (SelectedItem == null)
				return;
			SecureNote note = (SecureNote)SelectedItem;

			// Remove the selected note from the Notes collection
			Secrets.Remove(note);
			Save();

			// If the selected note was removed, select the first note in the list
			if (SelectedItem == note)
			{
				SelectedItem = Secrets.FirstOrDefault();
			}

			UnsavedChanges = true;
		}
	}
	
}
