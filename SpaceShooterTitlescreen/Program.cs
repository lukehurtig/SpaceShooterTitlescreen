using System;

namespace SpaceShooterTitlescreen
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Title())
                game.Run();
        }
    }
}
