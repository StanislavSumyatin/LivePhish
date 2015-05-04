using LivePhish.Wrapper.Interfaces;
using LivePhish.Wrapper.Models;
using LivePhish.Wrapper.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using LivePhish.Wrapper.Exceptions;
using NLog;

namespace LivePhish.Wrapper.Implementation
{
	public class AppleSubscriptionClient : ISubscriptionClient
	{
		#region Constants

		private const string TestUrl = "https://sandbox.itunes.apple.com/verifyReceipt";

		private const string ProdUrl = "https://buy.itunes.apple.com/verifyReceipt";

		#endregion

		#region Private fields

		private readonly bool _isProduction;

		private readonly string _receipt;

		private readonly string _password;

		private IHttpClient _httpClient;

		private static readonly Logger Log = LogManager.GetCurrentClassLogger();

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
			if (client == null)
			{
				throw new ArgumentNullException("client");
			}

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
				Log.Error("Empty response");
				throw new ApplicationException("Empty response");
			}

			var receiptResponse = JsonConvert.DeserializeObject<ReceiptResponse>(response);

			if (receiptResponse.status != 0)
			{
				Log.Error("Response status : {0}", receiptResponse.status);
                throw new AppleReceiptException(receiptResponse.status, receiptResponse.exception);
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