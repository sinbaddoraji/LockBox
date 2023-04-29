using System.ComponentModel;
using System.Windows.Input;
using LockBox.Data;
using LockBox.Data.Commands;
using LockBox.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace LockBox.ViewModels
{
	public class LoginViewModel : INotifyPropertyChanged
	{
		private static Logger Logger = LogManager.GetCurrentClassLogger();

		private readonly ServiceProvider _serviceProvider;

		private readonly DatabaseHandler _databaseHandler;

		private string _username;
		public string Username
		{
			get => _username;
			set
			{
				_username = value;
				OnPropertyChanged(nameof(Username));
			}
		}

		private string _password;
		

		public string Password
		{
			get => _password;
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		private string _loginMessage;


		public string LoginMessage
		{
			get => _loginMessage;
			set
			{
				_loginMessage = value;
				OnPropertyChanged(nameof(LoginMessage));
			}
		}

		public ICommand LoginCommand { get; }

		public ICommand RegisterCommand { get; }

		public bool CloseDialog { get; set; }

		public LoginViewModel(ServiceProvider serviceProvider)
		{
			LoginCommand = new RelayCommand(Login, () => true);
			RegisterCommand = new RelayCommand(Register, () => true);

			_serviceProvider = serviceProvider;
			_databaseHandler = _serviceProvider.GetService<DatabaseHandler>();
		}

		private void Login()
		{
			// Implement login logic here
			Logger.Info("User attempting login");

			if (_databaseHandler.Login(Username, Password))
			{
				CloseDialog = true;
			}
		}

		private void Register()
		{
			// Implement login logic here
			Logger.Info("User attempting to register");

			var registerWindow = _serviceProvider.GetService<RegisterWindow>();
			registerWindow.Show();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}