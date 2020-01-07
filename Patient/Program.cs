using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Patient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PatGUI());
        }
    }

    public enum Instruction
    {
        WAIT_START,
        WAIT_END,
        START_WARMUP,
        START_READING,
        START_COOLDOWN,
        PEDDLE_FASTER,
        PEDDLE_SLOWER,
        PEDDLE_RIGHT,
        HEARTRATE_STEADY
    }
}
