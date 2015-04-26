using LivePhish.Wrapper.Interfaces;
using LivePhish.Wrapper.Models;
using LivePhish.Wrapper.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace LivePhish.Wrapper.Implementation
{
	public class AppleSubscriptionClient : ISubscriptionClient
	{
		#region Constants

		private const string TestUrl = "https://sandbox.itunes.apple.com/verifyReceipt";

		private const string ProdUrl = "https://buy.itunes.apple.com/verifyReceipt";

		#endregion

		#region Private fields

		private bool _isProduction;

		private string _receipt;

		private string _password;

		private IHttpClient _httpClient;

		#endregion

		#region Constructors

		public AppleSubscriptionClient(bool isProduction, string receipt, string password = null)
		{
			if (string.IsNullOrEmpty(receipt))
			{
				throw new ArgumentNullException("receipt", "Empty receipt");
			}

			_isProduction = isProduction;
			_receipt = Helper.GetBase64(receipt);
			_password = password;
		}

		#endregion

		#region Public methods

		public void SetHttpClient(IHttpClient client)
		{
			_httpClient = client;
		}

		#endregion

		#region ISubscriptionClient implementation

		public Receipt GetSubscriptionInfo()
		{
			var url = GetUrl();

			var json = new JObject(new JProperty("receipt-data", _receipt));
			if (!string.IsNullOrEmpty(_password))
			{
				json.Add(new JProperty("password", _password));
			}

			var response = _httpClient.SendPostRequest(url, json.ToString());
			if (string.IsNullOrEmpty(response))
			{
				throw new ApplicationException("Empty response");
			}

			var receiptResponse = JsonConvert.DeserializeObject<ReceiptResponse>(response);

			if (receiptResponse.status != 0)
			{
				switch (receiptResponse.status)
				{
					case 21000:
						throw new ApplicationException("The App Store could not read the JSON object you provided.");

					case 21002:
						throw new ApplicationException("The data in the receipt-data property was malformed or missing.");

					case 21003:
						throw new ApplicationException("The receipt could not be authenticated.");

					case 21004:
						throw new ApplicationException("The shared secret you provided does not match the shared secret on file for your account.");

					case 21005:
						throw new ApplicationException("The receipt server is not currently available.");

					case 21006:
						throw new ApplicationException("This receipt is valid but the subscription has expired. When this status code is returned to your server, the receipt data is also decoded and returned as part of the response.");

					case 21007:
						throw new ApplicationException("This receipt is from the test environment, but it was sent to the production environment for verification. Send it to the test environment instead.");

					case 21008:
						throw new ApplicationException("This receipt is from the production environment, but it was sent to the test environment for verification. Send it to the production environment instead.");
				
					default:
						throw new ApplicationException("Unknow receipt response status" + receiptResponse.status); 
				}
			}

			return receiptResponse.receipt;
		}

		public void CancelSubscription()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Private methods

		private string GetUrl()
		{
			return _isProduction ? ProdUrl : TestUrl;
		}

		#endregion
	}
}