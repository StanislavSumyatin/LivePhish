using System;
using System.IO;
using System.Text;

namespace LivePhish.Wrapper.Utils
{
	public static class Helper
	{
		public static string GetBase64(string value)
		{
			var bytes = Encoding.UTF8.GetBytes(value);
			var base64 = Convert.ToBase64String(bytes);
			return base64;
		}

	    public static string GetPlainFromBase64(string value)
	    {
            var data = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(data);
	    }

		public static string ReadStream(Stream stream)
		{
			using (var streamReader = new StreamReader(stream))
			{
				return streamReader.ReadToEnd().Trim();
			}
		}
	}
}
