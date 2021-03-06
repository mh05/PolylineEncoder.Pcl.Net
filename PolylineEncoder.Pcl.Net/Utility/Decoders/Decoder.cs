﻿using System;
using System.Collections.Generic;
using PolylineEncoder.Pcl.Net.Models;

namespace PolylineEncoder.Pcl.Net.Utility.Decoders
{
    public class Decoder : IPolylineDecoder
    {
        private const double Divider = 1E5d;
        /// <summary>
        /// Latitude,Longitude
        /// </summary>
        /// <param name="encodedPoints"></param>
        /// <returns></returns>
        public IEnumerable<Tuple<double, double>> DecodeAsTuples<T>(string encodedPoints)
            where T : IGeoCoordinate, new()
        {
            if (string.IsNullOrEmpty(encodedPoints)) yield break;
            foreach (var point in Decode<T>(encodedPoints))
            {
                yield return Tuple.Create(point.Latitude, point.Longitude);
            }
        }

        public IEnumerable<GeoCoordinate> Decode(string encodePoints)
        {
            return Decode<GeoCoordinate>(encodePoints);
        }

        public IEnumerable<T> Decode<T>(string encodedPoints)
            where T : IGeoCoordinate, new()
        {
            if (string.IsNullOrEmpty(encodedPoints)) yield break;
            var polyLineChars = encodedPoints.ToCharArray();
            var index = 0;

            var currentLat = 0;
            var currentLng = 0;

            while (index < polyLineChars.Length)
            {
                // Calculate next Latitude
                var sum = 0;
                var shifter = 0;
                int next5Bits;

                do
                {
                    next5Bits = polyLineChars[index++] - 63;
                    sum |= (next5Bits & 31) << shifter;
                    shifter += 5;
                }
                while (next5Bits >= 32 && index < polyLineChars.Length);

                if (index >= polyLineChars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

                // Calculate next longitude
                sum = 0;
                shifter = 0;

                do
                {
                    next5Bits = polyLineChars[index++] - 63;
                    sum |= (next5Bits & 31) << shifter;
                    shifter += 5;
                }
                while (next5Bits >= 32 && index < polyLineChars.Length);

                if (index >= polyLineChars.Length && next5Bits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : sum >> 1;

                var geoPoint = new T
                {
                    Latitude = Convert.ToDouble(currentLat) / Divider,
                    Longitude = Convert.ToDouble(currentLng) / Divider
                };

                yield return geoPoint;
            }
        }
    }
}
