using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using LockBox.Data;
using LockBox.Data.Commands;

namespace LockBox.ViewModels
{
	public class RegisterViewModel : INotifyPropertyChanged
	{
		private readonly IDatabaseHandler _databaseHandler;

		private string _username;
		private string _password;
		private string _confirmPassword;
		private ObservableCollection<SecurityQuestion> _securityQuestions;
		private SecurityQuestion _selectedSecurityQuestion;
		private string _securityAnswer;

		public RegisterViewModel(IDatabaseHandler databaseHandler)
		{
			_databaseHandler = databaseHandler;

			// Initialize security questions
			SecurityQuestions = new ObservableCollection<SecurityQuestion>
			{
				new SecurityQuestion("What is your favorite color?"),
				new SecurityQuestion("What is your mother's maiden name?"),
				new SecurityQuestion("What is the name of your first pet?")
			};

			// Set default selected security question
			SelectedSecurityQuestion = _securityQuestions[0];

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

		public ObservableCollection<SecurityQuestion> SecurityQuestions
		{
			get => _securityQuestions;
			set
			{
				_securityQuestions = value;
				OnPropertyChanged();
			}
		}

		public SecurityQuestion SelectedSecurityQuestion
		{
			get => _selectedSecurityQuestion;
			set
			{
				_selectedSecurityQuestion = value;
				OnPropertyChanged();
			}
		}

		public string SecurityAnswer
		{
			get => _securityAnswer;
			set
			{
				_securityAnswer = value;
				OnPropertyChanged();
			}
		}

		public ICommand RegisterCommand { get; }

		private bool CanRegister()
		{
			return !string.IsNullOrEmpty(Username) &&
				   !string.IsNullOrEmpty(Password) &&
				   !string.IsNullOrEmpty(ConfirmPassword) &&
				   Password == ConfirmPassword &&
				   !string.IsNullOrEmpty(SecurityAnswer);
		}

		private async void Register()
		{
			// Create user object
			var user = new User
			{
				Username = Username,
				Password = Password,
				SecurityQuestion = SelectedSecurityQuestion.Question,
				SecurityAnswer = SecurityAnswer
			};

			// Register user
			var result = await _databaseHandler.Register(user);

			if (result is true)
			{
				// Navigate to login page
				// ...
			}
			else
			{
				// Show error message
				// ...
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
