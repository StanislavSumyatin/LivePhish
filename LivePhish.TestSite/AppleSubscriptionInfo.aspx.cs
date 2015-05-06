using LivePhish.Wrapper.Implementation;
using LivePhish.Wrapper.Interfaces;
using LivePhish.Wrapper.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LivePhish.TestSite
{
	public partial class AppleSubscriptionInfo : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var context = this.Context;
			var request = Helper.ReadStream(context.Request.InputStream);
			var disableReceipt = ConfigurationManager.AppSettings["disableReceiptVerification"] == "true";
			var client = new AppleSubscriptionClient(request);
			IHttpClient httpClient;

			if (disableReceipt)
			{
				httpClient = new MockHttpClient()
				{
					State = "0"
				};
			}
			else
			{
				httpClient = new HttpClient();
			}

			client.SetHttpClient(httpClient);

			var info = client.GetSubscriptionInfo();
			var response = JsonConvert.SerializeObject(info);

			context.Response.Clear();
			context.Response.Write(response);
			context.Response.End();
		}
	}
}