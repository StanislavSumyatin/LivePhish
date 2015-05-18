using LivePhish.Wrapper.Exceptions;
using LivePhish.Wrapper.Interfaces;
using LivePhish.Wrapper.Models;
using LivePhish.Wrapper.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using System;
using System.Text.RegularExpressions;

namespace LivePhish.Wrapper.Implementation
{
	public class AppleSubscriptionClient : ISubscriptionClient
	{
		#region Constants

		private const string TestUrl = "https://sandbox.itunes.apple.com/verifyReceipt";

		private const string ProdUrl = "https://buy.itunes.apple.com/verifyReceipt";

		private const string Password = "63dea646d1c94bd8b7b175b5973775a8";

		#endregion

		#region Private fields

		private readonly bool _isProduction;

		private readonly string _receipt;

		private IHttpClient _httpClient;

		private static readonly Logger Log = LogManager.GetCurrentClassLogger();
		
		#endregion

		#region Constructors

		public AppleSubscriptionClient(string receipt, bool isProduction)
		{
			if (string.IsNullOrEmpty(receipt))
			{
				throw new ArgumentNullException("receipt");
			}

			_isProduction = isProduction;
			//_receipt = Helper.GetBase64(receipt);
			_receipt = receipt;
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

		public ReceiptResponse GetSubscriptionInfo()
		{
			var url = GetUrl();

			var json = new JObject(new JProperty("receipt-data", _receipt));
			json.Add(new JProperty("password", Password));

			var response = _httpClient.SendPostRequest(url, json.ToString());
			if (string.IsNullOrEmpty(response))
			{
				Log.Error("Empty response");
				throw new ApplicationException("Empty response");
			}

			var receiptResponse = JsonConvert.DeserializeObject<ReceiptResponse>(response);

			if (receiptResponse.status != 0)
			{
                throw new AppleReceiptException(receiptResponse.status, receiptResponse.exception + Environment.NewLine + "Receipt: " + json);
			}

			return receiptResponse;
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