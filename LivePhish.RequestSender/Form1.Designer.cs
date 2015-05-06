namespace LivePhish.RequestSender
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.TextRequest = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.TextResponse = new System.Windows.Forms.TextBox();
			this.TextUrl = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(664, 306);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Send";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// TextRequest
			// 
			this.TextRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextRequest.Location = new System.Drawing.Point(64, 38);
			this.TextRequest.Multiline = true;
			this.TextRequest.Name = "TextRequest";
			this.TextRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextRequest.Size = new System.Drawing.Size(802, 262);
			this.TextRequest.TabIndex = 2;
			this.TextRequest.Text = resources.GetString("TextRequest.Text");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "URL:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Request:";
			// 
			// TextResponse
			// 
			this.TextResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextResponse.Location = new System.Drawing.Point(69, 335);
			this.TextResponse.Multiline = true;
			this.TextResponse.Name = "TextResponse";
			this.TextResponse.ReadOnly = true;
			this.TextResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TextResponse.Size = new System.Drawing.Size(802, 262);
			this.TextResponse.TabIndex = 5;
			// 
			// TextUrl
			// 
			this.TextUrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TextUrl.FormattingEnabled = true;
			this.TextUrl.Items.AddRange(new object[] {
            "http://localhost:4751/AppleSubscriptionInfo.aspx",
            "http://phish.provectus-it.com/AppleSubscriptionInfo.aspx"});
			this.TextUrl.Location = new System.Drawing.Point(64, 12);
			this.TextUrl.Name = "TextUrl";
			this.TextUrl.Size = new System.Drawing.Size(802, 21);
			this.TextUrl.TabIndex = 6;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(883, 609);
			this.Controls.Add(this.TextUrl);
			this.Controls.Add(this.TextResponse);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TextRequest);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox TextRequest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TextResponse;
		private System.Windows.Forms.ComboBox TextUrl;
	}
}

