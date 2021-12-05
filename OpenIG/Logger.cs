using System;
using System.IO;

namespace OpenIG
{
    public enum LogType
    {
        GGL = 1,
        Generic = 2,
        Graphics = 3,
        Game = 4,
        Unknown = 5, // Shouldn't this be 0? Wtf, FlukeDude??
        Steam = 6,
        OpenAL = 7,
        Audio = 8,
        Input = 9
    }

    public static class Logger
    {
        public static void Log(LogType type, string message)
        {
            var value = $"[{type}] {message}\n";
            Console.Write(value);
            File.AppendAllText("debug.log", value);
        }
    }
}
