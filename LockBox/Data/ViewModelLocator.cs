using System;
using System.Collections.Generic;
using System.Net.Mime;
using LockBox.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LockBox.Data
{
	public class ViewModelLocator
	{
		private readonly Dictionary<Type, object> _viewModels;

		private static LoginViewModel _loginViewModel;

		public static LoginViewModel LoginViewModel
		{
			get
			{
				if (_loginViewModel == null)
				{
					_loginViewModel = new LoginViewModel(App.serviceProvider);
				}
				return _loginViewModel;
			}
		}

		private static RegisterViewModel _registerViewModel;

		public static RegisterViewModel RegisterViewModel
		{
			get
			{
				if (_registerViewModel == null)
				{
					var databaseHandler = App.serviceProvider.GetService<DatabaseHandler>();
					_registerViewModel = new RegisterViewModel(databaseHandler);
				}
				return _registerViewModel;
			}
		}

	}
}
