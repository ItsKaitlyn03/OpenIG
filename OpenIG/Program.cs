using System;

namespace OpenIG
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // TODO: Init steam?

            {
                Logger.Log(LogType.Game, "Starting application");

                if (!Audio.Instance.InitSubsystem())
                    Logger.Log(LogType.Audio, "Audio subsystem init failed!");

                if (!Renderer.Instance.InitSDL(false))
                {
                    // ...
                }
            }

            Console.ReadKey();
        }
    }
}
