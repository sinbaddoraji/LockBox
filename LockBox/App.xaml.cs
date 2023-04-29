using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LockBox.Data;
using LockBox.Views.Windows;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LockBox
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static ServiceProvider serviceProvider;
		public App()
		{
			ServiceCollection services = new ServiceCollection();
			ConfigureServices(services);
			serviceProvider = services.BuildServiceProvider();
		}
		private void ConfigureServices(ServiceCollection services)
		{
			services.AddSingleton<DatabaseHandler>();

			services.AddSingleton<ServiceProvider>();
			services.AddSingleton<LoginWindow>();
			services.AddSingleton<MainWindow>();
			services.AddTransient<RegisterWindow>();
		}
		private void OnStartup(object sender, StartupEventArgs e)
		{
			var loginWindow = serviceProvider.GetService<LoginWindow>();
			loginWindow.Show();

			//var mainWindow = serviceProvider.GetService<MainWindow>();
			//mainWindow.Show();
		}
	}
}
