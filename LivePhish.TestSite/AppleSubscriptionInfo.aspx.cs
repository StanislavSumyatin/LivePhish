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
using NLog;

namespace LivePhish.TestSite
{
	public partial class AppleSubscriptionInfo : System.Web.UI.Page
	{		
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
            var log = LogManager.GetCurrentClassLogger();
            var context = this.Context;
            context.Response.Clear();

		    try
		    {
		        var transactionReceipt = HttpUtility.UrlDecode(context.Request["transactionReceipt"]);
		        // var request = Helper.GetPlainFromBase64(transactionReceipt);
		        //var request = Helper.ReadStream(context.Request.InputStream);

                log.Info("Request: " + transactionReceipt);

		        var requestDto = JsonConvert.DeserializeObject<RequestDto>(transactionReceipt);

		        var disableReceipt = ConfigurationManager.AppSettings["disableReceiptVerification"] == "true";
		        var client = new AppleSubscriptionClient(requestDto.receipt,
		            string.Compare("Sandbox", requestDto.environment, true) != 0);
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

                //log.Info("Request: " + transactionReceipt);

		        client.SetHttpClient(httpClient);

		        var info = client.GetSubscriptionInfo();
		        var response = JsonConvert.SerializeObject(info);
                context.Response.Write(response);

            }
            catch (Exception ex)
            {
                log.ErrorException(ex.ToString(), ex);
                context.Response.Write(ex.ToString());
            }
		   
		    context.Response.End();
		}
	}
}