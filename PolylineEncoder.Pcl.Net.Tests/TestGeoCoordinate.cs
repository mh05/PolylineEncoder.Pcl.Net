using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolylineEncoder.Pcl.Net.Models;

namespace PolylineEncoder.Pcl.Net.Tests
{
    public class TestGeoCoordinate : IGeoCoordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
