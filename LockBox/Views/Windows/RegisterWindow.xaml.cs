using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : MetroWindow
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
			PasswordBox passwordBox = sender as PasswordBox;
			ViewModelLocator.RegisterViewModel.Password = passwordBox.Password;
		}
        
        private void ConfirmPasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
			PasswordBox passwordBox = sender as PasswordBox;
			ViewModelLocator.RegisterViewModel
				.ConfirmPassword = passwordBox.Password;
		}
    }
}
