using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    static class Program
    {

        enum Mode { Test, Regular};
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mode mode = Mode.Test;

            switch(mode)
            {
                case Mode.Regular:
                    Application.Run(new Form1());
                    break;
                case Mode.Test:
                    Application.Run(new TestForm());
                    break;
            }

        }
    }
}
