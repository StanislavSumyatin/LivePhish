# LivePhish

## Apple wrapper
URL of test site: http://phish.provectus-it.com/AppleSubscriptionInfo.aspx

Request format example:
```
{
	"signature" = "ApMUBC86AlzNikV5YtrZAMiJQbK8EdeXk63kWBAXzlC8dXGujq47ZnIYKoFE1oN/FS8cXlFfp9YXt9iMBdL250lRRmiNGbyhitryYVAQori32W9aR0T8L/aYVBdfW+Oy/QyPZEmoNKxhnt2WNSUDoUhZ8Z+4pP70pe5kUQlbdIVhAAADVzCCA1MwggI7oAMCAQICCGUUkU3ZWAS1MA0GCSqGSIb3DQEBBQUAMH8xCzAJBgNVBAYTAlVTMRMwEQYDVQQKDApBcHBsZSBJbmMuMSYwJAYDVQQLDB1BcHBsZSBDZXJ0aWZpY2F0aW9uIEF1dGhvcml0eTEzMDEGA1UEAwwqQXBwbGUgaVR1bmVzIFN0b3JlIENlcnRpZmljYXRpb24gQXV0aG9yaXR5MB4XDTA5MDYxNTIyMDU1NloXDTE0MDYxNDIyMDU1NlowZDEjMCEGA1UEAwwaUHVyY2hhc2VSZWNlaXB0Q2VydGlmaWNhdGUxGzAZBgNVBAsMEkFwcGxlIGlUdW5lcyBTdG9yZTETMBEGA1UECgwKQXBwbGUgSW5jLjELMAkGA1UEBhMCVVMwgZ8wDQYJKoZIhvcNAQEBBQADgY0AMIGJAoGBAMrRjF2ct4IrSdiTChaI0g8pwv/cmHs8p/RwV/rt/91XKVhNl4XIBimKjQQNfgHsDs6yju++DrKJE7uKsphMddKYfFE5rGXsAdBEjBwRIxexTevx3HLEFGAt1moKx509dhxtiIdDgJv2YaVs49B0uJvNdy6SMqNNLHsDLzDS9oZHAgMBAAGjcjBwMAwGA1UdEwEB/wQCMAAwHwYDVR0jBBgwFoAUNh3o4p2C0gEYtTJrDtdDC5FYQzowDgYDVR0PAQH/BAQDAgeAMB0GA1UdDgQWBBSpg4PyGUjFPhJXCBTMzaN+mV8k9TAQBgoqhkiG92NkBgUBBAIFADANBgkqhkiG9w0BAQUFAAOCAQEAEaSbPjtmN4C/IB3QEpK32RxacCDXdVXAeVReS5FaZxc+t88pQP93BiAxvdW/3eTSMGY5FbeAYL3etqP5gm8wrFojX0ikyVRStQ+/AQ0KEjtqB07kLs9QUe8czR8UGfdM1EumV/UgvDd4NwNYxLQMg4WTQfgkQQVy8GXZwVHgbE/UC6Y7053pGXBk51NPM3woxhd3gSRLvXj+loHsStcTEqe9pBDpmG5+sk4tw+GK3GMeEN5/+e1QT9np/Kl1nj+aBw7C0xsy0bFnaAd1cSS6xdory/CUvM6gtKsmnOOdqTesbp0bs8sn6Wqs0C9dgcxRHuOMZ2tm8npLUm7argOSzQ==";
	"purchase-info" = "ewoJIm9yaWdpbmFsLXB1cmNoYXNlLWRhdGUtcHN0IiA9ICIyMDEyLTA0LTMwIDA4OjA1OjU1IEFtZXJpY2EvTG9zX0FuZ2VsZXMiOwoJIm9yaWdpbmFsLXRyYW5zYWN0aW9uLWlkIiA9ICIxMDAwMDAwMDQ2MTc4ODE3IjsKCSJidnJzIiA9ICIyMDEyMDQyNyI7CgkidHJhbnNhY3Rpb24taWQiID0gIjEwMDAwMDAwNDYxNzg4MTciOwoJInF1YW50aXR5IiA9ICIxIjsKCSJvcmlnaW5hbC1wdXJjaGFzZS1kYXRlLW1zIiA9ICIxMzM1Nzk4MzU1ODY4IjsKCSJwcm9kdWN0LWlkIiA9ICJjb20ubWluZG1vYmFwcC5kb3dubG9hZCI7CgkiaXRlbS1pZCIgPSAiNTIxMTI5ODEyIjsKCSJiaWQiID0gImNvbS5taW5kbW9iYXBwLk1pbmRNb2IiOwoJInB1cmNoYXNlLWRhdGUtbXMiID0gIjEzMzU3OTgzNTU4NjgiOwoJInB1cmNoYXNlLWRhdGUiID0gIjIwMTItMDQtMzAgMTU6MDU6NTUgRXRjL0dNVCI7CgkicHVyY2hhc2UtZGF0ZS1wc3QiID0gIjIwMTItMDQtMzAgMDg6MDU6NTUgQW1lcmljYS9Mb3NfQW5nZWxlcyI7Cgkib3JpZ2luYWwtcHVyY2hhc2UtZGF0ZSIgPSAiMjAxMi0wNC0zMCAxNTowNTo1NSBFdGMvR01UIjsKfQ==";
	"environment" = "Sandbox";
	"pod" = "100";
	"signing-status" = "0";
}
```
For switching to production mode change `environment` to “Production” (or other proper value for  iTunes – need example of real verification).

To disable receipt verification and get correct response for any well-formatted request with random data please set `disableReceiptVerification` to “true” in web.config file on the server.

JSON with receipt information example:
```
{"original_purchase_date_pst":"2012-04-30 08:05:55 America/Los_Angeles","original_transaction_id":"1000000046178817","original_purchase_date_ms":"1335798355868","transaction_id":"1000000046178817","quantity":"1","product_id":"com.mindmobapp.download","bvrs":"20120427","purchase_date_ms":"1335798355868","purchase_date":"2012-04-30 15:05:55 Etc/GMT","original_purchase_date":"2012-04-30 15:05:55 Etc/GMT","purchase_date_pst":"2012-04-30 08:05:55 America/Los_Angeles","bid":"com.mindmobapp.MindMob","item_id":"521129812"}
```

Example of using wrapper:

- Initialize apple wrapper with request data:

`var client = new AppleSubscriptionClient(request);`

- Assignee IHttpClient instance:

`client.SetHttpClient(new HttpClient());`

- Get receipt information with subscription:

`var info = client.GetSubscriptionInfo();`

## Google wrapper - TBD

## Solution structure
- Libs - third-party libraries
- LivePhish.RequestSender - WinForms test application to send requests to url
- LivePhish.Test - unit tests for apple and google wrappers
- LivePhish.TestSite - test site to process client's requests
- LivePhish.Wrapper - Apple and Google wrappers and helper classes
  * ISubscriptionClient - common interface for subscription wrappers
  * IHttpClient - interface for communication via http requests with Apple/Google services
  * AppleSubscriptionClient - ISubscriptionClient implementation for Apple
  * GoogleSubscriptionClient - ISubscriptionClient implementation for Google
