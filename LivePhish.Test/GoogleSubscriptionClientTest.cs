using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePhish.Wrapper.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LivePhish.Test
{
    [TestClass]
    public class GoogleSubscriptionClientTest
    {
        #region Public methods

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GoogleSubscriptionClientEmptyParameter1()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new GoogleSubscriptionClient(true, null, "subscriptionId", "token");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GoogleSubscriptionClientEmptyParameter2()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new GoogleSubscriptionClient(true, "packageName", string.Empty, "token");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GoogleSubscriptionClientEmptyParameter3()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new GoogleSubscriptionClient(true, "packageName", "subscriptionId", null);
        }

        #endregion
    }
}
