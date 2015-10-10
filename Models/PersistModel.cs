using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using NavigationMenuSample.Helper;

namespace NavigationMenuSample.Models
{
	[KnownType(typeof(NavigationMenuSample.Models.PersistModel))]
	[DataContractAttribute]
	public class PersistModel
	{
		#region Fields
		private string _userID;
		private string _screenName;

		private string _requestToken;
		private string _requestSecretToken;

		private string _accessToken;
		private string _accessSecretToken;
		#endregion

		#region Properies
		[DataMember()]
		public string UserID
		{
			get { return _userID; }
			set { _userID = value; }
		}
		[DataMember()]
		public string ScreenName
		{
			get { return _screenName; }
			set { _screenName = value; }
		}

		// リクエストトークンはXMLに書き込まない
		[System.Xml.Serialization.XmlIgnoreAttribute]
		public string RequestToken
		{
			get { return _requestToken; }
			set { _requestToken = value; }
		}

		// リクエストシークレットはXMLに書き込まない
		[System.Xml.Serialization.XmlIgnoreAttribute]
		public string RequestSecretToken
		{
			get { return _requestSecretToken; }
			set { _requestSecretToken = value; }
		}
		[DataMember()]
		public string AccessToken
		{
			get { return _accessToken; }
			set { _accessToken = value; }
		}
		[DataMember()]
		public string AccessSecretToken
		{
			get { return _accessSecretToken; }
			set { _accessSecretToken = value; }
		}
#if false
		// ナビゲータの保存
		[DataMember()]
		public int NavChara { get; set; }
#endif
#endregion

	}
}
