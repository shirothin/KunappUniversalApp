using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

using CoreTweet;

using NavigationMenuSample.Common;
using NavigationMenuSample.Models;
using System.Diagnostics;
using Windows.UI.Popups;
using Windows.ApplicationModel;
using System.Threading;
using Windows.UI.Xaml.Media.Imaging;


namespace NavigationMenuSample.Views
{
	public sealed partial class DrillInPage : Page
	{

		#region Fields

		internal const string API_CONSUMER_TOKEN = Const.ConsumerKey;
		internal const string API_CONSUMER_SECRET = Const.ConsumerSecret;
		internal const string API_CONSUMER_CALLBACK_URL = "http://127.0.0.1:64003/Account/ExternalLoginCallback";

		const string DEFAU_PINCODETEXT = "PINコードを入力してください。";
#if false
		const string DEFAU_STATUSTEXT = "商品名";
		const string DEFAU_DORDERTEXT = "発注番号";
#endif
		const string DEFAU_FREETEXT = "フリーTweet";

		#endregion Fields

		#region Properies

		public OAuth.OAuthSession Session { get; private set; }
		public Tokens Tokens { get; private set; }
		private List<TimeLine> listTimeLine { get; set; }
		private Const.NavigateCharactor navChara { get; set; }
		private Dictionary<int, string> actorLines { get; set; }
		private string imagePath { get; set; }
		public ImageSource NavigatorImage
		{
			get
			{
				return new BitmapImage(new Uri("ms-appx://" + this.imagePath));
			}
		}
		//private string NavigatorImage { get; set; }
		#endregion Properies

		#region Constructor


		public DrillInPage()
		{
			this.InitializeComponent();
			// Navigation Charactor
			navChara = Globals.NavChara;
			switch (navChara)
			{
				case Const.NavigateCharactor.Sayla:
					actorLines = Const.ActorLinesSayla;
					//NavigatorImage = "/Assets/SalaIcon_30x30.png.png";
					imagePath = "/Assets/SalaIcon_30x30.png";
					break;
				case Const.NavigateCharactor.Kunkoku:
					actorLines = Const.ActorLinesKunkoku;
					//NavigatorImage = "/Assets/Real_kunkokuIcon_30x30.png.png";
					imagePath = "/Assets/Real_kunkokuIcon_30x30.png";
					break;
				default:
					actorLines = Const.ActorLinesBright;
					//NavigatorImage = "/Assets/brightIcon_30x30.png";
					imagePath = "/Assets/brightIcon_30x30.png";
					break;
			}
			navigatorImage.Source = NavigatorImage;
			//ImagePath = "/Assets/brightIcon_30x30.png";

			// ProgressBar
			progressBar.IsIndeterminate = false;
			progressBar.Visibility = Visibility.Collapsed;
			// Restore setting with Async 
			bool res = false;
			var uisync = TaskScheduler.FromCurrentSynchronizationContext();
			Task medeaTask = Task.Run(async () =>
			{
				res = await LoadAccessTokens();
			});
			Task uiTask = medeaTask.ContinueWith((t) =>
			{
				if (res == true)
					_anyMessage.Text = actorLines[Const.ActorLinesMain["砂漠に蝶は舞う。"]];
				else
				{
					_anyMessage.Text = actorLines[Const.ActorLinesMain["アプリの使用を許可する。"]];
					if ((Tokens == null) || (Tokens.ConsumerKey == null) || (Tokens.ConsumerSecret == null))
					{
						_anyMessage.Text += actorLines[Const.ActorLinesMain["\r\nジャブローの認証が下りていないようだ。「Authorize Via External Web Browser」で外部ブラウザを開き、PINコードを入手するんだ。"]];
						FirstAuthBlock.Visibility = Visibility.Visible;
					}
				}
			}, uisync);
			// UI Text Default
			_pincodeTextBox.Text = DEFAU_PINCODETEXT;
#if false
			_statusTextBox.Text = DEFAU_STATUSTEXT;
			_orderTextBox.Text = DEFAU_DORDERTEXT;
#endif
			listTimeLine = new List<TimeLine>();
			_pincodeTextBox.Text = DEFAU_PINCODETEXT;
			// 保存先 %USERPROFILE%\AppData\Local\Packages\App.
			/*			var familyname = Package.Current.Id.FamilyName;
						Debug.WriteLine("Package FamilyName : {0}", familyname);
			*/
		}


		#endregion Constructor


		#region Methods

		/// <summary>
		/// Save
		/// </summary>
		private async Task<bool> SaveAccessTokens()
		{
			Medea medea = new Medea();
			var atenc = await AlphaGain.GeneralRevil(Tokens.AccessToken, "LOCAL=user");
			var atseceretenc = await AlphaGain.GeneralRevil(Tokens.AccessTokenSecret, "LOCAL=user");
			PersistModel persist = new PersistModel()
			{
#if TAKLAMAKAN_DESERT
				AccessToken = atenc,
				AccessSecretToken = atseceretenc,
#else
				AccessToken = Tokens.AccessToken,
				AccessSecretToken = Tokens.AccessTokenSecret,
#endif
				UserID = Tokens.UserId.ToString(),
				ScreenName = Tokens.ScreenName.ToString(),
			};
#if DEBUG
			Debug.WriteLine(
				"Saving Data:\r AcceccToken(ct) = {0}\r AccessTokenSecret(ct) = {1}\r AccessToken(enc) = {2}\r AccessTokenSecret(enc) = {3}\r",
				Tokens.AccessToken,
				Tokens.AccessTokenSecret,
				atenc,
				atseceretenc
			);
#endif
			medea.AddPersist(persist);
			var result = await medea.Woody();
			if (result == true)
				_anyMessage.Text = actorLines[Const.ActorLinesMain["機密を保持した。"]];
			return result;
		}

		/// <summary>
		/// Load
		/// </summary>
		private async Task<bool> LoadAccessTokens()
		{
			Medea medea = new Medea();
			List<PersistModel> data = await medea.Matilda();
#if TAKLAMAKAN_DESERT
			var atdec = await AlphaGain.SaylaMass(data[0].AccessToken);
			var atsecretdec = await AlphaGain.SaylaMass(data[0].AccessSecretToken);
#else
			string atdec = string.Empty;
			string atsecretdec = string.Empty;
#endif
			if (data != null)
			{
				Tokens = Tokens.Create(
					API_CONSUMER_TOKEN,
					API_CONSUMER_SECRET,
#if TAKLAMAKAN_DESERT
					atdec,
					atsecretdec,
#else
					data[0].AccessToken,
					data[0].AccessSecretToken,
#endif
					long.Parse(data[0].UserID),
					data[0].ScreenName
				);
#if DEBUG
				PackageVersion version = Package.Current.Id.Version;
				var familyname = Package.Current.Id.FamilyName;
				string versionString = string.Format("Ver : {0}.{1}\r\nfamilyname : {2}\r\n", version.Major, version.Minor, familyname);
				string settingsLocation = @"%USERPROFILE%\AppData\Local\Packages" + @"\" + familyname;
				Debug.WriteLine("location : {0}", settingsLocation);
				Debug.WriteLine(
					"Restore Data:\r ConsumerKey = {0}\r ConsumerSecret = {1}\r AccessToken = {2}\r AccessTokenSecret = {3}\r UserId = {4}\r ScreenName = {5}",
					Tokens.ConsumerKey,
					Tokens.ConsumerSecret,
					Tokens.AccessToken,
					Tokens.AccessTokenSecret,
					Tokens.UserId,
					Tokens.ScreenName
				);
#endif
				return true;
			}
			return false;
		}

		/// <summary>
		/// 1st.Step OnAuthorize
		/// </summary>
		private async void OnAuthorize(object sender, Windows.UI.Xaml.RoutedEventArgs args)
		{
			Session = await OAuth.AuthorizeAsync(API_CONSUMER_TOKEN, API_CONSUMER_SECRET);
			string uriToLaunch = Session.AuthorizeUri.ToString();
			var uri = new Uri(uriToLaunch);
			var success = await Windows.System.Launcher.LaunchUriAsync(uri);
			if (success)
			{
				// URI launched
				_anyMessage.Text = actorLines[Const.ActorLinesMain["PINコードを入力するんだ。"]];
				return;
			}
			else
			{
				// URI launch failed
				MessageDialog md = new MessageDialog("Failed External Web Browser Open.");
				await md.ShowAsync();
				_anyMessage.Text = actorLines[Const.ActorLinesMain["ジオンの制空権内ということを自覚しろ！"]];
			}
		}

		/// <summary>
		/// 2nd.Step PIN Comparison Button
		/// </summary>
		private async void PinExeCute(object sender, RoutedEventArgs e)
		{
			try
			{
				string pin = _pincodeTextBox.Text;
				Tokens = await Session.GetTokensAsync(pin);
			}
			catch (Exception)
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["操作に誤りがあるようだ。聡明な貴方が・・・"]];
				return;
			}
			if (Tokens != null)
			{
				Debug.WriteLine(
					"result > \r Token : {0}\r TokenSecret :{1}\r UseerID : {2}\r ScreenName : {2}",
					Tokens.AccessToken.ToString(),
					Tokens.AccessTokenSecret.ToString(),
					Tokens.UserId.ToString(),
					Tokens.ScreenName.ToString()
				);
				_anyMessage.Text =
					"\r Autorized : " + Tokens.ScreenName.ToString();
				_pincodeTextBox.Text = "";
				_anyMessage.Text += actorLines[Const.ActorLinesMain["\r ジャブローへの通信回線が開いたぞ。"]];
				// Save AccessTokens Data 
				await SaveAccessTokens();
				return;
			}
			else
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["ジャブローへの認証が失敗したようだ。貴様何をやっている！"]];
				return;
			}
		}

		/// <summary>
		/// OnTweet Button
		/// </summary>
		private async void OnTweet(object sender, Windows.UI.Xaml.RoutedEventArgs args)
		{
			if (Tokens == null)
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["殴って何故悪い！"]];
				return;
			}
			try
			{
				var tokenSource = new CancellationTokenSource();
				var res = await Tokens.Statuses.UpdateAsync(new { status = _statusTextBox.Text + " #KunappUniversalApp" }, tokenSource.Token);
				tokenSource.Cancel();
				if (res != null)
				{
					Debug.WriteLine(
						"result > \r Id : {0}\r HashCode :{1}\r Json : {2}",
						res.Id.ToString(),
						res.GetHashCode().ToString(),
						res.Json.ToString()
						);
					_anyMessage.Text = actorLines[Const.ActorLinesMain["通信を許可する。"]] +
						"\r Sent -> : " + res.Text;
					_statusTextBox.Text = "";
					return;
				}
			}
			catch (Exception)
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["ミノフスキー濃度が濃いようだ・・・ \r通信回線を調べるんだ。"]];
				return;
			}
		}

		/// <summary>
		/// Shopping Tweet
		/// </summary>
		private async void ShoppingTweet(object sender, RoutedEventArgs e)
		{
			if (Tokens == null)
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["貴様はシャアを越えられる奴だと思っていた。残念だよ。"]];
				return;
			}
			string str = _statusTextBox.Text;
			if (str.Length < 1)
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["商品名入れてないよ！何やってんの！！"]];
				return;
			}
			if (str.Length > (Const.TweetStringLength - (Const.PreTweetPhrase.Length + Const.PostTweetPhrase.Length)))
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["文字数が多すぎるぞ！字数は、有効に使え！ (現在の文字数 = "]] + (str.Length + Const.PreTweetPhrase.Length + Const.PostTweetPhrase.Length).ToString();
				return;
			}
			try
			{
				progressBar.IsIndeterminate = true;
				progressBar.Visibility = Visibility.Visible;
				// 購入tweet
				var tokenSource = new CancellationTokenSource();
				// status文字列は"@"付投稿でExceptionが発生するので@"@abc.."とする(TweetSharpでは"@"付きをリプライと認識してくれていた。
				var res = await Tokens.Statuses.UpdateAsync(new { status = Const.PreTweetPhrase + str + Const.PostTweetPhrase }, tokenSource.Token);
				tokenSource.Cancel();
				// DM
				var dmtSource = new CancellationTokenSource();
				var opt = await Tokens.DirectMessages.NewAsync(new { screen_name = Const.ToScreenName, text = "商品名:" + str + ",受注番号:" + _orderTextBox.Text }, dmtSource.Token);
				dmtSource.Cancel();
				if ((res != null) && (opt != null))
				{
					_anyMessage.Text = "\r Sent -> " + res.Text + "\r ご購入ありがとうございました。";
					_statusTextBox.Text = "";
					_orderTextBox.Text = "";
				}
			}
			catch (Exception)
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["？？ミノフスキー粒子濃度が濃いようだ・・・"]];
			}
			finally
			{
				progressBar.IsIndeterminate = false;
				progressBar.Visibility = Visibility.Collapsed;
			}
		}

		/// <summary>
		/// LoadTimeLine
		/// </summary>
		private async void LoadTimeLine(object sender, RoutedEventArgs e)
		{
			if (Tokens == null)
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["ジャブローへの認証が行われていないようだ。"]];
				return;
			}
			progressBar.Visibility = Visibility.Visible;
			progressBar.IsIndeterminate = true;
			try
			{
				foreach (Status status in await this.Tokens.Statuses.HomeTimelineAsync(count => 100))
				{
					// ListBOX
					TimeLine tl = new TimeLine();
					tl.ScreenName = status.User.ScreenName;
					tl.ProfileImageUrl = status.User.ProfileImageUrl.ToString();
					tl.Status = status.Text;
					tl.DateTime = status.CreatedAt.DateTime.ToLocalTime().ToString();
					listTimeLine.Add(tl);
				}
				timelineListView.ItemsSource = listTimeLine;
				_anyMessage.Text = actorLines[Const.ActorLinesMain["肩に力が入りすぎのようだな。大丈夫、コンピュータがやってくれますよ。"]];
				progressBar.IsIndeterminate = false;
				progressBar.Visibility = Visibility.Collapsed;
			}
			catch (Exception ex)
			{
				_anyMessage.Text = actorLines[Const.ActorLinesMain["・・・通信回線に問題があるようだ。第二ブリッジを調べろ。e:"]] + ex.ToString();
			}
		}

		private async void JetStreamAttack(object sender, RoutedEventArgs e)
		{
			Medea medea = new Medea();
			int n = await medea.JetStreamAttack();
			if (n > 0)
				_anyMessage.Text = actorLines[Const.ActorLinesMain["システムにトラブル発生。\r\n総員待避！"]];
			else
				_anyMessage.Text = actorLines[Const.ActorLinesMain["全滅だと・・・\r\n機密を消去した。"]];
		}

		#endregion Methods

		/// <summary>
		/// EventHandler in TextBox,キャプションの挙動
		/// </summary>
		private void _pincodeText_GotFocus(object sender, RoutedEventArgs e)
		{
			if (_pincodeTextBox.Text == DEFAU_PINCODETEXT)
				_pincodeTextBox.Text = string.Empty;
			_pincodeTextBox.SelectAll();
		}
		private void _pincodeText_LostFocus(object sender, RoutedEventArgs e)
		{
			if (_pincodeTextBox.Text == string.Empty)
				_pincodeTextBox.Text = DEFAU_PINCODETEXT;
		}

		private void _statusText_GotFocus(object sender, RoutedEventArgs e)
		{
#if false
			if (_statusTextBox.Text == DEFAU_STATUSTEXT)
				_statusTextBox.Text = string.Empty;
			_statusTextBox.SelectAll();
#endif
		}
		private void _statusText_LostFocus(object sender, RoutedEventArgs e)
		{
#if false
			if (_statusTextBox.Text == string.Empty)
				_statusTextBox.Text = DEFAU_STATUSTEXT;
#endif
			if (_statusTextBox.Text.Length > 0)
				_captionStatusTextBox.Text = string.Empty;
		}
		private void _orderText_GotFocus(object sender, RoutedEventArgs e)
		{
#if false
			if (_orderTextBox.Text ==DEFAU_DORDERTEXT)
				_orderTextBox.Text = string.Empty;
			_orderTextBox.SelectAll();
#endif
		}
		private void _orderText_LostFocus(object sender, RoutedEventArgs e)
		{
#if false
			if (_orderTextBox.Text == string.Empty)
				_orderTextBox.Text = DEFAU_DORDERTEXT;
#endif
			if (_orderTextBox.Text.Length > 0)
				_captionOrderTextBox.Text = string.Empty;
		}


#if false
		// test ListView Scroll Behavior
		private readonly ObservableCollection<string> items = new ObservableCollection<string>();

		private void MyListviewLoaded(object sender, RoutedEventArgs e)
		{
			this.timelineListView.ItemsSource = items;

			items.CollectionChanged += (s, args) => ScrollToBottom();
		}
		private void ScrollToBottom()
		{
			var selectedIndex = timelineListView.Items.Count - 1;
			if (selectedIndex < 0)
				return;

			timelineListView.SelectedIndex = selectedIndex;
			timelineListView.UpdateLayout();

			timelineListView.ScrollIntoView(timelineListView.SelectedItem);
		}
#endif


	}

}
