using LivePhish.Wrapper.Interfaces;
using LivePhish.Wrapper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivePhish.Wrapper.Implementation
{
	public class MockHttpClient : IHttpClient
	{
		#region Public properties

		public string State { get; set; }

		#endregion

		#region IHttpClient implementation

		public string SendPostRequest(string url, string requestData)
		{
			if (url.EndsWith("verifyReceipt"))
			{
				if (State != "0")
				{
					return string.Format("{{status:\"{}\"}}", State);
				}

				var response = new ReceiptResponse
				{
					receipt = new Receipt(),
					status = 0
				};

				return JsonConvert.SerializeObject(response);
			}

			return null;
		}

		#endregion
	}
}
