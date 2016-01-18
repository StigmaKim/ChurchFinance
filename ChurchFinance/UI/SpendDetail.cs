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

    public partial class SpendDetail : UserControl
    {
        #region 변수 선언

        /// <summary>
        /// 예산 예배비
        /// </summary>
        private Pray budgetPray;

        /// <summary>
        /// 선교비
        /// </summary>
        private Pray curPray;



        #region 예산 변수
        

        #endregion

        #endregion

        public SpendDetail()
        {
            InitializeComponent();
        }
    }

    #region 각 항목별 구조체

    /// <summary>
    /// 예배비
    /// </summary>
    public class Pray
    {
        #region 변수 선언

        /// <summary>
        /// 강단 꽃꽃이
        /// </summary>
        private int flower;
        /// <summary>
        /// 성가대 운영비
        /// </summary>
        private int singer;
        /// <summary>
        /// 주보대
        /// </summary>
        private int jubo;

        #endregion

        #region get / set

        public int Flower
        {
            get
            {
                return flower;
            }

            set
            {
                flower = value;
            }
        }

        public int Singer
        {
            get
            {
                return singer;
            }

            set
            {
                singer = value;
            }
        }

        public int Jubo
        {
            get
            {
                return jubo;
            }

            set
            {
                jubo = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// 선교비
    /// </summary>
    public class MissionWork
    {
        #region 변수 선언

        /// <summary>
        /// 선교비
        /// </summary>
        private int misson;
        /// <summary>
        /// 심방비
        /// </summary>
        private int visit;

        #endregion

        #region get / set

        public int Misson
        {
            get
            {
                return misson;
            }

            set
            {
                misson = value;
            }
        }

        public int Visit
        {
            get
            {
                return visit;
            }

            set
            {
                visit = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// 교육비
    /// </summary>
    public class Education
    {
        #region 변수 선언

        /// <summary>
        /// 주일학교 지원비
        /// </summary>
        private int weekSchool;
        /// <summary>
        /// 학생회 지원비
        /// </summary>
        private int student;
        /// <summary>
        /// 청년부 지원비
        /// </summary>
        private int youngMan;
        /// <summary>
        /// 장학금
        /// </summary>
        private int scholarShip;
        /// <summary>
        /// 도서비
        /// </summary>
        private int book;

        #endregion

        #region get / set 

        public int WeekSchool
        {
            get
            {
                return weekSchool;
            }

            set
            {
                weekSchool = value;
            }
        }

        public int Student
        {
            get
            {
                return student;
            }

            set
            {
                student = value;
            }
        }

        public int YoungMan
        {
            get
            {
                return youngMan;
            }

            set
            {
                youngMan = value;
            }
        }

        public int ScholarShip
        {
            get
            {
                return scholarShip;
            }

            set
            {
                scholarShip = value;
            }
        }

        public int Book
        {
            get
            {
                return book;
            }

            set
            {
                book = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// 인건비
    /// </summary>
    public class Person
    {
        #region 변수 선언

        /// <summary>
        /// 목사님 사례비
        /// </summary>
        private int priest;
        /// <summary>
        /// 전도사님 사례비
        /// </summary>
        private int missionary;
        /// <summary>
        /// 상여금
        /// </summary>
        private int bonus;

        #endregion

        #region get / set

        public int Priest
        {
            get
            {
                return priest;
            }

            set
            {
                priest = value;
            }
        }

        public int Missionary
        {
            get
            {
                return missionary;
            }

            set
            {
                missionary = value;
            }
        }

        public int Bonus
        {
            get
            {
                return bonus;
            }

            set
            {
                bonus = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// 봉사비
    /// </summary>
    public class service
    {
        #region 변수 선언

        /// <summary>
        /// 경조비
        /// </summary>
        private int gyeongJo;
        /// <summary>
        /// 구제비
        /// </summary>
        private int saving;
        /// <summary>
        /// 행사비
        /// </summary>
        private int events;

        #endregion

        #region get /set

        public int GyeongJo
        {
            get
            {
                return gyeongJo;
            }

            set
            {
                gyeongJo = value;
            }
        }

        public int Saving
        {
            get
            {
                return saving;
            }

            set
            {
                saving = value;
            }
        }

        public int Events
        {
            get
            {
                return events;
            }

            set
            {
                events = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// 운영 관리비
    /// </summary>
    public class manage
    {

        #region 변수 선언

        /// <summary>
        /// 사택 유지비
        /// </summary>
        private int home;

        /// <summary>
        /// 교회 관리비
        /// </summary>
        private int church;

        /// <summary>
        /// 목회 활동비
        /// </summary>
        private int ministry;

        /// <summary>
        /// 사무비
        /// </summary>
        private int office;

        /// <summary>
        /// 수도 광열비
        /// </summary>
        private int water;

        /// <summary>
        /// 통신비
        /// </summary>
        private int communication;

        /// <summary>
        /// 차량 관리비
        /// </summary>
        private int carManage;

        /// <summary>
        /// 차량 구입비 정립
        /// </summary>
        private int carBuy;

        /// <summary>
        /// 비품비
        /// </summary>
        private int tool;

        /// <summary>
        /// 기타 공과잡비
        /// </summary>
        private int etc;

        #endregion

        #region get / set

        public int Home
        {
            get
            {
                return home;
            }

            set
            {
                home = value;
            }
        }

        public int Church
        {
            get
            {
                return church;
            }

            set
            {
                church = value;
            }
        }

        public int Ministry
        {
            get
            {
                return ministry;
            }

            set
            {
                ministry = value;
            }
        }

        public int Office
        {
            get
            {
                return office;
            }

            set
            {
                office = value;
            }
        }

        public int Water
        {
            get
            {
                return water;
            }

            set
            {
                water = value;
            }
        }

        public int Communication
        {
            get
            {
                return communication;
            }

            set
            {
                communication = value;
            }
        }

        public int CarManage
        {
            get
            {
                return carManage;
            }

            set
            {
                carManage = value;
            }
        }

        public int CarBuy
        {
            get
            {
                return carBuy;
            }

            set
            {
                carBuy = value;
            }
        }

        public int Tool
        {
            get
            {
                return tool;
            }

            set
            {
                tool = value;
            }
        }

        public int Etc
        {
            get
            {
                return etc;
            }

            set
            {
                etc = value;
            }
        }

        #endregion

    }

    /// <summary>
    /// 대출 관련비
    /// </summary>
    public class Loan
    {
        #region 변수 선언

        /// <summary>
        /// 상환 적립금
        /// </summary>
        private int repayment;

        /// <summary>
        /// 지급 이자
        /// </summary>
        private int interest;

        #endregion

        #region get / set

        public int Repayment
        {
            get
            {
                return repayment;
            }

            set
            {
                repayment = value;
            }
        }

        public int Interest
        {
            get
            {
                return interest;
            }

            set
            {
                interest = value;
            }
        }

        #endregion
    }
    #endregion
}
