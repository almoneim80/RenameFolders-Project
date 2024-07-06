namespace RenameFolders
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BrowesBTN = new System.Windows.Forms.Button();
            this.FolderNameLBL = new System.Windows.Forms.Label();
            this.RunBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.StatusLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BrowesBTN
            // 
            this.BrowesBTN.Location = new System.Drawing.Point(78, 144);
            this.BrowesBTN.Name = "BrowesBTN";
            this.BrowesBTN.Size = new System.Drawing.Size(100, 35);
            this.BrowesBTN.TabIndex = 0;
            this.BrowesBTN.Text = "Browes";
            this.BrowesBTN.UseVisualStyleBackColor = true;
            this.BrowesBTN.Click += new System.EventHandler(this.BrowesBTN_Click);
            // 
            // FolderNameLBL
            // 
            this.FolderNameLBL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FolderNameLBL.Location = new System.Drawing.Point(184, 144);
            this.FolderNameLBL.Name = "FolderNameLBL";
            this.FolderNameLBL.Size = new System.Drawing.Size(293, 35);
            this.FolderNameLBL.TabIndex = 1;
            this.FolderNameLBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RunBTN
            // 
            this.RunBTN.Location = new System.Drawing.Point(377, 229);
            this.RunBTN.Name = "RunBTN";
            this.RunBTN.Size = new System.Drawing.Size(100, 35);
            this.RunBTN.TabIndex = 2;
            this.RunBTN.Text = "Run";
            this.RunBTN.UseVisualStyleBackColor = true;
            this.RunBTN.Click += new System.EventHandler(this.RunBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Location = new System.Drawing.Point(271, 229);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(100, 35);
            this.CancelBTN.TabIndex = 3;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // StatusLBL
            // 
            this.StatusLBL.AutoSize = true;
            this.StatusLBL.Location = new System.Drawing.Point(96, 347);
            this.StatusLBL.Name = "StatusLBL";
            this.StatusLBL.Size = new System.Drawing.Size(0, 15);
            this.StatusLBL.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.StatusLBL);
            this.Controls.Add(this.CancelBTN);
            this.Controls.Add(this.RunBTN);
            this.Controls.Add(this.FolderNameLBL);
            this.Controls.Add(this.BrowesBTN);
            this.Name = "Form1";
            this.Text = "Rename Folders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BrowesBTN;
        private Label FolderNameLBL;
        private Button RunBTN;
        private Button CancelBTN;
        private Label StatusLBL;
    }
}