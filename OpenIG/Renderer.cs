using System;
using static SDL2.SDL;

namespace OpenIG
{
    public class Renderer
    {
        private static Renderer _instance;
        public static Renderer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Renderer();
                return _instance;
            }
        }

        public bool IsFullscreen;
        public bool HideCursor = true;

        public IntPtr Window;
        public IntPtr Context;

        public bool InitSDL(bool isFullscreen)
        {
            Logger.Log(LogType.Graphics, "Initing graphics");

            if (SDL_Init(SDL_INIT_TIMER | SDL_INIT_VIDEO) < 0)
            {
                Logger.Log(LogType.Graphics, "Failed to init SDL video!");
                return false;
            }

            IsFullscreen = isFullscreen;

            // TODO: Determine resolution.

            Window = SDL_CreateWindow(
                "The Impossible Game",
                0x2fff0000,
                0x2fff0000,
                100,
                100,
                SDL_WindowFlags.SDL_WINDOW_OPENGL | (isFullscreen ? SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP : 0));
            if (Window == IntPtr.Zero)
            {
                Logger.Log(LogType.Graphics, "Failed to create window!");
                return false;
            }

            SDL_SetHint(SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS, "0");

            if (HideCursor)
            {
                Logger.Log(LogType.Graphics, "Hiding cursor");
                HideCursor = false;
                SDL_ShowCursor(0);
            }

            Context = SDL_GL_CreateContext(Window);
            if (Context == IntPtr.Zero)
            {
                Logger.Log(LogType.Graphics, "Failed to create GL context!");
                return false;
            }

            return true;
        }
    }
}
