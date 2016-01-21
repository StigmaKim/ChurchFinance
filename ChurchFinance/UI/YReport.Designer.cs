namespace UI
{
    partial class YReport
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.income = new System.Windows.Forms.DataGridView();
            this.total = new System.Windows.Forms.DataGridView();
            this.NN = new System.Windows.Forms.TextBox();
            this.NNbtn = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.income)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.title.Location = new System.Drawing.Point(252, 18);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(70, 26);
            this.title.TabIndex = 0;
            this.title.Text = "label1";
            // 
            // income
            // 
            this.income.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.income.Location = new System.Drawing.Point(154, 70);
            this.income.Name = "income";
            this.income.RowTemplate.Height = 23;
            this.income.Size = new System.Drawing.Size(248, 299);
            this.income.TabIndex = 1;
            // 
            // total
            // 
            this.total.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.total.Location = new System.Drawing.Point(154, 375);
            this.total.Name = "total";
            this.total.RowTemplate.Height = 23;
            this.total.Size = new System.Drawing.Size(248, 29);
            this.total.TabIndex = 3;
            // 
            // NN
            // 
            this.NN.Location = new System.Drawing.Point(563, 18);
            this.NN.Name = "NN";
            this.NN.Size = new System.Drawing.Size(123, 21);
            this.NN.TabIndex = 5;
            // 
            // NNbtn
            // 
            this.NNbtn.Location = new System.Drawing.Point(610, 60);
            this.NNbtn.Name = "NNbtn";
            this.NNbtn.Size = new System.Drawing.Size(75, 23);
            this.NNbtn.TabIndex = 6;
            this.NNbtn.Text = "button1";
            this.NNbtn.UseVisualStyleBackColor = true;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(234, 47);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(100, 21);
            this.name.TabIndex = 7;
            // 
            // YReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.name);
            this.Controls.Add(this.NNbtn);
            this.Controls.Add(this.NN);
            this.Controls.Add(this.total);
            this.Controls.Add(this.income);
            this.Controls.Add(this.title);
            this.Name = "YReport";
            this.Size = new System.Drawing.Size(715, 461);
            ((System.ComponentModel.ISupportInitialize)(this.income)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.DataGridView income;
        private System.Windows.Forms.DataGridView total;
        private System.Windows.Forms.TextBox NN;
        private System.Windows.Forms.Button NNbtn;
        private System.Windows.Forms.TextBox name;
    }
}
