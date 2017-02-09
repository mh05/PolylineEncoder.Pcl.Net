using System;
using System.Collections.Generic;
using PolylineEncoder.Pcl.Net.Models;

namespace PolylineEncoder.Pcl.Net.Utility.Encoders
{
    public interface IPolylineEncoder
    {
        string Encode(double latitude, double longitude);
        string Encode(IGeoCoordinate point);
        string Encode(IEnumerable<Tuple<double, double>> points);
        string Encode(IEnumerable<IGeoCoordinate> points);
    }
}
