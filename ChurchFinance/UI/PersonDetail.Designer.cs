namespace UI
{
    partial class PersonDetail
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
            this.detailView = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.Label();
            this.PersonLabel = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.detailTotal = new System.Windows.Forms.DataGridView();
            this.peopleView = new System.Windows.Forms.DataGridView();
            this.peopleTotal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // detailView
            // 
            this.detailView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailView.Location = new System.Drawing.Point(89, 117);
            this.detailView.Name = "detailView";
            this.detailView.RowTemplate.Height = 23;
            this.detailView.Size = new System.Drawing.Size(300, 382);
            this.detailView.TabIndex = 0;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(290, 27);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(38, 12);
            this.title.TabIndex = 1;
            this.title.Text = "label1";
            // 
            // PersonLabel
            // 
            this.PersonLabel.AutoSize = true;
            this.PersonLabel.Location = new System.Drawing.Point(495, 66);
            this.PersonLabel.Name = "PersonLabel";
            this.PersonLabel.Size = new System.Drawing.Size(38, 12);
            this.PersonLabel.TabIndex = 2;
            this.PersonLabel.Text = "label2";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(714, 70);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(144, 21);
            this.searchBox.TabIndex = 4;
            // 
            // detailTotal
            // 
            this.detailTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailTotal.Location = new System.Drawing.Point(89, 519);
            this.detailTotal.Name = "detailTotal";
            this.detailTotal.RowTemplate.Height = 23;
            this.detailTotal.Size = new System.Drawing.Size(300, 31);
            this.detailTotal.TabIndex = 5;
            // 
            // peopleView
            // 
            this.peopleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.peopleView.Location = new System.Drawing.Point(420, 117);
            this.peopleView.Name = "peopleView";
            this.peopleView.RowTemplate.Height = 23;
            this.peopleView.Size = new System.Drawing.Size(438, 382);
            this.peopleView.TabIndex = 6;
            // 
            // peopleTotal
            // 
            this.peopleTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.peopleTotal.Location = new System.Drawing.Point(420, 519);
            this.peopleTotal.Name = "peopleTotal";
            this.peopleTotal.RowTemplate.Height = 23;
            this.peopleTotal.Size = new System.Drawing.Size(438, 31);
            this.peopleTotal.TabIndex = 7;
            // 
            // PersonDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.peopleTotal);
            this.Controls.Add(this.peopleView);
            this.Controls.Add(this.detailTotal);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.PersonLabel);
            this.Controls.Add(this.title);
            this.Controls.Add(this.detailView);
            this.Name = "PersonDetail";
            this.Size = new System.Drawing.Size(973, 631);
            ((System.ComponentModel.ISupportInitialize)(this.detailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView detailView;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label PersonLabel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.DataGridView detailTotal;
        private System.Windows.Forms.DataGridView peopleView;
        private System.Windows.Forms.DataGridView peopleTotal;
    }
}
