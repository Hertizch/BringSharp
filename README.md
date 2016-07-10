# BringSharp
A simple web API wrapper library for tracking packages trough Bring.

## Compatibility
Windows (7, 8, 8.1, 10), iOS and Android. Requires .NET framework 4.5 or later.

## Usage
Example usage:
```
Tracking tracking = new Tracking
{
  DisplayLanguage = DisplayLanguage.No
};

await tracking.TrackByPackageNumber("trackingNumber");
```
