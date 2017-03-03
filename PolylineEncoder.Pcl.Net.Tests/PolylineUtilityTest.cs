using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolylineEncoder.Pcl.Net.Models;
using PolylineEncoder.Pcl.Net.Utility;

namespace PolylineEncoder.Pcl.Net.Tests
{
    /// <summary>
    /// Test the whole Chain
    /// </summary>
    [TestClass]
    public class PolylineUtilityTest
    {
        //Google uses math 5 till its max.
        private const double Tolerance = 1 / 1E5;

        [TestMethod]
        public void ShouldAlwaysPassPolyLineTests()
        {
            Assert.IsFalse(false);
        }

        [TestMethod]
        public void EncodeDecodeAmsterdamCoordinate()
        {
            var utility = new PolylineUtility();
            var encodeStr = utility.Encode(TestData.AmsterdamCoordinate);
            var coordinates = utility.Decode(encodeStr);
            var geoCoordinates = coordinates as IGeoCoordinate[] ?? coordinates.ToArray();
            var firstCoordinate = geoCoordinates.First();
            Assert.IsTrue(Math.Abs(firstCoordinate.Longitude - TestData.AmsterdamCoordinate.Longitude) < Tolerance);
        }

        [TestMethod]
        public void EncodeDecodeThreeCoordinates()
        {
            var utility = new PolylineUtility();
            var encodeStr = utility.Encode
            (
                TestData.AmsterdamCoordinate,
                TestData.MicrosofHeadCoordinate,
                TestData.AppleHeadCoordinate
            );

            var coordinates = utility.Decode(encodeStr);
            Assert.IsTrue(coordinates.Count() == 3);

        }

        [TestMethod]
        public void CheckCountOfCustomAgainstCountofInternal()
        {
            var utility = new PolylineUtility();
            var encodeStr = utility.Encode
            (
                TestData.AmsterdamCoordinate,
                TestData.MicrosofHeadCoordinate,
                TestData.AppleHeadCoordinate
            );
            Assert.AreEqual(utility.Decode(encodeStr).Count(), utility.Decode<TestGeoCoordinate>(encodeStr).Count());
        }

        [TestMethod]
        public void EncodeDecodeThreeCoordinatesSameCustomCheck()
        {
            var utility = new PolylineUtility();
            var encodeStr = utility.Encode
            (
                TestData.AmsterdamCoordinate,
                TestData.MicrosofHeadCoordinate,
                TestData.AppleHeadCoordinate
            );
            var geoCoordinates = utility.Decode(encodeStr).ToList();
            var testCoordinates = utility.Decode<TestGeoCoordinate>(encodeStr).ToList();
            Assert.IsTrue(!geoCoordinates.Where((t, i) => !(Math.Abs(t.Longitude - testCoordinates[i].Longitude) < Tolerance) 
                || !(Math.Abs(t.Latitude - testCoordinates[i].Latitude) < Tolerance)).Any());

        }

        [TestMethod]
        public void DecodeEncodeMicrosoftHead()
        {
           var utility = new PolylineUtility();
           var coordinate = utility.Decode(TestData.MicrosoftHeadCoordinateEncode);
                
        }
      
    }
}
