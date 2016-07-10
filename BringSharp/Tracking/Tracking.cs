using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BringSharp.Enums;
using BringSharp.Tracking.ConsignmentData;
using Newtonsoft.Json;

namespace BringSharp.Tracking
{
    public class Tracking
    {
        private DisplayLanguage DisplayLanguage { get; set; }

        private string TrackingNumber { get; set; }

        public Consignment Consignment { get; set; }

        private HttpStatusCode _httpStatusCode;

        /// <summary>
        /// Track a shipment by it's tracking number.
        /// </summary>
        /// <param name="trackingNumber">Shipment tracking number</param>
        /// <param name="displayLanguage">Language of the results (Defaults to English if not set)</param>
        /// <returns></returns>
        public async Task TrackByPackageNumber(string trackingNumber, DisplayLanguage displayLanguage = DisplayLanguage.En)
        {
            TrackingNumber = trackingNumber;
            DisplayLanguage = displayLanguage;

            // Check if TrackingNumber property has been set - Throw exception if not set
            if (string.IsNullOrEmpty(TrackingNumber))
                throw new Exception("Provide value on parameter TrackingNumber");

            // Query bring API json response
            var json = await QueryJsonResponse();

            // If the status is OK
            if (_httpStatusCode == HttpStatusCode.OK)
            {
                // Deserialize the json response
                Consignment = JsonConvert.DeserializeObject<Consignment>(json);
            }
            else
            {
                Debug.WriteLine($"Could not query Bring API response - Query response code: {(int) _httpStatusCode} {_httpStatusCode}");
            }
        }

        private async Task<string> QueryJsonResponse()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(new Uri($"https://tracking.bring.com/tracking.json?q={TrackingNumber}&lang={DisplayLanguage}"));

                if (response.IsSuccessStatusCode)
                {
                    _httpStatusCode = response.StatusCode;
                }
                else
                {
                    _httpStatusCode = response.StatusCode;
                    return null;
                }

                return await httpClient.GetStringAsync(new Uri($"https://tracking.bring.com/tracking.json?q={TrackingNumber}&lang={DisplayLanguage}"));
            }
        }

        public bool Success()
        {
            return (_httpStatusCode == HttpStatusCode.OK && Consignment != null && Consignment.ConsignmentSet.Count > 0);
        }
    }
}
