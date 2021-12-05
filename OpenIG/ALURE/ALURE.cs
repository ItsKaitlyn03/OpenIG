using System;
using static OpenAL.ALC10;

namespace ALURE
{
    public static class ALURE
    {
        private static string _lastError = "No error";

        private static void SetError(string err)
        {
            _lastError = err;
        }

        public static string alureGetErrorString()
        {
            string ret = _lastError;
            _lastError = "No error";
            return ret;
        }

        public static bool alureInitDevice(string name, params int[] attribs)
        {
            IntPtr device = alcOpenDevice(name);
            if (device == IntPtr.Zero)
            {
                alcGetError(IntPtr.Zero);

                SetError("Device open failed");
                return false;
            }

            IntPtr context = alcCreateContext(device, attribs);
            if (context == IntPtr.Zero || !alcMakeContextCurrent(context))
            {
                if (context != IntPtr.Zero)
                    alcDestroyContext(context);
                alcCloseDevice(device);

                SetError("Context setup failed");
                return false;
            }
            alcGetError(device);

            return true;
        }
    }
}
