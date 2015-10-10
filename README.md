# KunappWinApp

KunappWinAppは、kunkokuショップメンバーズの公式アプリ
kunappのWindowsアプリ版です。

Android版 : [https://play.google.com/store/apps/details?id=com.kunkoku.kunapp&hl=ja](https://play.google.com/store/apps/details?id=com.kunkoku.kunapp&hl=ja)

# インストール
Windows 向けこのアプリ : [https://www.microsoft.com/ja-jp/store/apps/kunappwin/9wzdncrdrqc2](https://www.microsoft.com/ja-jp/store/apps/kunappwin/9wzdncrdrqc2)

# 概要

* Home
	* Tweetをナビゲートするキャラクタを選択します。
* Feed
	* kunkokuさん関連のRSSフィードリーダです。
* Tweet
	* kunkokuさん経由の購入ツィートです。

# ビルド

* Const.csクラスの追加

	プロジェクト\Commonディレクトリ内にあるConst.csをプロジェクトに追加します。

* Const.csの例

```Const.cs
		public const string ConsumerKey = "ConsumerKey";		// 取得したキーを代入します。
		public const string ConsumerSecret = "ConsumerSecret";	// 取得したキーを代入します。

		public const int TweetStringLength = 140;
		public const string ToScreenName = "kunkoku";			// テスト時は適当なサブアカウントにしてください。
		public const string PostTweetPhrase = "を購入したなう。#kunapp #KunappWin";
		public const string PreTweetPhrase = @"@" + Const.ToScreenName + " さん経由で";

		// for save and load class
		public const string FileDirectory = @".\";

		public const string FileName = "SETTINGS";
		public const string FileExtensionPlane = ".xml";
		public const string FileExtensionEnc = ".enc";
		public const string FileFillPathNonExtension = FileDirectory + FileName + ".";
		public const string FileFullPathPlane = FileDirectory + FileName + FileExtensionPlane;
		public const string FileFullPathEnc = FileDirectory + FileName + FileExtensionEnc;
		public const string Password = "password";				// password
		public const int SizeOfEos = 1;

		// for encript option
		public const string InitVector = "intvector";			// intvecor

		public const int KeySize = 256;
		public const int PasswordIterations = 1000; //2;
		public const string SaltValue = "saltvalue";			// saltvalue

		// size of setting data byte
		public const int SizeOfSaveByte = 4 * 1024 * 1024;

		// enum 
		public enum NavigateCharactor :  int
		{
			Bright = 0,
			Sayla,
			Kunkoku,
		}
		public static Dictionary<string, int> ActorLinesMain = new Dictionary<string, int>() {
			{"アプリの使用を許可する。", 1},
			{"砂漠に蝶は舞う。", 2},
			{"\r\nジャブローの認証が下りていないようだ。「Authorize Via External Web Browser」で外部ブラウザを開き、PINコードを入手するんだ。", 3},
			{"機密を保持した。", 4},
			{"PINコードを入力するんだ。", 5},
			{"ジオンの制空権内ということを自覚しろ！", 6},
			{"操作に誤りがあるようだ。聡明な貴方が・・・", 7},
			{"\r ジャブローへの通信回線が開いたぞ。", 8},
			{"ジャブローへの認証が失敗したようだ。貴様何をやっている！", 9},
			{"殴って何故悪い！", 10},
			{"通信を許可する。", 11},
			{"ミノフスキー濃度が濃いようだ・・・ \r通信回線を調べるんだ。", 12},
			{"貴様はシャアを越えられる奴だと思っていた。残念だよ。", 13},
			{"商品名入れてないよ！何やってんの！！", 14},
			{"文字数が多すぎるぞ！字数は、有効に使え！ (現在の文字数 = ", 15},
			{"？？ミノフスキー粒子濃度が濃いようだ・・・", 16},
			{"ジャブローへの認証が行われていないようだ。", 17},
			{"肩に力が入りすぎのようだな。大丈夫、コンピュータがやってくれますよ。", 18},
			{"・・・通信回線に問題があるようだ。第二ブリッジを調べろ。e:", 19},
			{"システムにトラブル発生。\r\n総員待避！", 20},
			{"全滅だと・・・\r\n機密を消去した。", 21},
		};
```

* 参照設定の追加

	パッケジマネージャーコンソールを開き、次のライブラリをNuGetで追加します。

	* CoreTweet

# Special Thanks
* CoreTweet : [https://github.com/CoreTweet/CoreTweet/wiki/Home%28%E6%97%A5%E6%9C%AC%E8%AA%9E%29](https://github.com/CoreTweet/CoreTweet/wiki/Home%28%E6%97%A5%E6%9C%AC%E8%AA%9E%29)

