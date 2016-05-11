using System;

namespace DiodeDesktop
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class DiodeBootProgram
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new DiodeCore())
                game.Run();
        }
    }
}
