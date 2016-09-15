using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BringSharp.Annotations;
using BringSharp.Converters;
using BringSharp.Details;
using BringSharp.Enums;
using Newtonsoft.Json.Linq;

namespace BringSharp
{
    public class PackageTracking
    {
        private string _responseUrl;
        private HttpStatusCode _httpStatusCode;
        private string _json;
        private dynamic _jObject;
        private dynamic _root;

        /// <summary>
        /// Tracks a package, using it's tracking number, trough the Bring API
        /// </summary>
        /// <param name="trackingNumber">Tracking number to track</param>
        /// <param name="displayLanguage">Language of the response</param>
        /// <param name="displayDimension">Unit of length, width, height and weight</param>
        /// <returns>Current tracking details of a package</returns>
        public async Task<PackageDetails> GetPackageDetails([NotNull] string trackingNumber, DisplayLanguage displayLanguage = DisplayLanguage.No, DisplayDimension displayDimension = DisplayDimension.Metric)
        {
            _responseUrl = $"https://tracking.bring.com/tracking.json?q={trackingNumber}&lang={displayLanguage}";

            // Check for valid response
            try
            {
                _httpStatusCode = await JsonQueryClient.GetResponseStatusCode(_responseUrl);
            }
            catch (Exception)
            {
                // ignored
            }

            if (_httpStatusCode != HttpStatusCode.OK)
                return new PackageDetails();

            // Get json string
            _json = await JsonQueryClient.GetResponse(_responseUrl);

            // Parse json string to dynamic objects
            _jObject = JObject.Parse(_json);

            // Root object
            _root = _jObject.consignmentSet[0].packageSet[0];

            // Get events
            var eventSetArray = (JArray)_root[AttributeConverter.GetValue(PropertyName.Events)];

            // Get recipient
            var recipient = _root[AttributeConverter.GetValue(PropertyName.Recipient)];

            // Get handling recipient
            var handlingRecipient = _root[AttributeConverter.GetValue(PropertyName.HandlingRecipient)];

            // Return the package details
            return new PackageDetails(
                new Sender(
                    (string)_root[AttributeConverter.GetValue(PropertyName.SenderName)]),

                new Product(
                    (string)_root[AttributeConverter.GetValue(PropertyName.ProductName)],
                    (string)_root[AttributeConverter.GetValue(PropertyName.ProductCode)]),

                new List<Events>(eventSetArray.Select(t => new Events
                    (TrimHtml((string)t.SelectToken(AttributeConverter.GetValue(PropertyName.Description))),
                    (DateTime)t.SelectToken(AttributeConverter.GetValue(PropertyName.TimeStamp)),
                    (string)t.SelectToken(AttributeConverter.GetValue(PropertyName.Status)))).ToList()),

                new Package(
                    displayDimension == DisplayDimension.Imperial ? UnitConverter.ConvertCentimetersToInches((int)_root[AttributeConverter.GetValue(PropertyName.Length)]) : (int)_root[AttributeConverter.GetValue(PropertyName.Length)],
                    displayDimension == DisplayDimension.Imperial ? UnitConverter.ConvertCentimetersToInches((int)_root[AttributeConverter.GetValue(PropertyName.Width)]) : (int)_root[AttributeConverter.GetValue(PropertyName.Width)],
                    displayDimension == DisplayDimension.Imperial ? UnitConverter.ConvertCentimetersToInches((int)_root[AttributeConverter.GetValue(PropertyName.Height)]) : (int)_root[AttributeConverter.GetValue(PropertyName.Height)],
                    (double)_root[AttributeConverter.GetValue(PropertyName.Volume)],
                    displayDimension == DisplayDimension.Imperial ? UnitConverter.ConvertKilogramsToPunds((double)_root[AttributeConverter.GetValue(PropertyName.Weight)]) : (double)_root[AttributeConverter.GetValue(PropertyName.Weight)],
                    (string)_root[AttributeConverter.GetValue(PropertyName.PickupCode)],
                    (DateTime)_root[AttributeConverter.GetValue(PropertyName.DateOfReturn)]),

                new Recipient(
                    (string)recipient?[AttributeConverter.GetValue(PropertyName.AddressLine1)],
                    (string)recipient?[AttributeConverter.GetValue(PropertyName.AddressLine2)],
                    (string)recipient?[AttributeConverter.GetValue(PropertyName.PostalCode)],
                    (string)recipient?[AttributeConverter.GetValue(PropertyName.City)],
                    (string)recipient?[AttributeConverter.GetValue(PropertyName.CountryCode)],
                    (string)recipient?[AttributeConverter.GetValue(PropertyName.Country)]),

                new HandlingRecipient(
                    (string)handlingRecipient?[AttributeConverter.GetValue(PropertyName.AddressLine1)],
                    (string)handlingRecipient?[AttributeConverter.GetValue(PropertyName.AddressLine2)],
                    (string)handlingRecipient?[AttributeConverter.GetValue(PropertyName.PostalCode)],
                    (string)handlingRecipient?[AttributeConverter.GetValue(PropertyName.City)],
                    (string)handlingRecipient?[AttributeConverter.GetValue(PropertyName.CountryCode)],
                    (string)handlingRecipient?[AttributeConverter.GetValue(PropertyName.Country)])
                );
        }

        public bool Success
        {
            get
            {
                if (_httpStatusCode != HttpStatusCode.OK)
                    throw new Exception($"Could not query Bring API - Http response: {(int)_httpStatusCode}: {_httpStatusCode}");

                if (string.IsNullOrEmpty(_json))
                    throw new Exception($"Json response string is null or empty - From target: {_responseUrl}");

                if (_jObject == null)
                    throw new Exception($"Unable to parse json string to JObject: {nameof(_jObject)}");

                if (_root == null)
                    throw new Exception($"Unable to resolve element: {nameof(_root)} - From JObject: {nameof(_jObject)}");

                return _httpStatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(_json) && _jObject != null && _root != null;
            }
        }

        private static string TrimHtml(string input)
        {
            return Regex.Replace(input, "<a\\starget=\"_blank\"\\stitle=\".*\"\\shref=\".*\"\\sclass=\".*\">|<\\/a>", string.Empty);
        }
    }
}
