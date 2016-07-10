# BringSharp
A simple web API wrapper library for tracking packages trough Bring.

## Compatibility
Windows Desktop, Windows Phone 8.1, iOS and Android. Requires .NET framework 4.5 or later.

## Usage
Example usage:
```
Tracking tracking = new Tracking
{
  DisplayLanguage = DisplayLanguage.No
};

await tracking.TrackByPackageNumber("trackingNumber");
```
