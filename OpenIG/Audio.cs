using static ALURE.ALURE;
using static OpenAL.AL10;

namespace OpenIG
{
    public class Audio
    {
        private static Audio _instance;
        public static Audio Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Audio();
                return _instance;
            }
        }

        public bool Initialized;
        public static uint Source;

        public bool InitSubsystem()
        {
            for (var i = 0; i < 5; ++i)
            {
                Initialized = alureInitDevice("", 0);
                if (Initialized)
                    break;

                var errorString = alureGetErrorString();
                if (errorString != null)
                    Logger.Log(LogType.OpenAL, errorString);

                // TODO: Handle this.

                Initialized = true;
            }

            if (!Initialized)
                return false;

            alGenSources(1, out Source);
            alListener3f(4100, 0, 0, 0);
            alSource3f(Source, 4100, 0, 0, 0);

            return true;
        }
    }
}
