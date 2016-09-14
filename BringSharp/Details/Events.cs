using System;

namespace BringSharp.Details
{
    public struct Events
    {
        /// <summary>
        /// Gets the events description
        /// </summary>
        public readonly string Description;

        /// <summary>
        /// Gets the events time stamp
        /// </summary>
        public readonly DateTime TimeStamp;

        /// <summary>
        /// Gets the events status
        /// </summary>
        public readonly string Status;

        public Events(string description, DateTime timeStamp, string status)
        {
            Description = description;
            TimeStamp = timeStamp;
            Status = status;
        }
    }
}