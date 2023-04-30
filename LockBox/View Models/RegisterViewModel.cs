using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using LockBox.Data;
using LockBox.Data.Commands;

namespace LockBox.ViewModels
{
	public class RegisterViewModel : INotifyPropertyChanged
	{
		private readonly DatabaseHandler _databaseHandler;

		private string _username;
		private string _password;
		private string _confirmPassword;
		private string _registerMessage;

		public RegisterViewModel(DatabaseHandler databaseHandler)
		{
			_databaseHandler = databaseHandler;

			RegisterCommand = new RelayCommand(Register, CanRegister);
		}
		

		public string Username
		{
			get => _username;
			set
			{
				_username = value;
				OnPropertyChanged();
			}
		}

		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyChanged();
			}
		}

		public string ConfirmPassword
		{
			get => _confirmPassword;
			set
			{
				_confirmPassword = value;
				OnPropertyChanged();
			}
		}


		public string RegisterMessage
		{
			get => _registerMessage;
			set
			{
				_registerMessage = value;
				OnPropertyChanged();
			}
		}

		private bool _closeWindow;

		public bool CloseWindow
		{
			get => _closeWindow;
			set
			{
				_closeWindow = value;
				OnPropertyChanged();
			}
		}

		public ICommand RegisterCommand { get; }

		private bool CanRegister()
		{
			return !string.IsNullOrEmpty(Username) &&
				   !string.IsNullOrEmpty(Password) &&
				   !string.IsNullOrEmpty(ConfirmPassword) && Password.Equals(ConfirmPassword);
		}

		private void Register()
		{
			// Create user object
			var user = new User
			{
				Id = System.Guid.NewGuid(),
				Username = Username
			};

			// Register user
			var result =  _databaseHandler.Register(user, Password).Result;

			RegisterMessage = result is true ? "Success" : "Registration failed!";
			
		}

		

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
