using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BringSharp.Enums;
using Newtonsoft.Json;

namespace BringSharp.Tracking
{
    public class Tracking
    {
        public Consignment.Consignment Consignment { get; set; }

        private DisplayLanguage DisplayLanguage { get; set; }
        private HttpStatusCode _httpStatusCode;
        private string ResponseUrl { get; set; }

        /// <summary>
        /// Track a shipment by it's tracking number.
        /// </summary>
        /// <param name="trackingNumber">Shipment tracking number</param>
        /// <param name="displayLanguage">Language of the results (Defaults to English if not set)</param>
        /// <returns></returns>
        public async Task TrackByTrackingNumber(string trackingNumber, DisplayLanguage displayLanguage = DisplayLanguage.En)
        {
            // Set properties
            DisplayLanguage = displayLanguage;
            ResponseUrl = $"https://tracking.bring.com/tracking.json?q={trackingNumber}&lang={DisplayLanguage}";

            // Check if TrackingNumber property has been set - Throw exception if not set
            if (string.IsNullOrEmpty(trackingNumber))
                throw new ArgumentNullException(trackingNumber, "Provide value on parameter");

            // Check for valid response
            _httpStatusCode = await JsonQueryClient.GetResponseStatusCode(ResponseUrl);

            // If response is not OK
            if (_httpStatusCode != HttpStatusCode.OK)
                throw new HttpRequestException($"Could not query Bring API response - Query response code: {(int)_httpStatusCode} -- {_httpStatusCode}");

            // Get json response
            var json = await JsonQueryClient.GetResponse(ResponseUrl);

            // Deserialize the json response
            Consignment = JsonConvert.DeserializeObject<Consignment.Consignment>(json);

            // Remove unwanted HTML tags i descriptions
            if (Success())
                RemoveInlineHtml();
        }

        /// <summary>
        /// Checks to see if the response returned without errors.
        /// </summary>
        /// <returns>True for success</returns>
        public bool Success()
        {
            return (_httpStatusCode == HttpStatusCode.OK && Consignment != null && Consignment.ConsignmentSet.Count > 0);
        }

        /// <summary>
        /// Removes unwanted HTML code in properties.
        /// </summary>
        private void RemoveInlineHtml()
        {
            foreach (var eventSet in Consignment.ConsignmentSet[0].PackageSet[0].EventSet)
            {
                var regex = Regex.Match(eventSet.Description, "(.*)<a .*>(.*)<\\/a>");
                if (!regex.Success) continue;

                var description = $"{regex.Groups[1].Value}{regex.Groups[2].Value}";
                eventSet.Description = description;
            }
        }
    }
}
