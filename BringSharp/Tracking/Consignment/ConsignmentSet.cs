using System.Collections.Generic;

namespace BringSharp.Tracking.Consignment
{
    public class ConsignmentSet
    {
        public string ConsignmentId { get; set; }

        public string PreviousConsignmentId { get; set; }

        public List<PackageSet> PackageSet { get; set; }

        public string SenderName { get; set; }

        public SenderAddress2 SenderAddress { get; set; }

        public RecipientAddress2 RecipientAddress { get; set; }

        public RecipientHandlingAddress2 RecipientHandlingAddress { get; set; }

        public string SenderReference { get; set; }

        public double TotalWeightInKgs { get; set; }

        public double TotalVolumeInDm3 { get; set; }
    }
}
