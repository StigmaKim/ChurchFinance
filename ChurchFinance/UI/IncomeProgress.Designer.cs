namespace UI
{
    partial class IncomeProgress
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
            this.budgetView = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.Label();
            this.progressView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.etcView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.budgetView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.etcView)).BeginInit();
            this.SuspendLayout();
            // 
            // budgetView
            // 
            this.budgetView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.budgetView.Location = new System.Drawing.Point(19, 99);
            this.budgetView.Name = "budgetView";
            this.budgetView.RowTemplate.Height = 23;
            this.budgetView.Size = new System.Drawing.Size(426, 206);
            this.budgetView.TabIndex = 0;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Tahoma", 15F);
            this.title.Location = new System.Drawing.Point(56, 16);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(64, 24);
            this.title.TabIndex = 1;
            this.title.Text = "label1";
            // 
            // progressView
            // 
            this.progressView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.progressView.Location = new System.Drawing.Point(475, 99);
            this.progressView.Name = "progressView";
            this.progressView.RowTemplate.Height = 23;
            this.progressView.Size = new System.Drawing.Size(451, 206);
            this.progressView.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(203, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "예 산";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(681, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "수 입";
            // 
            // etcView
            // 
            this.etcView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.etcView.Location = new System.Drawing.Point(627, 357);
            this.etcView.Name = "etcView";
            this.etcView.RowTemplate.Height = 23;
            this.etcView.Size = new System.Drawing.Size(298, 49);
            this.etcView.TabIndex = 5;
            // 
            // IncomeProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.etcView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressView);
            this.Controls.Add(this.title);
            this.Controls.Add(this.budgetView);
            this.Name = "IncomeProgress";
            this.Size = new System.Drawing.Size(1048, 555);
            ((System.ComponentModel.ISupportInitialize)(this.budgetView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.etcView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView budgetView;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.DataGridView progressView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView etcView;
    }
}
