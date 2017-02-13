using System;
using System.Collections.Generic;
using PolylineEncoder.Pcl.Net.Models;
using PolylineEncoder.Pcl.Net.Utility.Decoders;
using PolylineEncoder.Pcl.Net.Utility.Encoders;

namespace PolylineEncoder.Pcl.Net.Utility
{
    public class PolylineUtility : IPolylineUtility
    {
        private readonly IPolylineEncoder _encoder;
        private readonly IPolylineDecoder _decoder;

        public PolylineUtility() : this(new Encoder(), new Decoder()) { }

        public PolylineUtility(IPolylineEncoder encoder, IPolylineDecoder decoder)
        {
            _encoder = encoder;
            _decoder = decoder;
        }

        public string Encode(double latitude, double longitude)
        {
            return _encoder.Encode(latitude, longitude);
        }

        public string Encode(IGeoCoordinate point)
        {
            return _encoder.Encode(point);
        }

        public string Encode(IEnumerable<Tuple<double, double>> points)
        {
            return _encoder.Encode(points);
        }

        public string Encode(IEnumerable<IGeoCoordinate> points)
        {
            return _encoder.Encode(points);
        }

        public IEnumerable<Tuple<double, double>> DecodeAsTuples<T>(string encodedPoints)
             where T : IGeoCoordinate, new()
        {
            return _decoder.DecodeAsTuples<T>(encodedPoints);
        }

        public IEnumerable<T> Decode<T>(string encodedPoints)
             where T : IGeoCoordinate, new()
        {
            return _decoder.Decode<T>(encodedPoints);
        }
    }
}
