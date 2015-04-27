namespace LivePhish.Wrapper.Models
{
	public class ReceiptResponse
	{
	    // ReSharper disable InconsistentNaming
		public int status { get; set; }
		public Receipt receipt { get; set; }
        public string exception { get; set; }
	}
}
