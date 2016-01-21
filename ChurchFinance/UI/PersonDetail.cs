using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class PersonDetail : UserControl
    {

        #region 변수 부분



        #endregion

        // 기타 변수
        private DateTime date;

        private String personName;

        public PersonDetail()
        {
            InitializeComponent();


            date = DateTime.Now;
            personName = "이길복";

            setView();

            Paint += PersonDetail_Paint;
        }

        #region 각종 컨트롤 설정 (생성자 부분)

        /// <summary>
        /// 각종 라벨과 데이터뷰를 설정합니다.
        /// </summary>
        private void setView()
        {
            // 제목 부분
            title.Text = date.Year + "년도 헌금 집계";
            title.Font = new Font("Tahoma", 20f);

            PersonLabel.Text = personName;
            PersonLabel.Font = new Font("Tahoma", 18f);

            // 데이터뷰 설정
            setDataView();
            // 항목입력
            InputItem();
        }

        /// <summary>
        /// 왼쪽 항목을 입력합니다.
        /// </summary>
        private void InputItem()
        {
            detailView.Rows[0].Cells[0].Value = "감사헌금";
            detailView.Rows[1].Cells[0].Value = "십일조";
            detailView.Rows[2].Cells[0].Value = "구역헌금";
            detailView.Rows[3].Cells[0].Value = "건축헌금";
            detailView.Rows[4].Cells[0].Value = "선교헌금";
            detailView.Rows[5].Cells[0].Value = "성미헌금";
            detailView.Rows[6].Cells[0].Value = "구제헌금";
            detailView.Rows[7].Cells[0].Value = "차량헌금";
            detailView.Rows[8].Cells[0].Value = "절기헌금";
            detailView.Rows[9].Cells[0].Value = "기타수입";
            detailView.Rows[10].Cells[0].Value = "이자수입";
        }

        /// <summary>
        /// 데이터뷰 셜정
        /// </summary>
        private void setDataView()
        {

            // 왼쪽 데이터뷰 설정
            detailView.Size = new Size(300, 382);
            detailView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            detailView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            detailView.ColumnHeadersHeight = 30;
            detailView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            detailView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            detailView.Font = new Font("Microsoft Sans Serif", 12);
            detailView.RowTemplate.Height = 30;
            detailView.ColumnCount = 2;
            detailView.ReadOnly = true;
            detailView.AllowUserToAddRows = false;
            detailView.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            detailView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            detailView.Columns[0].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            detailView.Columns[0].Name = "항 목";
            detailView.Columns[1].Name = "금 액";

            for (int i = 0; i < detailView.Columns.Count; i++)
                detailView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            detailView.RowCount = 11;


            // 합계 데이타뷰 설정
            detailTotal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            detailTotal.ColumnHeadersHeight = 30;
            detailTotal.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            detailTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            detailTotal.Font = new Font("Microsoft Sans Serif", 12);
            detailTotal.RowTemplate.Height = 30;
            detailTotal.ColumnHeadersVisible = false;
            detailTotal.ColumnCount = 2;
            detailTotal.ReadOnly = true;
            detailTotal.RowCount = 2;
            detailTotal.AllowUserToAddRows = false;
            detailTotal.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            detailTotal.RowHeadersDefaultCellStyle.Padding = new Padding(detailTotal.RowHeadersWidth);
            detailTotal.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            detailTotal.Columns[0].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            detailTotal.Rows[0].Cells[0].Value = "Total";
            detailTotal.ClearSelection();

            for (int i = 0; i < detailTotal.Columns.Count; i++)
                detailTotal.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            // 사람 검색 데이터뷰 설정
            peopleView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            peopleView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            peopleView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            peopleView.ColumnHeadersHeight = 30;
            peopleView.Font = new Font("Microsoft Sans Serif", 12);
            peopleView.RowTemplate.Height = 30;
            peopleView.AllowUserToAddRows = false;
            peopleView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;


            // 사람 검색 합계 뷰 설정
            peopleTotal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            peopleTotal.ColumnHeadersHeight = 30;
            peopleTotal.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            peopleTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            peopleTotal.Font = new Font("Microsoft Sans Serif", 12);
            peopleTotal.RowTemplate.Height = 30;
            peopleTotal.ColumnHeadersVisible = false;
            peopleTotal.ColumnCount = 3;
            peopleTotal.ReadOnly = true;
            peopleTotal.RowCount = 2;
            peopleTotal.AllowUserToAddRows = false;
            peopleTotal.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            peopleTotal.RowHeadersDefaultCellStyle.Padding = new Padding(detailTotal.RowHeadersWidth);
            peopleTotal.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            peopleTotal.Columns[0].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            peopleTotal.Rows[0].Cells[0].Value = "Total";
            peopleTotal.ClearSelection();

            for (int i = 0; i < detailTotal.Columns.Count; i++)
                peopleTotal.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        #endregion

        #region Paint 부분

        /// <summary>
        /// Paint 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PersonDetail_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion
    }
}
