using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BringSharp.Annotations;
using BringSharp.Details;
using BringSharp.Enums;
using Newtonsoft.Json.Linq;

namespace BringSharp
{
    public class PackageTracking
    {
        /// <summary>
        /// Tracks a package, using it's tracking number, trough the Bring API
        /// </summary>
        /// <param name="trackingNumber">Tracking number to track</param>
        /// <param name="displayLanguage">Language of the response</param>
        /// <returns>Current tracking details of a package</returns>
        public async Task<PackageDetails> GetPackageDetails([NotNull] string trackingNumber, DisplayLanguage displayLanguage = DisplayLanguage.No)
        {
            string responseUrl = $"https://tracking.bring.com/tracking.json?q={trackingNumber}&lang={displayLanguage}";

            // Check for valid response
            var httpStatusCode = await JsonQueryClient.GetResponseStatusCode(responseUrl);
            if (httpStatusCode != HttpStatusCode.OK)
                throw new HttpRequestException($"Could not query Bring API - Http response: {(int)httpStatusCode}: {httpStatusCode}");

            // Get json string
            var json = await JsonQueryClient.GetResponse(responseUrl);

            // Parse json string to dynamic objects
            dynamic dyn = JObject.Parse(json);

            // Root object
            var root = dyn.consignmentSet[0].packageSet[0];

            // Get events
            var eventSetArray = (JArray) root["eventSet"];

            // Get recipient
            var recipient = root["recipientAddress"];

            // Get handling recipient
            var handlingRecipient = root["recipientHandlingAddress"];

            // Return the package details
            return new PackageDetails(
                new Sender(
                    (string)root["senderName"]),

                new Product(
                    (string)root["productName"],
                    (string)root["productCode"]),

                new List<Events>(eventSetArray.Select(t => new Events
                    (TrimHtml((string)t.SelectToken("description")),
                    (DateTime)t.SelectToken("dateIso"),
                    (string)t.SelectToken("status"))).ToList()),

                new Package(
                    (int)root["lengthInCm"],
                    (int)root["widthInCm"],
                    (int)root["heightInCm"],
                    (double)root["volumeInDm3"],
                    (double)root["weightInKgs"],
                    (string)root["pickupCode"],
                    (DateTime)root["dateOfReturn"]),

                new Recipient(
                    (string)recipient?["addressLine1"],
                    (string)recipient?["addressLine2"],
                    (string)recipient?["postalCode"],
                    (string)recipient?["city"],
                    (string)recipient?["countryCode"],
                    (string)recipient?["country"]),

                new HandlingRecipient(
                    (string)handlingRecipient?["addressLine1"],
                    (string)handlingRecipient?["addressLine2"],
                    (string)handlingRecipient?["postalCode"],
                    (string)handlingRecipient?["city"],
                    (string)handlingRecipient?["countryCode"],
                    (string)handlingRecipient?["country"])
                );
        }

        private static string TrimHtml(string input)
        {
            return Regex.Replace(input, "<a\\starget=\"_blank\"\\stitle=\".*\"\\shref=\".*\"\\sclass=\".*\">|<\\/a>", string.Empty);
        }
    }
}
