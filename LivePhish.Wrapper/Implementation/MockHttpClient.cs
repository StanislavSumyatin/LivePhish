using LivePhish.Wrapper.Interfaces;
using System;

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

				var rnd = new Random(DateTime.Now.Millisecond);
				var original_transaction_id = (long)rnd.Next(100000000, int.MaxValue) * 4;
				var original_purchase_date_ms = (long)rnd.Next(100000000, int.MaxValue) * 2;
				var transaction_id = (long)rnd.Next(100000000, int.MaxValue) * 2;
				var purchase_date_ms = (long)rnd.Next(100000000, int.MaxValue) * 2;
				var item_id = rnd.Next(100000, 10000000);

		        return string.Format(@"{{
    ""receipt"": {{
        ""original_purchase_date_pst"": ""2012-04-30 08:05:55 America/Los_Angeles"",
        ""original_transaction_id"": ""{0}"",
        ""original_purchase_date_ms"": ""{1}"",
        ""transaction_id"": ""{2}"",
        ""quantity"": ""1"",
        ""product_id"": ""br.com.jera.Example"",
        ""bvrs"": ""20120427"",
        ""purchase_date_ms"": ""{3}"",
        ""purchase_date"": ""2012-04-30 15:05:55 Etc/GMT"",
        ""original_purchase_date"": ""2012-04-30 15:05:55 Etc/GMT"",
        ""purchase_date_pst"": ""2012-04-30 08:05:55 America/Los_Angeles"",
        ""bid"": ""br.com.jera.Example"",
        ""item_id"": ""{4}""
    }},
    ""status"": 0
}}", original_transaction_id, original_purchase_date_ms, transaction_id, purchase_date_ms, item_id);
		    }

		    return null;
		}

		#endregion
	}
}
