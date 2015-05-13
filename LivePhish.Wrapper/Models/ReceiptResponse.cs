using System.Collections.Generic;
namespace LivePhish.Wrapper.Models
{
	public class ReceiptResponse
	{
	    // ReSharper disable InconsistentNaming
		public int status { get; set; }
		public Receipt receipt { get; set; }
        public string exception { get; set; }
		public string environment { get; set; }
		public List<Receipt> latest_receipt_info { get; set; }
		public string latest_receipt { get; set; }
	}
}
