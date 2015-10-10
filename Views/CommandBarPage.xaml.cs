using NavigationMenuSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Syndication;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NavigationMenuSample.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CommandBarPage : Page
	{
		public CommandBarPage()
		{
			this.InitializeComponent();
			firstParamSet();
		}
		async private void firstParamSet()
		{
			targetUri = kunokufeed;
			await parameterSet(targetUri);
		}

		const string kunokufeed = "http://kunkoku.com/feed";
		const string gundamfeed = "http://rss.exblog.jp/rss/exblog/kunkoku/index.xml";
		const string honyarafeed = "http://kunkoku.livedoor.biz/index.rdf";
		const string shopappfeed = "http://shirothin.com/rss/kunapp.xml";

		private string targetUri { get; set; }
		private SyndicationFeed feed { get; set; }
		private string currentViewUri { get; set; }


		private async void feedButton1_Click(object sender, RoutedEventArgs e)
		{
			targetUri = kunokufeed; //OK,RSS
			await parameterSet(targetUri);
		}
		private async void feedButton2_Click(object sender, RoutedEventArgs e)
		{
			targetUri = gundamfeed; //RSS
			await parameterSet(targetUri);
		}
		private async void feedButton3_Click(object sender, RoutedEventArgs e)
		{
			targetUri = honyarafeed;    //RDF
			await parameterSet(targetUri);
		}
		private async void feedButton4_Click(object sender, RoutedEventArgs e)
		{
			targetUri = shopappfeed;    //ATOM
			await parameterSet(targetUri);
		}

		async private Task parameterSet(string turi)
		{
			textBlockTargetFeed.Text = turi.ToString();
			try
			{
				SyndicationClient client = new SyndicationClient();
				Uri feedUri = new Uri(turi);
				feed = await client.RetrieveFeedAsync(feedUri);
				FeedLsvModel feedData = new FeedLsvModel();

				foreach (SyndicationItem item in feed.Items)
				{
					FeedItem feedItem = new FeedItem();
					feedItem.Title = item.Title.Text;
					feedItem.PubDate = item.PublishedDate.DateTime;
					feedItem.Author = item.Authors[0].Name;
					// Handle the differences between RSS and Atom feeds.
					if (feed.SourceFormat == SyndicationFormat.Atom10)
					{
						feedItem.Content = item.Content.Text;
						feedItem.Link = new Uri(turi + item.Id);
					}
					else if (feed.SourceFormat == SyndicationFormat.Rss20)
					{
						feedItem.Content = item.Summary.Text;
						feedItem.Link = item.Links[0].Uri;
					}
					feedData.Items.Add(feedItem);
				}
				ItemListView.DataContext = feedData.Items;
				ItemListView.SelectedIndex = 0;
			}
			catch (Exception ex)
			{
				textBlockTargetFeed.Text = "ネットワークに問題が発生しました。RSSフィードが受信できません。 e:" + ex.ToString();
			}
		}


		async private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if ((ItemListView.DataContext == null) ||
				(ItemListView.SelectedIndex < 0))
			{
				/* 
					* feed変更時は前回のアイテムを吐き出す為に,
					* return,2回目で読む,
					* ItemListView.DataContext と
					* ItemListView.SelectedIndex 両方の判定が必要 
				*/
				return;
			}
			FeedItem f = new FeedItem();
			var item = feed.Items[ItemListView.SelectedIndex];
			string link = string.Empty;
			if (item.Links.Count > 0)
			{
				link = item.Links[0].Uri.AbsoluteUri;
				currentViewUri = link;
			}
			string content = "(no content)";
			if (item.Content != null)
			{
				content = item.Content.Text;
			}
			else if (item.Summary != null)
			{
				content = item.Summary.Text;
			}
			/*
				* webView.Navigate(f.Link) では,
				* 上手くLink HTMLを拾えない
				* webView.NavigateToString(content) を使う
				*/
			//webView.Navigate(f.Link);
			webView.NavigateToString("<html><body>" + content + "</body></html>");
			webView.Visibility = Visibility.Visible;
			await Task.Delay(0);
		}

		/// <summary>
		/// (test)download HTML source
		/// </summary>
		public async Task<string> DownloadHtmlCode(string url)
		{
			HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true, AllowAutoRedirect = true };
			HttpClient client = new HttpClient(handler);
			HttpResponseMessage response = await client.GetAsync(url);
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			return responseBody;
		}

		async private void buttonOpenViaExtWBrowser_Click(object sender, RoutedEventArgs e)
		{
			if (currentViewUri == null)
				return;
			var uri = new Uri(currentViewUri);
			await Windows.System.Launcher.LaunchUriAsync(uri);
		}


	}
}
