using System.Collections.Generic;
namespace LivePhish.Wrapper.Models
{
	public class Receipt
	{
	    // ReSharper disable InconsistentNaming
		public string receipt_type { get; set; }
		public int adam_id { get; set; }
		public int app_item_id { get; set; }
		public string bundle_id { get; set; }
		public string application_version { get; set; }
		public int download_id { get; set; }
		public int version_external_identifier { get; set; }
		public string request_date { get; set; }
		public string request_date_ms { get; set; }
		public string request_date_pst { get; set; }
		public string original_purchase_date { get; set; }
		public string original_purchase_date_ms { get; set; }
		public string original_purchase_date_pst { get; set; }
		public string original_application_version { get; set; }
		public List<InApp> in_app { get; set; }
	}
}
