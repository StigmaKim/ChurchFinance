namespace UI
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.neoTabWindow1 = new NeoTabControlLibrary.NeoTabWindow();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.imgBtnContainer2 = new UI.ImgBtnContainer();
            this.imgBtnContainer1 = new UI.ImgBtnContainer();
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // neoTabWindow1
            // 
            this.neoTabWindow1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.neoTabWindow1.Location = new System.Drawing.Point(13, 177);
            this.neoTabWindow1.Name = "neoTabWindow1";
            this.neoTabWindow1.RendererName = null;
            this.neoTabWindow1.Size = new System.Drawing.Size(967, 552);
            this.neoTabWindow1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Location = new System.Drawing.Point(13, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 2);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, -49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(993, 2);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Location = new System.Drawing.Point(13, 127);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(993, 35);
            this.panel3.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Gulim", 11F);
            this.dateTimePicker1.Location = new System.Drawing.Point(750, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 24);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(13, 120);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(993, 2);
            this.panel5.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(13, 735);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 46);
            this.panel1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(843, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "인 쇄";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(843, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "저 장";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // imgBtnContainer2
            // 
            this.imgBtnContainer2.Location = new System.Drawing.Point(558, 13);
            this.imgBtnContainer2.Name = "imgBtnContainer2";
            this.imgBtnContainer2.Size = new System.Drawing.Size(420, 97);
            this.imgBtnContainer2.TabIndex = 9;
            // 
            // imgBtnContainer1
            // 
            this.imgBtnContainer1.BackColor = System.Drawing.Color.White;
            this.imgBtnContainer1.Location = new System.Drawing.Point(13, 13);
            this.imgBtnContainer1.Name = "imgBtnContainer1";
            this.imgBtnContainer1.Size = new System.Drawing.Size(539, 97);
            this.imgBtnContainer1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(990, 793);
            this.Controls.Add(this.imgBtnContainer2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.imgBtnContainer1);
            this.Controls.Add(this.neoTabWindow1);
            this.Name = "Form1";
            this.Text = "정산 프로그램";
            ((System.ComponentModel.ISupportInitialize)(this.neoTabWindow1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private NeoTabControlLibrary.NeoTabWindow neoTabWindow1;
        private ImgBtnContainer imgBtnContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.Button button2;
        private ImgBtnContainer imgBtnContainer2;
    }
}

