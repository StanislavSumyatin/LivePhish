using LivePhish.Wrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivePhish.Wrapper.Interfaces
{
	public interface ISubscriptionClient
	{
		Receipt GetSubscriptionInfo();

		void CancelSubscription();
	}
}
