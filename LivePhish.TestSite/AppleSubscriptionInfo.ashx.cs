using LivePhish.Wrapper.Implementation;
using LivePhish.Wrapper.Models;
using LivePhish.Wrapper.Utils;
using Newtonsoft.Json;
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
			var response = JsonConvert.SerializeObject(info);
			context.Response.Write(response);
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