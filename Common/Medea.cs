using NavigationMenuSample.Helper;
using NavigationMenuSample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.Storage;

namespace NavigationMenuSample.Common
{
	public class Medea
	{
		private const string keyValue = "UvjfgyIY1phY5nMMxyOQoeHw";
		private const string xmlFileName = "Pseristance.xml";
		public static List<PersistModel> MyModel { get; set; }
		public static List<PersistModel> loadModel { get; set; }

		public Medea()
		{
			MyModel = new List<PersistModel>();
			loadModel = new List<PersistModel>();
		}

		public void AddPersist(PersistModel persist)
		{
			MyModel.Add(persist);
		}
		public List<PersistModel> GetPersist()
		{
			return MyModel;
		}
		public List<PersistModel> GetLoadData()
		{
			return loadModel;
		}

		public async Task<bool> Woody()
		{
			bool result = false;
			await Task.Run(() => AsyncWoody<List<PersistModel>>(MyModel, xmlFileName));
			// verify
			await Task.Run(() => AsyncMatilda<List<PersistModel>>(xmlFileName));
			string dabamy = XmlSerializer<List<PersistModel>>.Serialize(MyModel);
			string load = XmlSerializer<List<PersistModel>>.Serialize(loadModel);
			if (dabamy == load)
			{
				result = true;
			}
#if DEBUG
			if (result)
			{
				Debug.WriteLine("Saved");
			}
			else
			{
				Debug.WriteLine("Error in Saved");
			}
#endif
			return result;
		}
		private static async void AsyncWoody<T>(T observableCollection, string xmlFileName)
		{
			var storage = Windows.Storage.ApplicationData.Current.LocalSettings;

			if (!storage.Containers.ContainsKey(keyValue))
			{
				storage.CreateContainer(keyValue, Windows.Storage.ApplicationDataCreateDisposition.Always);
			}
			using (MemoryStream stream = new MemoryStream())
			{
				DataContractSerializer serializer = new DataContractSerializer(observableCollection.GetType());
				serializer.WriteObject(stream, observableCollection);
				stream.Position = 0;
				using (StreamReader reader = new StreamReader(stream))
				{
					storage.Values["settings"] = reader.ReadToEnd();
				}
			}
			var setting = ApplicationData.Current.LocalSettings;
			setting.CreateContainer("container", ApplicationDataCreateDisposition.Always);
			setting.Containers["container"].Values["settings"] = storage.Values["settings"];
			await Task.FromResult(0);
		}

		public async Task<List<PersistModel>> Matilda()
		{
			List<PersistModel> resut = new List<PersistModel>();
			resut = null;
			await Task.Run(() => AsyncMatilda<List<PersistModel>>(xmlFileName));
			resut = loadModel;
			return resut;
		}
		private static async void AsyncMatilda<T>(string xmlFileName)
		{
			var setting = ApplicationData.Current.LocalSettings;
			try
			{
				var xml = setting.Containers["container"].Values["settings"];
				using (Stream stream = new MemoryStream())
				{
					byte[] data = System.Text.Encoding.UTF8.GetBytes((string)xml);
					stream.Write(data, 0, data.Length);
					stream.Position = 0;
					DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
					loadModel = (List<PersistModel>)deserializer.ReadObject(stream);
				}
#if DEBUG
				string debt = XmlSerializer<List<PersistModel>>.Serialize(loadModel);
				Debug.WriteLine(debt);
#endif
			}
			catch (KeyNotFoundException e)
			{
				Debug.WriteLine(e);
				return;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				return;
			}
			await Task.FromResult(0);
		}

		public async Task<int> JetStreamAttack()
		{
			int t = GetSettingValueCount();
			try
			{
				await Windows.Storage.ApplicationData.Current.ClearAsync();
				t = GetSettingValueCount();
			}
			catch (Exception)
			{
				return t;
			}
			return t;
		}
		static int GetSettingValueCount()
		{
			var storage = Windows.Storage.ApplicationData.Current.LocalSettings;
			return storage.Containers.Values.Count();
		}
	}
}