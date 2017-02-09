using System;
using System.Collections.Generic;
using PolylineEncoder.Pcl.Net.Models;

namespace PolylineEncoder.Pcl.Net.Utility.Decoders
{
    public interface IPolylineDecoder
    {
        IEnumerable<Tuple<double, double>> DecodeAsTuples(string encodedPoints);
        IEnumerable<IGeoCoordinate> Decode(string encodedPoints);
    }
}