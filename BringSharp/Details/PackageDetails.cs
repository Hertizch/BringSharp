using System.Collections.Generic;

namespace BringSharp.Details
{
    public struct PackageDetails
    {
        /// <summary>
        /// Gets the sender details
        /// </summary>
        public readonly Sender Sender;

        /// <summary>
        /// Gets the product details
        /// </summary>
        public readonly Product Product;

        /// <summary>
        /// Gets the event details
        /// </summary>
        public readonly List<Events> Events;

        /// <summary>
        /// Gets the recipient details
        /// </summary>
        public readonly Recipient Recipient;

        /// <summary>
        /// Gets the handling recipient details
        /// </summary>
        public readonly HandlingRecipient HandlingRecipient;

        /// <summary>
        /// Gets the package details
        /// </summary>
        public readonly Package Package;

        public PackageDetails(Sender sender, Product product, List<Events> events, Package package, Recipient recipient, HandlingRecipient handlingRecipient)
        {
            Sender = sender;
            Product = product;
            Events = events;
            Package = package;
            Recipient = recipient;
            HandlingRecipient = handlingRecipient;
        }
    }
}