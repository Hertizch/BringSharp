# BringSharp
A simple web API wrapper library for tracking packages trough Bring.

## Compatibility
Windows Desktop, Windows Phone 8.1, iOS and Android. Requires .NET framework 4.5 or later.

## Changelog
### 2.0.0;
- Complete rewrite

### 1.0.3
- More exception handling

### 1.0.2
- Remove unwanted HTML formatting

### 1.0.1
- Exception handling

### 1.0.0
- Initial commit.

## Usage
Example tracking:
```C#
            var packageTracking = new PackageTracking();
            var packageDetails = await packageTracking.GetPackageDetails("TESTPACKAGE-AT-PICKUPPOINT");
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
```
