using System;
using System.Text;

namespace LivePhish.Wrapper.Utils
{
	internal static class Helper
	{
		public static string GetBase64(string value)
		{
			var bytes = Encoding.UTF8.GetBytes(value);
			var base64 = Convert.ToBase64String(bytes);
			return base64;
		}
	}
}
