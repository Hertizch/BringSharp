namespace BringSharp.Details
{
    public struct Recipient
    {
        /// <summary>
        /// Gets the recipients address line 1
        /// </summary>
        public readonly string AddressLine1;

        /// <summary>
        /// Gets the recipients address line 2
        /// </summary>
        public readonly string AddressLine2;

        /// <summary>
        /// Gets the recipients postal code
        /// </summary>
        public readonly string PostalCode;

        /// <summary>
        /// Gets the recipients city
        /// </summary>
        public readonly string City;

        /// <summary>
        /// Gets the recipients country code
        /// </summary>
        public readonly string CountryCode;

        /// <summary>
        /// Gets the recipients country
        /// </summary>
        public readonly string Country;

        public Recipient(string addressLine1, string addressLine2, string postalCode, string city, string countryCode, string country)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            PostalCode = postalCode;
            City = city;
            CountryCode = countryCode;
            Country = country;
        }
    }
}