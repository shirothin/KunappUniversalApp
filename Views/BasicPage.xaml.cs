using NavigationMenuSample.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NavigationMenuSample.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class BasicPage : Page
	{
		private string imagePath { get; set; }
		public ImageSource NavigatorImage
		{
			get
			{
				return new BitmapImage(new Uri("ms-appx://" + this.imagePath));
			}
		}

		public BasicPage()
		{
			this.InitializeComponent();

			navigatorImage.Source = NavigatorImage;

		}

		private void Grid_OnTapped0(object sender, TappedRoutedEventArgs e)
		{
			Debug.WriteLine("selected0");
			Globals.NavChara = Const.NavigateCharactor.Bright;
			imagePath = "/Assets/brightIcon_30x30.png";
		}
		private void Grid_OnTapped1(object sender, TappedRoutedEventArgs e)
		{
			Debug.WriteLine("selected1");
			Globals.NavChara = Const.NavigateCharactor.Sayla;
			imagePath = "/Assets/SalaIcon_30x30.png";
		}
		private void Grid_OnTapped3(object sender, TappedRoutedEventArgs e)
		{
			Debug.WriteLine("selected3");
			Globals.NavChara = Const.NavigateCharactor.Kunkoku;
			imagePath = "/Assets/Real_kunkokuIcon_30x30.png";
		}
	}

}
