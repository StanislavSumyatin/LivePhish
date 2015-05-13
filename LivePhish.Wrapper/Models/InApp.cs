using System;
using System.Collections.Generic;
using System.Text;

namespace LivePhish.Wrapper.Models
{
	public class InApp
	{
		// ReSharper disable InconsistentNaming
		public string quantity { get; set; }
		public string product_id { get; set; }
		public string transaction_id { get; set; }
		public string original_transaction_id { get; set; }
		public string purchase_date { get; set; }
		public string purchase_date_ms { get; set; }
		public string purchase_date_pst { get; set; }
		public string original_purchase_date { get; set; }
		public string original_purchase_date_ms { get; set; }
		public string original_purchase_date_pst { get; set; }
		public string expires_date { get; set; }
		public string expires_date_ms { get; set; }
		public string expires_date_pst { get; set; }
		public string web_order_line_item_id { get; set; }
		public string is_trial_period { get; set; }
	}
}
