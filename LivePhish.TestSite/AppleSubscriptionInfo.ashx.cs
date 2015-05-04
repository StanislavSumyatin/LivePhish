using LivePhish.Wrapper.Implementation;
using LivePhish.Wrapper.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace LivePhish.TestSite
{
	/// <summary>
	/// Summary description for AppleSubscriptionInfo1
	/// </summary>
	public class AppleSubscriptionInfo : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			var request = Helper.ReadStream(context.Request.InputStream);
			var mode = ConfigurationManager.AppSettings["mode"];
			var client = new AppleSubscriptionClient(mode == "production", request);
			client.SetHttpClient(new HttpClient());
			var info = client.GetSubscriptionInfo();
			context.Response.Write(info.item_id);
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}