namespace Enigma_Proxies.Utilities
{
    public static class EMath
    {
        
        

        public static int Clamp(int number, int min, int max)
        {
            return (int) Clamp((float) number, (float) min, (float) max);
        }
        
        public static float Clamp(float number, float min, float max)
        {
            if (number > max) return max;
            if (number < min) return min;
            
            return number;
        }
    }
}