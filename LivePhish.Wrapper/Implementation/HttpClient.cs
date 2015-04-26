using LivePhish.Wrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LivePhish.Wrapper.Implementation
{
	public class HttpClient : IHttpClient
	{
		public string SendPostRequest(string url, string requestData)
		{
			var postBytes = Encoding.UTF8.GetBytes(requestData);

			var request = System.Net.HttpWebRequest.Create(url);
			request.Method = "POST";
			request.ContentType = "application/json";
			request.ContentLength = postBytes.Length;

			using (var stream = request.GetRequestStream())
			{
				stream.Write(postBytes, 0, postBytes.Length);
				stream.Flush();
			}
			var sendresponse = request.GetResponse();

			using (var streamReader = new StreamReader(sendresponse.GetResponseStream()))
			{
				return streamReader.ReadToEnd().Trim();
			}
		}
	}
}
