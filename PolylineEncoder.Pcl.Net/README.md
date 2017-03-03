# PolylineEncoder PCL.Net

### Information
Its is a portable class libray of [PolyLineEncoder.Net][3] from Alex Frame and all credits goes to him 

The MIT License (MIT)

### Features
Allows you to encode and decode lat/long pairs into Google's encoded polyline format. You can learn more about Google's algorithm [here][1], but you don't have to, let this package do the work for you.


### Usage
It's easy to use, create an instance of `IPolylineUtility` and simple start encoding or decoding. You can pass in `IEnumerable<IGeoCoordinate>` or `IEnumerable<Tuple<double,double>>`.

```csharp
// Create a polyline utility.
var utility = new PolylineUtility();

// Create an IEnumberable<IGeoCoordinate>
// or IEnumerable<Tuple<double,double>>
var geoPoints = new List<IGeoCoordinate>
{
    new GeoCoordinate(38.5, -120.2),
    new GeoCoordinate(40.7, -120.95),
    new GeoCoordinate(43.252, -126.453)
};

// Encode points to string.
var polyLine = utility.Encode(geoPoints); // output: _p~iF~ps|U_ulLnnqC_mqNvxq`@

// Decode string to points. 
var decodedPoints = utility.Decode(polyLine); // output: An IEnumerable<GeoCoorindate> equal to geoPoints.
// 
var customPoints = utility.Decode
```

  [1]: https://developers.google.com/maps/documentation/utilities/polylinealgorithm
  [2]: https://www.nuget.org/packages/PolylineEncoder.Net
  [3]: https://github.com/alexframe/PolylineEncoder.Net