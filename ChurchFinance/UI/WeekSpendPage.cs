using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeoTabControlLibrary;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Data;

namespace UI
{
    class WeekSpendPage
    {
        NeoTabPage W_SpendTab = null;

        DataGridView spend = null;
        DataGridView spend_total = null;
        DataGridView _spend_total = null;

        DataGridView _spend_Worship = null;
        DataGridView _spend_Mission = null;
        DataGridView _spend_Edu = null;
        DataGridView _spend_Human = null;
        DataGridView _spend_Vol = null;
        DataGridView _spend_Main = null;
        DataGridView _spend_Loan = null;
        DataGridView _spend_Res = null;

        int Sum_Worship = 0;
        int Sum_Mission = 0;
        int Sum_Edu = 0;
        int Sum_Human = 0;
        int Sum_Vol = 0;
        int Sum_Main = 0;
        int Sum_Loan = 0;
        int Sum_Res = 0;
        
        Control currentTab = null;
        DateTimePicker dateTimePicker1 = null;
        Button button1 = null;
        
        // DB 관련 
        SQLite SQLite = null;
        SQLiteCommand cmd = null;

        // 생성자
        public WeekSpendPage(NeoTabPage Tab, DateTimePicker dtp)
        {
            W_SpendTab = Tab;

            SQLite = new SQLite(); // DB Object
            cmd = SQLite.GetSQLCommand(); // Command Object

            dateTimePicker1 = dtp;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }

        public void ButtonEvent()
        {
            SQLite.Execute(string.Format("Delete From Spending_Worship where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
            SQLite.Execute(string.Format("Delete From Spending_Mission where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
            SQLite.Execute(string.Format("Delete From Spending_Edu where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
            SQLite.Execute(string.Format("Delete From Spending_Human where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
            SQLite.Execute(string.Format("Delete From Spending_Vol where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
            SQLite.Execute(string.Format("Delete From Spending_Main where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
            SQLite.Execute(string.Format("Delete From Spending_Loan where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
            SQLite.Execute(string.Format("Delete From Spending_Res where date = '{0}'", ((DateTime)dateTimePicker1.Value).ToShortDateString()));

            for (int i = 0; i < _spend_Worship.RowCount - 1; i++)
                SQLite.Execute(string.Format("insert into Spending_Worship (name, amount, date) values('{0}', {1}, '{2}')", _spend_Worship.Rows[i].Cells[0].Value, _spend_Worship.Rows[i].Cells[1].Value, ((DateTime)_spend_Worship.Rows[i].Cells[2].Value).ToShortDateString()));
            for (int i = 0; i < _spend_Mission.RowCount - 1; i++)
                SQLite.Execute(string.Format("insert into Spending_Mission (name, amount, date) values('{0}', {1}, '{2}')", _spend_Mission.Rows[i].Cells[0].Value, _spend_Mission.Rows[i].Cells[1].Value, ((DateTime)_spend_Mission.Rows[i].Cells[2].Value).ToShortDateString()));
            for (int i = 0; i < _spend_Edu.RowCount - 1; i++)
                SQLite.Execute(string.Format("insert into Spending_Edu (name, amount, date) values('{0}', {1}, '{2}')", _spend_Edu.Rows[i].Cells[0].Value, _spend_Edu.Rows[i].Cells[1].Value, ((DateTime)_spend_Edu.Rows[i].Cells[2].Value).ToShortDateString()));
            for (int i = 0; i < _spend_Human.RowCount - 1; i++)
                SQLite.Execute(string.Format("insert into Spending_Human (name, amount, date) values('{0}', {1}, '{2}')", _spend_Human.Rows[i].Cells[0].Value, _spend_Human.Rows[i].Cells[1].Value, ((DateTime)_spend_Human.Rows[i].Cells[2].Value).ToShortDateString()));
            for (int i = 0; i < _spend_Vol.RowCount - 1; i++)
                SQLite.Execute(string.Format("insert into Spending_Vol (name, amount, date) values('{0}', {1}, '{2}')", _spend_Vol.Rows[i].Cells[0].Value, _spend_Vol.Rows[i].Cells[1].Value, ((DateTime)_spend_Vol.Rows[i].Cells[2].Value).ToShortDateString()));
            for (int i = 0; i < _spend_Main.RowCount - 1; i++)
                SQLite.Execute(string.Format("insert into Spending_Main (name, amount, date) values('{0}', {1}, '{2}')", _spend_Main.Rows[i].Cells[0].Value, _spend_Main.Rows[i].Cells[1].Value, ((DateTime)_spend_Main.Rows[i].Cells[2].Value).ToShortDateString()));
            for (int i = 0; i < _spend_Loan.RowCount - 1; i++)
                SQLite.Execute(string.Format("insert into Spending_Loan (name, amount, date) values('{0}', {1}, '{2}')", _spend_Loan.Rows[i].Cells[0].Value, _spend_Loan.Rows[i].Cells[1].Value, ((DateTime)_spend_Loan.Rows[i].Cells[2].Value).ToShortDateString()));
            for (int i = 0; i < _spend_Res.RowCount - 1; i++)
                SQLite.Execute(string.Format("insert into Spending_Res (name, amount, date) values('{0}', {1}, '{2}')", _spend_Res.Rows[i].Cells[0].Value, _spend_Res.Rows[i].Cells[1].Value, ((DateTime)_spend_Res.Rows[i].Cells[2].Value).ToShortDateString()));
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            W_SpendTab.Controls.Add(_spend_Worship);
            W_SpendTab.Controls.Add(_spend_Mission);
            W_SpendTab.Controls.Add(_spend_Edu);
            W_SpendTab.Controls.Add(_spend_Human);
            W_SpendTab.Controls.Add(_spend_Vol);
            W_SpendTab.Controls.Add(_spend_Main);
            W_SpendTab.Controls.Add(_spend_Loan);
            W_SpendTab.Controls.Add(_spend_Res);

            // 날짜변화시
            SetWorshipDGV(2);
            SetMissionDGV(2);
            SetEduDGV(2);
            SetHumanDGV(2);
            SetVolDGV(2);
            SetMainDGV(2);
            SetLoanDGV(2);
            SetResDGV(2);

            W_SpendTab.Controls.Remove(_spend_Worship);
            W_SpendTab.Controls.Remove(_spend_Mission);
            W_SpendTab.Controls.Remove(_spend_Edu);
            W_SpendTab.Controls.Remove(_spend_Human);
            W_SpendTab.Controls.Remove(_spend_Vol);
            W_SpendTab.Controls.Remove(_spend_Main);
            W_SpendTab.Controls.Remove(_spend_Loan);
            W_SpendTab.Controls.Remove(_spend_Res);

            SetInputSumDGV();

            W_SpendTab.Controls.Add(_spend_Worship);
            currentTab = _spend_Worship;
        }
        
        public void WeekSpendPageStart()
        {
            // spend Area
            AddGridView();
            CreateTable();

            // 최초 DGV 그리기.
            SetWorshipDGV(1);
            SetMissionDGV(1);
            SetEduDGV(1);
            SetHumanDGV(1);
            SetVolDGV(1);
            SetMainDGV(1);
            SetLoanDGV(1);
            SetResDGV(1);

            W_SpendTab.Controls.Remove(_spend_Worship);
            W_SpendTab.Controls.Remove(_spend_Mission);
            W_SpendTab.Controls.Remove(_spend_Edu);
            W_SpendTab.Controls.Remove(_spend_Human);
            W_SpendTab.Controls.Remove(_spend_Vol);
            W_SpendTab.Controls.Remove(_spend_Main);
            W_SpendTab.Controls.Remove(_spend_Loan);
            W_SpendTab.Controls.Remove(_spend_Res);

            SetInputSumDGV(); // 최초 DGV 그리기. ( 수입 SUM )
            W_SpendTab.Controls.Add(_spend_Worship);
            currentTab = _spend_Worship;
        }

        private void AddGridView()
        {
            #region 수입 탭 GridView 선언

            spend = new DataGridView();
            spend_total = new DataGridView();
            _spend_total = new DataGridView();

            _spend_Worship = new DataGridView();
            _spend_Mission = new DataGridView();
            _spend_Edu = new DataGridView();
            _spend_Human = new DataGridView();
            _spend_Vol = new DataGridView();
            _spend_Main = new DataGridView();
            _spend_Loan = new DataGridView();
            _spend_Res = new DataGridView();


            _spend_Worship.CellEndEdit += _spend_Worship_CellEndEdit;
            _spend_Mission.CellEndEdit += _spend_Mission_CellEndEdit;
            _spend_Edu.CellEndEdit += _spend_Edu_CellEndEdit;
            _spend_Human.CellEndEdit += _spend_Human_CellEndEdit;
            _spend_Vol.CellEndEdit += _spend_Vol_CellEndEdit;
            _spend_Main.CellEndEdit += _spend_Main_CellEndEdit;
            _spend_Loan.CellEndEdit += _spend_Loan_CellEndEdit;
            _spend_Res.CellEndEdit += _spend_Res_CellEndEdit;

            spend.CellMouseDown += Spend_CellMouseDown;


            #endregion

            #region DGV 옵션 1
            // spend ---------------------------------------
            spend.Size = new Size(300, 400);
            spend.Location = new Point(20, 20);
            spend.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend.ColumnCount = 2;
            spend.ReadOnly = true;

            spend.Columns[0].Name = "수 입";
            spend.Columns[1].Name = "금 액";

            //String[] rows = { "십일조", "4,300,200원" };
            //spend.Rows.Add(rows);

            for (int i = 0; i < spend.Columns.Count; i++)
            {
                spend.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            /*
            for(int i = 0;i < 20; i++)
            {
                String[] row = { " ", " " };
                spend.Rows.Add(row);
            }
            */

            // spend_total ------------------------------
            spend_total.Size = new Size(300, 26);
            spend_total.Location = new Point(20, 425);
            spend_total.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            spend_total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            spend_total.ColumnHeadersVisible = false;
            spend_total.ColumnCount = 2;
            spend_total.ReadOnly = true;

            spend_total.Rows[0].Cells[0].Value = "Total";

            for (int i = 0; i < spend_total.Columns.Count; i++)
            {
                spend_total.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // _spend_total -------------------------------
            _spend_total.Size = new Size(600, 26);
            _spend_total.Location = new Point(350, 425);
            _spend_total.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_total.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _spend_total.ColumnHeadersVisible = false;
            _spend_total.ColumnCount = 3;
            _spend_total.ReadOnly = true;

            _spend_total.Rows[0].Cells[0].Value = "Total";
            _spend_total.Rows[0].Cells[1].Value = "";
            _spend_total.Rows[0].Cells[2].Value = "";

            for (int i = 0; i < _spend_total.Columns.Count; i++)
            {
                _spend_total.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            #endregion


            #region DGV 옵션 2

            // _spend_Worship ----------------------------------
            _spend_Worship.Size = new Size(600, 400);
            _spend_Worship.Location = new Point(350, 20);
            _spend_Worship.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_Worship.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _spend_Mission ----------------------------------
            _spend_Mission.Size = new Size(600, 400);
            _spend_Mission.Location = new Point(350, 20);
            _spend_Mission.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_Mission.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _spend_Edu ----------------------------------
            _spend_Edu.Size = new Size(600, 400);
            _spend_Edu.Location = new Point(350, 20);
            _spend_Edu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_Edu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _spend_Human ----------------------------------
            _spend_Human.Size = new Size(600, 400);
            _spend_Human.Location = new Point(350, 20);
            _spend_Human.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_Human.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _spend_Vol ----------------------------------
            _spend_Vol.Size = new Size(600, 400);
            _spend_Vol.Location = new Point(350, 20);
            _spend_Vol.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_Vol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _spend_Main ----------------------------------
            _spend_Main.Size = new Size(600, 400);
            _spend_Main.Location = new Point(350, 20);
            _spend_Main.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_Main.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _spend_Loan ----------------------------------
            _spend_Loan.Size = new Size(600, 400);
            _spend_Loan.Location = new Point(350, 20);
            _spend_Loan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_Loan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // _spend_Res ----------------------------------
            _spend_Res.Size = new Size(600, 400);
            _spend_Res.Location = new Point(350, 20);
            _spend_Res.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _spend_Res.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            #endregion

            // Draw DGVS --------------------------------------------------

            W_SpendTab.Controls.Add(spend);

            W_SpendTab.Controls.Add(_spend_Worship);
            W_SpendTab.Controls.Add(_spend_Mission);
            W_SpendTab.Controls.Add(_spend_Edu);
            W_SpendTab.Controls.Add(_spend_Human);
            W_SpendTab.Controls.Add(_spend_Vol);
            W_SpendTab.Controls.Add(_spend_Main);
            W_SpendTab.Controls.Add(_spend_Loan);
            W_SpendTab.Controls.Add(_spend_Res);

            W_SpendTab.Controls.Add(spend_total);
            W_SpendTab.Controls.Add(_spend_total);

        }

        #region 이벤트
        private void Spend_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            Debug.WriteLine("Rows : " + e.RowIndex);
            W_SpendTab.Controls.Remove(currentTab);

            switch (e.RowIndex)
            {
                case 0:
                    W_SpendTab.Controls.Add(_spend_Worship);
                    _spend_total.Rows[0].Cells[1].Value = Sum_Worship;
                    currentTab = _spend_Worship;
                    break;
                case 1:
                    W_SpendTab.Controls.Add(_spend_Mission);
                    _spend_total.Rows[0].Cells[1].Value = Sum_Mission;
                    currentTab = _spend_Mission;
                    break;
                case 2:
                    W_SpendTab.Controls.Add(_spend_Edu);
                    _spend_total.Rows[0].Cells[1].Value = Sum_Edu;
                    currentTab = _spend_Edu;
                    break;
                case 3:
                    W_SpendTab.Controls.Add(_spend_Human);
                    _spend_total.Rows[0].Cells[1].Value = Sum_Human;
                    currentTab = _spend_Human;
                    break;
                case 4:
                    W_SpendTab.Controls.Add(_spend_Vol);
                    _spend_total.Rows[0].Cells[1].Value = Sum_Vol;
                    currentTab = _spend_Vol;
                    break;
                case 5:
                    W_SpendTab.Controls.Add(_spend_Main);
                    _spend_total.Rows[0].Cells[1].Value = Sum_Main;
                    currentTab = _spend_Main;
                    break;
                case 6:
                    W_SpendTab.Controls.Add(_spend_Loan);
                    _spend_total.Rows[0].Cells[1].Value = Sum_Loan;
                    currentTab = _spend_Loan;
                    break;
                case 7:
                    W_SpendTab.Controls.Add(_spend_Res);
                    _spend_total.Rows[0].Cells[1].Value = Sum_Res;
                    currentTab = _spend_Res;
                    break;
            }
        }

        private void _spend_Res_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_spend_Res.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _spend_Res.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _spend_Res.RowCount - 1; i++)
            {
                if (_spend_Res.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_spend_Res.Rows[i].Cells[1].Value);
            }
            Sum_Res = sum;
            _spend_total.Rows[0].Cells[1].Value = Sum_Res;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _spend_Loan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_spend_Loan.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _spend_Loan.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _spend_Loan.RowCount - 1; i++)
            {
                if (_spend_Loan.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_spend_Loan.Rows[i].Cells[1].Value);
            }
            Sum_Loan = sum;
            _spend_total.Rows[0].Cells[1].Value = Sum_Loan;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _spend_Main_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_spend_Main.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _spend_Main.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _spend_Main.RowCount - 1; i++)
            {
                if (_spend_Main.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_spend_Main.Rows[i].Cells[1].Value);
            }
            Sum_Main = sum;
            _spend_total.Rows[0].Cells[1].Value = Sum_Main;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _spend_Vol_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_spend_Vol.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _spend_Vol.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _spend_Vol.RowCount - 1; i++)
            {
                if (_spend_Vol.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_spend_Vol.Rows[i].Cells[1].Value);
            }
            Sum_Vol = sum;
            _spend_total.Rows[0].Cells[1].Value = Sum_Vol;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _spend_Human_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_spend_Human.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _spend_Human.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _spend_Human.RowCount - 1; i++)
            {
                if (_spend_Human.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_spend_Human.Rows[i].Cells[1].Value);
            }
            Sum_Human = sum;
            _spend_total.Rows[0].Cells[1].Value = Sum_Human;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _spend_Edu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_spend_Edu.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _spend_Edu.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _spend_Edu.RowCount - 1; i++)
            {
                if (_spend_Edu.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_spend_Edu.Rows[i].Cells[1].Value);
            }
            Sum_Edu = sum;
            _spend_total.Rows[0].Cells[1].Value = Sum_Edu;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _spend_Mission_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_spend_Mission.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _spend_Mission.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _spend_Mission.RowCount - 1; i++)
            {
                if (_spend_Mission.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_spend_Mission.Rows[i].Cells[1].Value);
            }
            Sum_Mission = sum;
            _spend_total.Rows[0].Cells[1].Value = Sum_Mission;

            SetInputSumDGV();
            SQLite.CloseDB();
        }

        private void _spend_Worship_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Set New Value`s Date
            if (_spend_Worship.Rows[e.RowIndex].Cells[2].Value.ToString() == "")
                _spend_Worship.Rows[e.RowIndex].Cells[2].Value = ((DateTime)dateTimePicker1.Value).ToShortDateString();

            // Set Sumation.
            int sum = 0;
            for (int i = 0; i < _spend_Worship.RowCount - 1; i++)
            {
                if (_spend_Worship.Rows[i].Cells[1].Value.ToString() != "")
                    sum += Convert.ToInt32(_spend_Worship.Rows[i].Cells[1].Value);
            }
            Sum_Worship = sum;
            _spend_total.Rows[0].Cells[1].Value = Sum_Worship;

            SetInputSumDGV();
            SQLite.CloseDB();
        }
        #endregion

        private void CreateTable()
        {
            SQLite.Execute(string.Format("create table Spending_Worship " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Spending_Mission " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Spending_Edu " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Spending_Human " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Spending_Vol " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Spending_Main " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Spending_Loan " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
            SQLite.Execute(string.Format("create table Spending_Res " +
                "(no Integer primary key autoincrement, date datetime, name varchar(40), amount Integer)"));
        }

        #region SETDGV
        private void SetWorshipDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Worship where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _spend_Worship.DataSource = ds.Tables[0];
                    if ( ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Worship (name, date, amount) values ('{0}', '{1}', {2})", "강단꽃꽃이", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Worship (name, date, amount) values ('{0}', '{1}', {2})", "성가대운영비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Worship (name, date, amount) values ('{0}', '{1}', {2})", "주보대", DateTime.Now.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Worship where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                        _spend_Worship.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Worship where date = '{0}' order by no asc", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                    _spend_Worship.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Worship (name, date, amount) values ('{0}', '{1}', {2})", "강단꽃꽃이", ((DateTime)dateTimePicker1.Value).ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Worship (name, date, amount) values ('{0}', '{1}', {2})", "성가대운영비", ((DateTime)dateTimePicker1.Value).ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Worship (name, date, amount) values ('{0}', '{1}', {2})", "주보대", ((DateTime)dateTimePicker1.Value).ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Worship where date = '{0}' order by no asc", ((DateTime)dateTimePicker1.Value).ToShortDateString()));
                        _spend_Worship.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }

                for (int i = 0; i < _spend_Worship.Columns.Count; i++)
                {
                    _spend_Worship.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _spend_Worship.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _spend.Rows[0].Cells[0].Value);
                    if (_spend_Worship.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        sum += Convert.ToInt32(_spend_Worship.Rows[i].Cells[1].Value);
                    }

                }

                Sum_Worship = sum;
                Debug.WriteLine("Sum Worship : " + Sum_Worship);
                _spend_total.Rows[0].Cells[1].Value = Sum_Worship;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        private void SetMissionDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Mission where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _spend_Mission.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Mission (name, date, amount) values ('{0}', '{1}', {2})", "선교비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Mission (name, date, amount) values ('{0}', '{1}', {2})", "심방비", DateTime.Now.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Mission where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                        _spend_Mission.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Mission where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _spend_Mission.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Mission (name, date, amount) values ('{0}', '{1}', {2})", "선교비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Mission (name, date, amount) values ('{0}', '{1}', {2})", "심방비", dateTimePicker1.Value.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Mission where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                        _spend_Mission.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }

                for (int i = 0; i < _spend_Mission.Columns.Count; i++)
                {
                    _spend_Mission.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _spend_Mission.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _spend.Rows[0].Cells[0].Value);
                    if (_spend_Mission.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_spend_Mission.Rows[i].Cells[1].Value);
                }
                Sum_Mission = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        private void SetEduDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Edu where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _spend_Edu.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "주일학교지원비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "학생부지원비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "청년부지원비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "장학금", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "도서비", DateTime.Now.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Edu where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                        _spend_Edu.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Edu where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _spend_Edu.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "주일학교지원비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "학생부지원비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "청년부지원비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "장학금", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Edu (name, date, amount) values ('{0}', '{1}', {2})", "도서비", dateTimePicker1.Value.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Edu where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                        _spend_Edu.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }

                for (int i = 0; i < _spend_Edu.Columns.Count; i++)
                {
                    _spend_Edu.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _spend_Edu.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _spend.Rows[0].Cells[0].Value);
                    if (_spend_Edu.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_spend_Edu.Rows[i].Cells[1].Value);
                }
                Sum_Edu = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        private void SetHumanDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Human where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _spend_Human.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Human (name, date, amount) values ('{0}', '{1}', {2})", "목사님사례비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Human (name, date, amount) values ('{0}', '{1}', {2})", "전도사님사례비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Human (name, date, amount) values ('{0}', '{1}', {2})", "상여금", DateTime.Now.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Human where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                        _spend_Human.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Human where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _spend_Human.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Human (name, date, amount) values ('{0}', '{1}', {2})", "목사님사례비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Human (name, date, amount) values ('{0}', '{1}', {2})", "전도사님사례비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Human (name, date, amount) values ('{0}', '{1}', {2})", "상여금", dateTimePicker1.Value.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Human where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                        _spend_Human.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }

                for (int i = 0; i < _spend_Human.Columns.Count; i++)
                {
                    _spend_Human.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _spend_Human.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _spend.Rows[0].Cells[0].Value);
                    if (_spend_Human.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_spend_Human.Rows[i].Cells[1].Value);
                }
                Sum_Human = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }

        private void SetVolDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Vol where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _spend_Vol.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Vol (name, date, amount) values ('{0}', '{1}', {2})", "경조비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Vol (name, date, amount) values ('{0}', '{1}', {2})", "구제비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Vol (name, date, amount) values ('{0}', '{1}', {2})", "행사비", DateTime.Now.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Vol where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                        _spend_Vol.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Vol where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _spend_Vol.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Vol (name, date, amount) values ('{0}', '{1}', {2})", "경조비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Vol (name, date, amount) values ('{0}', '{1}', {2})", "구제비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Vol (name, date, amount) values ('{0}', '{1}', {2})", "행사비", dateTimePicker1.Value.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Vol where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                        _spend_Vol.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }

                for (int i = 0; i < _spend_Vol.Columns.Count; i++)
                {
                    _spend_Vol.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _spend_Vol.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _spend.Rows[0].Cells[0].Value);
                    if (_spend_Vol.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_spend_Vol.Rows[i].Cells[1].Value);
                }
                Sum_Vol = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void SetMainDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Main where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _spend_Main.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "사택유지비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "교회관리비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "목회활동비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "수도광열비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "통신비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "차량관리비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "상회비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "교회비품비", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "기타지출", DateTime.Now.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Main where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                        _spend_Main.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Main where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _spend_Main.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "사택유지비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "교회관리비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "목회활동비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "수도광열비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "통신비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "차량관리비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "차량구입비적립", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "상회비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "교회비품비", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Main (name, date, amount) values ('{0}', '{1}', {2})", "기타지출", dateTimePicker1.Value.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Main where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                        _spend_Main.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }

                for (int i = 0; i < _spend_Main.Columns.Count; i++)
                {
                    _spend_Main.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _spend_Main.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _spend.Rows[0].Cells[0].Value);
                    if (_spend_Main.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_spend_Main.Rows[i].Cells[1].Value);
                }
                Sum_Main = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void SetLoanDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Loan where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _spend_Loan.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Loan (name, date, amount) values ('{0}', '{1}', {2})", "상환", DateTime.Now.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Loan (name, date, amount) values ('{0}', '{1}', {2})", "적립이자", DateTime.Now.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Loan where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                        _spend_Loan.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Loan where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _spend_Loan.DataSource = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        SQLite.Execute(string.Format("insert into Spending_Loan (name, date, amount) values ('{0}', '{1}', {2})", "상환", dateTimePicker1.Value.ToShortDateString(), 0));
                        SQLite.Execute(string.Format("insert into Spending_Loan (name, date, amount) values ('{0}', '{1}', {2})", "적립이자", dateTimePicker1.Value.ToShortDateString(), 0));

                        ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Loan where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                        _spend_Loan.DataSource = ds.Tables[0];
                    }
                    _spend_Worship.Columns[0].ReadOnly = true;
                }

                for (int i = 0; i < _spend_Loan.Columns.Count; i++)
                {
                    _spend_Loan.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _spend_Loan.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _spend.Rows[0].Cells[0].Value);
                    if (_spend_Loan.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_spend_Loan.Rows[i].Cells[1].Value);
                }
                Sum_Loan = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }

        private void SetResDGV(int check)
        {
            try
            {
                SQLite.ConnectToDB();

                if (check == 1)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Res where date = '{0}' order by no asc", DateTime.Now.ToShortDateString()));
                    _spend_Res.DataSource = ds.Tables[0];
                }
                else if (check == 2)
                {
                    DataSet ds = SQLite.ExecuteSelectQuery(string.Format("select name as '항 목', amount as '금 액', date as '날 짜' from Spending_Res where date = '{0}' order by no asc", dateTimePicker1.Value.ToShortDateString()));
                    _spend_Res.DataSource = ds.Tables[0];
                }

                for (int i = 0; i < _spend_Res.Columns.Count; i++)
                {
                    _spend_Res.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Set Sumation.
                int sum = 0;
                for (int i = 0; i < _spend_Res.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + _spend.Rows[0].Cells[0].Value);
                    if (_spend_Res.Rows[i].Cells[1].Value.ToString() != "")
                        sum += Convert.ToInt32(_spend_Res.Rows[i].Cells[1].Value);
                }
                Sum_Res = sum;

                SQLite.CloseDB();
            }
            catch (SQLiteException e)
            {
                SQLite.CloseDB();
                Debug.WriteLine(e);
            }
        }
        #endregion

        private void SetInputSumDGV()
        {
            try
            {
                spend.Rows.Clear();

                // 예배비
                String[] a = { "예배비", Sum_Worship.ToString() };
                spend.Rows.Add(a);

                // 선교비
                string[] b = { "선교비", Sum_Mission.ToString() };
                spend.Rows.Add(b);

                // 교육비
                string[] c = { "교육비", Sum_Edu.ToString() };
                spend.Rows.Add(c);

                // 인건비
                string[] d = { "인건비", Sum_Human.ToString() };
                spend.Rows.Add(d);

                // 봉사비
                string[] e = { "봉사비", Sum_Vol.ToString() };
                spend.Rows.Add(e);

                // 운영관리비
                string[] f = { "운영관리비", Sum_Main.ToString() };
                spend.Rows.Add(f);

                // 대출관련비
                string[] g = { "대출관련비", Sum_Loan.ToString() };
                spend.Rows.Add(g);

                // 예비비
                string[] h = { "예비비", Sum_Res.ToString() };
                spend.Rows.Add(h);

                // Total of Total
                int sumn = 0;
                for (int i = 0; i < spend.RowCount - 1; i++)
                {
                    //Debug.WriteLine("Cell 0 : " + spend.Rows[0].Cells[1].Value);
                    if (spend.Rows[i].Cells[1].Value.ToString() != "")
                        sumn += Convert.ToInt32(spend.Rows[i].Cells[1].Value);
                }

                spend_total.Rows[0].Cells[1].Value = sumn;
            }
            catch (SQLiteException e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
