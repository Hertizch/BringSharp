using System.Collections.Generic;

namespace BringSharp.Tracking.ConsignmentData
{
    public class PackageSet
    {
        public string StatusDescription { get; set; }
        public List<object> Descriptions { get; set; }
        public string PackageNumber { get; set; }
        public string PreviousPackageNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Brand { get; set; }
        public int LengthInCm { get; set; }
        public int WidthInCm { get; set; }
        public int HeightInCm { get; set; }
        public double VolumeInDm3 { get; set; }
        public double WeightInKgs { get; set; }
        public string PickupCode { get; set; }
        public string DateOfReturn { get; set; }
        public string SenderName { get; set; }
        public SenderAddress SenderAddress { get; set; }
        public RecipientAddress RecipientAddress { get; set; }
        public RecipientHandlingAddress RecipientHandlingAddress { get; set; }
        public List<EventSet> EventSet { get; set; }
    }
}
