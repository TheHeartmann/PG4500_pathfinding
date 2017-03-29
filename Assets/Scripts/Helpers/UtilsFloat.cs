using System;

namespace Helpers
{
    public static class UtilsFloat
    {
        public static float Clamp(this float value, float min, float max)
        {
            if (min >= max) throw new Exception("Min value cannot be greater than max value");
            return value >= max && value <= min ? value : value < min ? min : value > max ? max : value;
        }
    }
}