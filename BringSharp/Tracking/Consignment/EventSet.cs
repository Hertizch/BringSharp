namespace BringSharp.Tracking.Consignment
{
    public class EventSet
    {
        public string Description { get; set; }

        /// <summary>
        /// Possible values:
        /// ARRIVED_COLLECTION,
        /// ARRIVED_DELIVERY,
        /// CUSTOMS,
        /// COLLECTED,
        /// DELIVERED,
        /// DELIVERY_CANCELLED,
        /// DELIVERY_CHANGED,
        /// DELIVERY_ORDERED,
        /// DEVIATION,
        /// HANDED_IN,
        /// INTERNATIONAL,
        /// IN_TRANSIT,
        /// NOTIFICATION_SENT,
        /// PRE_NOTIFIED,
        /// READY_FOR_PICKUP,
        /// RETURN,
        /// TRANSPORT_TO_RECIPIENT
        /// </summary>
        public string Status { get; set; }

        public RecipientSignature RecipientSignature { get; set; }

        public string UnitId { get; set; }

        public string UnitType { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string Country { get; set; }

        public string DateIso { get; set; }

        public string DisplayDate { get; set; }

        public string DisplayTime { get; set; }

        public bool ConsignmentEvent { get; set; }

        public string UnitInformationUrl { get; set; }
    }
}
