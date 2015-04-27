﻿using LivePhish.Wrapper.Interfaces;

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
		            return string.Format("{{status:\"{0}\"}}", State);
		        }

		        return @"{
    ""receipt"": {
        ""original_purchase_date_pst"": ""2012-04-30 08:05:55 America/Los_Angeles"",
        ""original_transaction_id"": ""1000000046178817"",
        ""original_purchase_date_ms"": ""1335798355868"",
        ""transaction_id"": ""1000000046178817"",
        ""quantity"": ""1"",
        ""product_id"": ""br.com.jera.Example"",
        ""bvrs"": ""20120427"",
        ""purchase_date_ms"": ""1335798355868"",
        ""purchase_date"": ""2012-04-30 15:05:55 Etc/GMT"",
        ""original_purchase_date"": ""2012-04-30 15:05:55 Etc/GMT"",
        ""purchase_date_pst"": ""2012-04-30 08:05:55 America/Los_Angeles"",
        ""bid"": ""br.com.jera.Example"",
        ""item_id"": ""521129812""
    },
    ""status"": 0
}";
		    }

		    return null;
		}

		#endregion
	}
}
