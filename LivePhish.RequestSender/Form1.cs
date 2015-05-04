using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace LivePhish.RequestSender
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var webClient = new WebClient();
			var response = webClient.UploadData(TextUrl.Text,
				Encoding.UTF8.GetBytes(TextRequest.Text.Trim()));
			TextResponse.Text = Encoding.UTF8.GetString(response);
		}
	}
}
