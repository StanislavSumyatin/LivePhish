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
			var transactionReceipt = context.Request["transactionReceipt"];
			// var request = Helper.GetPlainFromBase64(transactionReceipt);
			//var request = Helper.ReadStream(context.Request.InputStream);

			var requestDto = JsonConvert.DeserializeObject<RequestDto>(transactionReceipt);

			var disableReceipt = ConfigurationManager.AppSettings["disableReceiptVerification"] == "true";
			var client = new AppleSubscriptionClient(requestDto.receipt, string.Compare("Sandbox", requestDto.environment, true) != 0);
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