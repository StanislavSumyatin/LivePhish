using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivePhish.Wrapper.Interfaces
{
	public interface IHttpClient
	{
		/// <summary>
		/// Send POST request to url with specified data
		/// </summary>
		/// <param name="url"></param>
		/// <param name="requestData"></param>
		/// <returns></returns>
		string SendPostRequest(string url, string requestData);
	}
}
