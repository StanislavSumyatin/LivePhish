using LivePhish.Wrapper.Interfaces;
using LivePhish.Wrapper.Utils;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LivePhish.Wrapper.Implementation
{
	public class HttpClient : IHttpClient
	{
		#region Private fields

		private static readonly Logger Log = LogManager.GetCurrentClassLogger();

		#endregion

		#region IHttpClient implementation

		public string SendPostRequest(string url, string requestData)
		{
			Log.Debug("SendPostRequest to url:`{0}'", url);

			var postBytes = Encoding.UTF8.GetBytes(requestData);

			var request = System.Net.HttpWebRequest.Create(url);
			request.Method = "POST";
			request.ContentType = "application/json";
			request.ContentLength = postBytes.Length;

			try
			{
				using (var stream = request.GetRequestStream())
				{
					stream.Write(postBytes, 0, postBytes.Length);
					stream.Flush();
				}

				var sendresponse = request.GetResponse();

				return Helper.ReadStream(sendresponse.GetResponseStream());
			}
			catch (Exception ex)
			{
				Log.Error("SendPostRequest to url:`{0}' exception: {1}", url, ex);
				throw;
			}
		}

		#endregion
	}
}
