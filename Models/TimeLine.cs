using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationMenuSample.Models
{
	public class TimeLine : INotifyPropertyChanged
	{
		private string screenName;
		public string ScreenName
		{
			get { return screenName; }
			set
			{
				screenName = value;
				OnPropertyChanged(new PropertyChangedEventArgs("ScreenName"));
			}
		}
		private string status;
		public string Status
		{
			get { return status; }
			set
			{
				status = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Status"));
			}
		}
		private string dateTime;
		public string DateTime
		{
			get { return dateTime; }
			set
			{
				dateTime = value;
				OnPropertyChanged(new PropertyChangedEventArgs("dateTime"));
			}
		}
		private string profileImageUrl;
		public string ProfileImageUrl
		{
			get { return profileImageUrl; }
			set
			{
				profileImageUrl = value;
				OnPropertyChanged(new PropertyChangedEventArgs("profileImageUrl"));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, e);
		}
	}
}
