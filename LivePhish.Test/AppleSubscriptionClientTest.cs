using LivePhish.Wrapper.Exceptions;
using LivePhish.Wrapper.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LivePhish.Test
{
    [TestClass]
    public class AppleSubscriptionClientTest
    {
        #region Constants

        private const string Receipt = @"{
	""signature"" = ""ApMUBC86AlzNikV5YtrZAMiJQbK8EdeXk63kWBAXzlC8dXGujq47ZnIYKoFE1oN/FS8cXlFfp9YXt9iMBdL250lRRmiNGbyhitryYVAQori32W9aR0T8L/aYVBdfW+Oy/QyPZEmoNKxhnt2WNSUDoUhZ8Z+4pP70pe5kUQlbdIVhAAADVzCCA1MwggI7oAMCAQICCGUUkU3ZWAS1MA0GCSqGSIb3DQEBBQUAMH8xCzAJBgNVBAYTAlVTMRMwEQYDVQQKDApBcHBsZSBJbmMuMSYwJAYDVQQLDB1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTEzMDEGA1UEAwwqQXBwbGUgaVR1bmVzIFN0b3JlIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MB4XDTA5MDYxNTIyMDU1NloXDTE0MDYxNDIyMDU1NlowZDEjMCEGA1UEAwwaUHVyY2hhc2VSZWNlaXB0Q2VydGlmaWNhdGUxGzAZBgNVBAsMEkFwcGxlIGlUdW5lcyBTdG9yZTETMBEGA1UECgwKQXBwbGUgSW5jLjELMAkGA1UEBhMCVVMwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBAMrRjF2ct4IrSdiTChaI0g8pwv/cmHs8p/RwV/rt/91XKVhNl4XIBimKjQQNfgHsDs6yju++DrKJE7uKsphMddKYfFE5rGXsAdBEjBwRIxexTevx3HLEFGAt1moKx509dhxtiIdDgJv2YaVs49B0uJvNdy6SMqNNLHsDLzDS9oZHAgMBAAGjcjBwMAwGA1UdEwEB/wQCMAAwHwYDVR0jBBgwFoAUNh3o4p2C0gEYtTJrDtdDC5FYQzowDgYDVR0PAQH/BAQDAgeAMB0GA1UdDgQWBBSpg4PyGUjFPhJXCBTMzaN+mV8k9TAQBgoqhkiG92NkBgUBBAIFADANBgkqhkiG9w0BAQUFAAOCAQEAEaSbPjtmN4C/IB3QEpK32RxacCDXdVXAeVReS5FaZxc+t88pQP93BiAxvdW/3eTSMGY5FbeAYL3etqP5gm8wrFojX0ikyVRStQ+/AQ0KEjtqB07kLs9QUe8czR8UGfdM1EumV/UgvDd4NwNYxLQMg4WTQfgkQQVy8GXZwVHgbE/UC6Y7053pGXBk51NPM3woxhd3gSRLvXj+loHsStcTEqe9pBDpmG5+sk4tw+GK3GMeEN5/+e1QT9np/Kl1nj+aBw7C0xsy0bFnaAd1cSS6xdory/CUvM6gtKsmnOOdqTesbp0bs8sn6Wqs0C9dgcxRHuOMZ2tm8npLUm7argOSzQ=="";
	""purchase-info"" = ""ewoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtcHN0IiA9ICIyMDEyLTA0LTMwIDA4OjA1OjU1IEFtZXJpY2EvTG9zX0FuZ2VsZXMiOwoJIm9yaWdpbmFsLXRyYW5zYWN0aW9uLWlkIiA9ICIxMDAwMDAwMDQ2MTc4ODE3IjsKCSJidnJzIiA9ICIyMDEyMDQyNyI7CgkidHJhbnNhY3Rpb24taWQiID0gIjEwMDAwMDAwNDYxNzg4MTciOwoJInF1YW50aXR5IiA9ICIxIjsKCSJvcmlnaW5hbC1wdXJjaGFzZS1kYXRlLW1zIiA9ICIxMzM1Nzk4MzU1ODY4IjsKCSJwcm9kdWN0LWlkIiA9ICJjb20ubWluZG1vYmFwcC5kb3dubG9hZCI7CgkiaXRlbS1pZCIgPSAiNTIxMTI5ODEyIjsKCSJiaWQiID0gImNvbS5taW5kbW9iYXBwLk1pbmRNb2IiOwoJInB1cmNoYXNlLWRhdGUtbXMiID0gIjEzMzU3OTgzNTU4NjgiOwoJInB1cmNoYXNlLWRhdGUiID0gIjIwMTItMDQtMzAgMTU6MDU6NTUgRXRjL0dNVCI7CgkicHVyY2hhc2UtZGF0ZS1wc3QiID0gIjIwMTItMDQtMzAgMDg6MDU6NTUgQW1lcmljYS9Mb3NfQW5nZWxlcyI7Cgkib3JpZ2luYWwtcHVyY2hhc2UtZGF0ZSIgPSAiMjAxMi0wNC0zMCAxNTowNTo1NSBFdGMvR01UIjsKfQ=="";
	""environment"" = ""Sandbox"";
	""pod"" = ""100"";
	""signing-status"" = ""0"";
}";

        private const string IncorrectReceipt = @"{
	""signature"" = ""ApMUBC86AlzNikV5YtrZAMiJQbK8EdeXk6gfhjghAXzlC8dXGujq47ZnIYKoFE1oN/FS8cXlFfp9YXt9iMBdL250lRRmiNGbyhitryYVAQori32W9aR0T8L/aYVBdfW+Oy/QyPZEmoNKxhnt2WNSUDoUhZ8Z+4pP70pe5kUQlbdIVhAAADVzCCA1MwggI7oAMCAQICCGUUkU3ZWAS1MA0GCSqGSIb3DQEBBQUAMH8xCzAJBgNVBAYTAlVTMRMwEQYDVQQKDApBcHBsZSBJbmMuMSYwJAYDVQQLDB1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTEzMDEGA1UEAwwqQXBwbGUgaVR1bmVzIFN0b3JlIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MB4XDTA5MDYxNTIyMDU1NloXDTE0MDYxNDIyMDU1NlowZDEjMCEGA1UEAwwaUHVyY2hhc2VSZWNlaXB0Q2VydGlmaWNhdGUxGzAZBgNVBAsMEkFwcGxlIGlUdW5lcyBTdG9yZTETMBEGA1UECgwKQXBwbGUgSW5jLjELMAkGA1UEBhMCVVMwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBAMrRjF2ct4IrSdiTChaI0g8pwv/cmHs8p/RwV/rt/91XKVhNl4XIBimKjQQNfgHsDs6yju++DrKJE7uKsphMddKYfFE5rGXsAdBEjBwRIxexTevx3HLEFGAt1moKx509dhxtiIdDgJv2YaVs49B0uJvNdy6SMqNNLHsDLzDS9oZHAgMBAAGjcjBwMAwGA1UdEwEB/wQCMAAwHwYDVR0jBBgwFoAUNh3o4p2C0gEYtTJrDtdDC5FYQzowDgYDVR0PAQH/BAQDAgeAMB0GA1UdDgQWBBSpg4PyGUjFPhJXCBTMzaN+mV8k9TAQBgoqhkiG92NkBgUBBAIFADANBgkqhkiG9w0BAQUFAAOCAQEAEaSbPjtmN4C/IB3QEpK32RxacCDXdVXAeVReS5FaZxc+t88pQP93BiAxvdW/3eTSMGY5FbeAYL3etqP5gm8wrFojX0ikyVRStQ+/AQ0KEjtqB07kLs9QUe8czR8UGfdM1EumV/UgvDd4NwNYxLQMg4WTQfgkQQVy8GXZwVHgbE/UC6Y7053pGXBk51NPM3woxhd3gSRLvXj+loHsStcTEqe9pBDpmG5+sk4tw+GK3GMeEN5/+e1QT9np/Kl1nj+aBw7C0xsy0bFnaAd1cSS6xdory/CUvM6gtKsmnOOdqTesbp0bs8sn6Wqs0C9dgcxRHuOMZ2tm8npLUm7argOSzQ=="";
	""purchase-info"" = ""ewoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtcHN0IiA9ICIyMDEyLTA0LTMwIDA4OjA1Oj45EFtZXJpY2EvTG9zX0FuZ2VsZXMiOwoJIm9yaWdpbmFsLXRyYW5zYWN0aW9uLWlkIiA9ICIxMDAwMDAwMDQ2MTc4ODE3IjsKCSJidnJzIiA9ICIyMDEyMDQyNyI7CgkidHJhbnNhY3Rpb24taWQiID0gIjEwMDAwMDAwNDYxNzg4MTciOwoJInF1YW50aXR5IiA9ICIxIjsKCSJvcmlnaW5hbC1wdXJjaGFzZS1kYXRlLW1zIiA9ICIxMzM1Nzk4MzU1ODY4IjsKCSJwcm9kdWN0LWlkIiA9ICJjb20ubWluZG1vYmFwcC5kb3dubG9hZCI7CgkiaXRlbS1pZCIgPSAiNTIxMTI5ODEyIjsKCSJiaWQiID0gImNvbS5taW5kbW9iYXBwLk1pbmRNb2IiOwoJInB1cmNoYXNlLWRhdGUtbXMiID0gIjEzMzU3OTgzNTU4NjgiOwoJInB1cmNoYXNlLWRhdGUiID0gIjIwMTItMDQtMzAgMTU6MDU6NTUgRXRjL0dNVCI7CgkicHVyY2hhc2UtZGF0ZS1wc3QiID0gIjIwMTItMDQtMzAgMDg6MDU6NTUgQW1lcmljYS9Mb3NfQW5nZWxlcyI7Cgkib3JpZ2luYWwtcHVyY2hhc2UtZGF0ZSIgPSAiMjAxMi0wNC0zMCAxNTowNTo1NSBFdGMvR01UIjsKfQ=="";
	""environment"" = ""Sandbox"";
	""pod"" = ""100"";
	""signing-status"" = ""0"";
}";

        #endregion

        #region Public methods

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetSubscriptionInfoEmptyReciept()
        {
            // ReSharper disable once UnusedVariable
            var client = new AppleSubscriptionClient(true, "");
        }

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void GetSubscriptionInfoOK()
        {
            var client = new AppleSubscriptionClient(false, Receipt);
            client.SetHttpClient(new HttpClient());
            var response = client.GetSubscriptionInfo();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(AppleReceiptException))]
        public void GetSubscriptionInfoIncorrectReceipt()
        {
            var client = new AppleSubscriptionClient(false, IncorrectReceipt);
            client.SetHttpClient(new HttpClient());
            var response = client.GetSubscriptionInfo();
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CancelSubscription()
        {
            // ReSharper disable once UnusedVariable
            var client = new AppleSubscriptionClient(true, Receipt);
            client.CancelSubscription();
        }

        #endregion
    }
}
