using System;
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
			var client = new AppleSubscriptionClient(true, "");
		}

		[TestMethod]
		public void GetSubscriptionInfoOK()
		{
			var client = new AppleSubscriptionClient(false, "receipt");
			var http = new MockHttpClient
			{
				State = "0"
			};
			client.SetHttpClient(http);
			var response = client.GetSubscriptionInfo();
			Assert.IsNotNull(response);
		}
	}
}
