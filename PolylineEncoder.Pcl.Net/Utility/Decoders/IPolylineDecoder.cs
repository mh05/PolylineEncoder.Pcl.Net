using System;
using System.Collections.Generic;
using PolylineEncoder.Pcl.Net.Models;

namespace PolylineEncoder.Pcl.Net.Utility.Decoders
{
    public interface IPolylineDecoder
    {
        IEnumerable<Tuple<double, double>> DecodeAsTuples<T>(string encodedPoints) where T : IGeoCoordinate, new();
        IEnumerable<T> Decode<T>(string encodedPoints) where T : IGeoCoordinate, new();
    }
}