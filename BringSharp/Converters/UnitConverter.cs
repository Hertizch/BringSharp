namespace BringSharp.Converters
{
    public static class UnitConverter
    {
        public static int ConvertCentimetersToInches(int centimeters)
        {
            return (int)(centimeters / 2.54);
        }

        public static double ConvertKilogramsToPunds(double kilograms)
        {
            return kilograms * 2.20462;
        }
    }
}
