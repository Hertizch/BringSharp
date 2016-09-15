using BringSharp.Extensions;

namespace BringSharp.Enums
{
    public enum PropertyName
    {
        [ApiPropertyName("senderName")]
        SenderName,

        [ApiPropertyName("productName")]
        ProductName,

        [ApiPropertyName("productCode")]
        ProductCode,

        [ApiPropertyName("description")]
        Description,

        [ApiPropertyName("dateIso")]
        TimeStamp,

        [ApiPropertyName("status")]
        Status,

        [ApiPropertyName("lengthInCm")]
        Length,

        [ApiPropertyName("widthInCm")]
        Width,

        [ApiPropertyName("heightInCm")]
        Height,

        [ApiPropertyName("volumeInDm3")]
        Volume,

        [ApiPropertyName("weightInKgs")]
        Weight,

        [ApiPropertyName("pickupCode")]
        PickupCode,

        [ApiPropertyName("dateOfReturn")]
        DateOfReturn,

        [ApiPropertyName("addressLine1")]
        AddressLine1,

        [ApiPropertyName("addressLine2")]
        AddressLine2,

        [ApiPropertyName("postalCode")]
        PostalCode,

        [ApiPropertyName("city")]
        City,

        [ApiPropertyName("countryCode")]
        CountryCode,

        [ApiPropertyName("country")]
        Country,

        [ApiPropertyName("eventSet")]
        Events,

        [ApiPropertyName("recipientAddress")]
        Recipient,

        [ApiPropertyName("recipientHandlingAddress")]
        HandlingRecipient,
    }
}