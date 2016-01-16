namespace UI
{
    partial class TestForm
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
            this.neoTabWindow1 = new NeoTabControlLibrary.NeoTabWindow();
            this.neoTabPage1 = new NeoTabControlLibrary.NeoTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).BeginInit();
            this.neoTabWindow1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neoTabWindow1
            // 
            this.neoTabWindow1.Controls.Add(this.neoTabPage1);
            this.neoTabWindow1.Location = new System.Drawing.Point(12, 12);
            this.neoTabWindow1.Name = "neoTabWindow1";
            this.neoTabWindow1.RendererName = null;
            this.neoTabWindow1.SelectedIndex = 0;
            this.neoTabWindow1.Size = new System.Drawing.Size(729, 602);
            this.neoTabWindow1.TabIndex = 0;
            // 
            // neoTabPage1
            // 
            this.neoTabPage1.BackColor = System.Drawing.Color.Transparent;
            this.neoTabPage1.Name = "neoTabPage1";
            this.neoTabPage1.Text = "neoTabPage1";
            this.neoTabPage1.ToolTipText = "neoTabPage1";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(752, 626);
            this.Controls.Add(this.neoTabWindow1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).EndInit();
            this.neoTabWindow1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NeoTabControlLibrary.NeoTabWindow neoTabWindow1;
        private NeoTabControlLibrary.NeoTabPage neoTabPage1;
    }
}