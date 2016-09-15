using System;

namespace BringSharp.Details
{
    public struct Package
    {
        /// <summary>
        /// Gets the packages physical length (DisplayDimension.Metric == Centimeters (cm), DisplayDimension.Imperial == Inches (inch))
        /// </summary>
        public readonly int Length;

        /// <summary>
        /// Gets the packages physical width (DisplayDimension.Metric == Centimeters (cm), DisplayDimension.Imperial == Inches (inch))
        /// </summary>
        public readonly int Width;

        /// <summary>
        /// Gets the packages physical height (DisplayDimension.Metric == Centimeters (cm), DisplayDimension.Imperial == Inches (inch))
        /// </summary>
        public readonly int Height;

        /// <summary>
        /// Gets the packages physical volume (in Cubic Decimeter (dm3)/Liter (l))
        /// </summary>
        public readonly double Volume;

        /// <summary>
        /// Gets the packages physical weight (DisplayDimension.Metric == Kilograms (kg), DisplayDimension.Imperial == Punds (pound))
        /// </summary>
        public readonly double Weight;

        /// <summary>
        /// Gets the packages pickup code
        /// </summary>
        public readonly string PickupCode;

        /// <summary>
        /// Gets the packages date of return
        /// </summary>
        public readonly DateTime DateOfReturn;

        public Package(int length, int width, int height, double volume, double weight, string pickupCode, DateTime dateOfReturn)
        {
            Length = length;
            Width = width;
            Height = height;
            Volume = volume;
            Weight = weight;
            PickupCode = pickupCode;
            DateOfReturn = dateOfReturn;
        }
    }
}