using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LockBox.Data;
using MahApps.Metro.Controls;

namespace LockBox.Views.Windows
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class LoginWindow : MetroWindow
	{
		public LoginWindow()
		{
			InitializeComponent();

			Timer timer = new Timer(1000);
			timer.Elapsed += (sender, args) => 
			{
				var dataContext = ViewModelLocator.LoginViewModel;
				if (dataContext.CloseDialog)
				{
					this.Dispatcher.Invoke(() =>
					{
						this.Close();
					});
				}
			};
			timer.Start();
		}

		private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
		{
			PasswordBox passwordBox = sender as PasswordBox;
			ViewModelLocator.LoginViewModel.Password = passwordBox.Password;
		}
	}
}
