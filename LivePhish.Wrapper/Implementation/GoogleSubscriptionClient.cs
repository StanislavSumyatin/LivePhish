using LivePhish.Wrapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LivePhish.Wrapper.Models;

namespace LivePhish.Wrapper.Implementation
{
	public class GoogleSubscriptionClient : ISubscriptionClient
    {
        #region Constants

        private const string SubscriptionInfoUrl = "https://www.googleapis.com/androidpublisher/v2/applications/{0}/purchases/subscriptions/{1}/tokens/{2}";

        #endregion

        #region Private fields

        private readonly bool _isProduction;

        private readonly string _packageName;

        private readonly string _subscriptionId;

        private readonly string _token;

        #endregion

        #region Constructors

        public GoogleSubscriptionClient(bool isProduction, string packageName, string subscriptionId, string token)
        {
            if (string.IsNullOrEmpty(packageName))
            {
                throw new ArgumentNullException("packageName");
            }

            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException("subscriptionId");
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("token");
            }

            _isProduction = isProduction;
            _packageName = packageName;
            _subscriptionId = subscriptionId;
            _token = token;
        }

        #endregion

        #region ISubscriptionClient implementation

		public ReceiptResponse GetSubscriptionInfo()
		{
			throw new NotImplementedException();
		}

		public void CancelSubscription()
		{
			throw new NotImplementedException();
        }

        #endregion
    }
}
