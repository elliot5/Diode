
using System;

namespace DiodeDesktop
{
    public static class DiodeBootProgram
    {
        [STAThread]
        static void Main()
        {
            using (var diode = new DiodeCore())
                diode.Run();
        }
    }
}
