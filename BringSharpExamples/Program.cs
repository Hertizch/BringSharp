﻿using System;
using BringSharp;
using BringSharp.Enums;

namespace BringSharpExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            GetTrackingDetails();

            Console.ReadKey();
        }

        private static PackageTracking _packageTracking;
        private static string _trackingNumber = "TESTPACKAGE-AT-PICKUPPOINT";

        private static async void GetTrackingDetails()
        {
            _packageTracking = new PackageTracking();

            var packageDetails = await _packageTracking.GetPackageDetails(_trackingNumber, DisplayLanguage.En, DisplayDimension.Metric); // Testing number: TESTPACKAGE-AT-PICKUPPOINT

            if (!_packageTracking.Success)
            {
                Console.WriteLine("Package tracking unsuccessfull!");
                return;
            }

            Console.WriteLine($"Sender Name: {packageDetails.Sender.Name}");
            Console.WriteLine($"Product Name: {packageDetails.Product.Name}");
            Console.WriteLine($"Product Code: {packageDetails.Product.Code}");

            Console.WriteLine($"Package Height: {packageDetails.Package.Height}");
            Console.WriteLine($"Package Length: {packageDetails.Package.Length}");
            Console.WriteLine($"Package Volume: {packageDetails.Package.Volume}");
            Console.WriteLine($"Package Weight: {packageDetails.Package.Weight}");
            Console.WriteLine($"Package Width: {packageDetails.Package.Width}");
            Console.WriteLine($"Package Pickup Code: {packageDetails.Package.PickupCode}");
            Console.WriteLine($"Package Date Of Return: {packageDetails.Package.DateOfReturn}");

            Console.WriteLine($"Recipient Address Line 1: {packageDetails.Recipient.AddressLine1}");
            Console.WriteLine($"Recipient Address Line 2: {packageDetails.Recipient.AddressLine2}");
            Console.WriteLine($"Recipient Postal Code: {packageDetails.Recipient.PostalCode}");
            Console.WriteLine($"Recipient City: {packageDetails.Recipient.City}");
            Console.WriteLine($"Recipient Country Code: {packageDetails.Recipient.CountryCode}");
            Console.WriteLine($"Recipient Country: {packageDetails.Recipient.Country}");

            Console.WriteLine($"Handling Recipient Address Line 1: {packageDetails.HandlingRecipient.AddressLine1}");
            Console.WriteLine($"Handling Recipient Address Line 2: {packageDetails.HandlingRecipient.AddressLine2}");
            Console.WriteLine($"Handling Recipient Postal Code: {packageDetails.HandlingRecipient.PostalCode}");
            Console.WriteLine($"Handling Recipient City: {packageDetails.HandlingRecipient.City}");
            Console.WriteLine($"Handling Recipient Country Code: {packageDetails.HandlingRecipient.CountryCode}");
            Console.WriteLine($"Handling Recipient Country: {packageDetails.HandlingRecipient.Country}");

            foreach (var packageEvent in packageDetails.Events)
            {
                Console.WriteLine($"Event: {packageEvent.TimeStamp} ({packageEvent.Status}): {packageEvent.Description}");
            }
        }
    }
}
