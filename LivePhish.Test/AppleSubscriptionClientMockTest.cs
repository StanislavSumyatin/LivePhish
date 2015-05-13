using System;
using LivePhish.Wrapper.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LivePhish.Wrapper.Implementation;

namespace LivePhish.Test
{
	[TestClass]
	public class AppleSubscriptionClientMockTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetSubscriptionInfoEmptyReciept()
		{
            // ReSharper disable once UnusedVariable
			var client = new AppleSubscriptionClient("", false);
		}

		[TestMethod]
		// ReSharper disable once InconsistentNaming
		public void GetSubscriptionInfoOK()
		{
			var client = new AppleSubscriptionClient("receipt", false);
			var http = new MockHttpClient
			{
				State = "0"
			};
			client.SetHttpClient(http);
			var response = client.GetSubscriptionInfo();
			Assert.IsNotNull(response);
		}

        [TestMethod]
        [ExpectedException(typeof(AppleReceiptException))]
        public void GetSubscriptionInfoIncorrectReceipt()
        {
			var client = new AppleSubscriptionClient("receipt", false);
            var http = new MockHttpClient
            {
                State = "21005"
            };
            client.SetHttpClient(http);
            var response = client.GetSubscriptionInfo();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CancelSubscription()
        {
            // ReSharper disable once UnusedVariable
			var client = new AppleSubscriptionClient("receipt", false);
            client.CancelSubscription();
        }
	}
}
