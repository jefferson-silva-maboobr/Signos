using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net.Http;
using System.Diagnostics;

namespace Signos
{
	public class RestAPI
	{
		private static string ENDPOINT = "http://www.json-generator.com/api/json/get/bOrUyJDxiW?indent=2";
		private static RestAPI _instance;

		public static RestAPI Instance {
			get {
				if (_instance == null) {
					_instance = new RestAPI ();
				}
				return _instance;
			}
		}

		public async Task<Boolean> RefreshDataAsync ()
		{
			List<SignoItem> parsedList = await DownloadListAsync ();

			if (parsedList != null && parsedList.Count > 0) {
				SaveData (parsedList);
				return true;
			}

			return false;
		}

		public void SaveData (List<SignoItem> parsedList)
		{
			foreach (SignoItem item in parsedList) {
				SignoItem.SaveItem (item);
			}
		}

		public async Task<List<SignoItem>> DownloadListAsync ()
		{
			List<SignoItem> restList = new List <SignoItem> ();;
	
			var httpClient = new HttpClient ();
			Task<string> downloadTask = httpClient.GetStringAsync (ENDPOINT);
			string content = await downloadTask;	
			Debug.WriteLine ("Response: \r\n {0}", content);

			// de-serializing json response into list
			JArray jsonResponse = JArray.Parse (content);
			restList = jsonResponse.ToObject<List<SignoItem>> ();

			Debug.WriteLine ("Response: \r\n {0}", restList);

			return restList;
		}
	}
}
