# BringSharp
A simple web API wrapper library for tracking packages trough Bring.

## Compatibility
Windows Desktop, Windows Phone 8.1, iOS and Android. Requires .NET framework 4.5 or later.

## Usage
Example usage:
```
var tracking = new Tracking();

await tracking.TrackByPackageNumber("trackingNumber");

if (tracking.Success())
  {
    var results = tracking.Consignment.ConsignmentSet[0];

    Console.WriteLine($"Sender: {results.SenderName}");
    Console.WriteLine($"Recipient: {results.RecipientAddress.City}");
    Console.WriteLine($"Package Volume: {results.TotalVolumeInDm3}");
    Console.WriteLine($"Package Weight: {results.TotalWeightInKgs} kg");

    var eventResults = results.PackageSet[0].EventSet;

    foreach (var trackingEvent in eventResults)
    {
      Console.WriteLine($"{trackingEvent.DisplayDate} {trackingEvent.DisplayTime}: {trackingEvent.Description}");
    }
```
