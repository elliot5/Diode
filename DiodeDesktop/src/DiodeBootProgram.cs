
using System;

namespace DiodeDesktop
{
    public static class DiodeBootProgram
    {
        //Create a runnable thread, and run Diode within the thread.
        [STAThread]
        static void Main()
        {
            using (var diode = new DiodeCore())
                diode.Run();
        }
    }
}