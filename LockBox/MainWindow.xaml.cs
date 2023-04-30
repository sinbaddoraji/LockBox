using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LockBox.Data;
using LockBox.Models;
using MahApps.Metro.Controls;

namespace LockBox
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void NoteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (NoteList.SelectedItem is PasswordEntry selectedPasswordEntry)
			{
				ViewModelLocator.MainWindowViewModel.SelectedItem = selectedPasswordEntry;
			}
			else if (NoteList.SelectedItem is SecureNote selectedSecureNote)
			{
				ViewModelLocator.MainWindowViewModel.SelectedItem = selectedSecureNote;
			}


		}

		private void ButtonBase_OnClick_Margin_(object sender, RoutedEventArgs e)
		{
			//throw new NotImplementedException();
			ViewModelLocator.MainWindowViewModel.Save();
		}

		private void SecureNoteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
