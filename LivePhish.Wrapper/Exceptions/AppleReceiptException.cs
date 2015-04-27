using System;

namespace LivePhish.Wrapper.Exceptions
{
    public class AppleReceiptException : LivePhishException
    {
        #region Constructors

        public AppleReceiptException(int status, string exceptionMessage = null)
            : base(GetMessage(status))
        {
            Status = status;
            ExceptionMessage = exceptionMessage;
        }

        #endregion

        #region Public properties

        public int Status { get; set; }

        public string ExceptionMessage { get; set; }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return string.Format("{0}: {1}{2}{3}", Status, Message, Environment.NewLine, ExceptionMessage).Trim();
        }

        #endregion

        #region Private methods

        private static string GetMessage(int status)
        {
            switch (status)
            {
                case 21000:
                    return "The App Store could not read the JSON object you provided.";

                case 21002:
                    return "The data in the receipt-data property was malformed or missing.";

                case 21003:
                    return "The receipt could not be authenticated.";

                case 21004:
                    return "The shared secret you provided does not match the shared secret on file for your account.";

                case 21005:
                    return "The receipt server is not currently available.";

                case 21006:
                    return "This receipt is valid but the subscription has expired. When this status code is returned to your server, the receipt data is also decoded and returned as part of the response.";

                case 21007:
                    return "This receipt is from the test environment, but it was sent to the production environment for verification. Send it to the test environment instead.";

                case 21008:
                    return "This receipt is from the production environment, but it was sent to the test environment for verification. Send it to the production environment instead.";

                default:
                    return "Unknow receipt response status";
            }
        }

        #endregion
    }
}
