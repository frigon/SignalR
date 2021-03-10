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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AspNetCore.SignalR.Client;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>	
	public partial class MainWindow : Window
	{
		private HubConnection hub = null;
		public MainWindow()
		{
			InitializeComponent();
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				hub = new HubConnectionBuilder()
					.WithUrl("http://localhost:7071/api")
					.Build();
				hub.On<string,string>("newMessage", (result, one) => {
					MessageBox.Show(result);
				});



				await hub.StartAsync();
			}catch(Exception ex)
			{

			}
		}
	}
}
