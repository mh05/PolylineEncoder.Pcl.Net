using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolylineEncoder.Pcl.Net.Models;
using PolylineEncoder.Pcl.Net.Utility.Encoders;

namespace PolylineEncoder.Pcl.Net.Tests
{
    [TestClass]
    public class EncoderTests
    {
        [TestMethod]
        public void ShouldAlwaysPassEncoderTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EncodeAmsterdamCoordinate()
        {
            var encoder = new Encoder();
            var actual = encoder.Encode(TestData.AmsterdamCoordinate);
            Assert.AreEqual(TestData.AmsterdamCoordinateEncode, actual);
        }

        [TestMethod]
        public void EncodeAppleHeadCoordinate()
        {
            var encoder = new Encoder();
            var actual = encoder.Encode(TestData.AppleHeadCoordinate);
            Assert.AreEqual(TestData.AppleHeadCoordinateEncode, actual);
        }

        [TestMethod]
        public void EncodeAmsterdamCoordinateAndAppleCoordinate()
        {
            var encoder = new Encoder();
            var actual = encoder.Encode(TestData.AmsterdamCoordinate, TestData.AppleHeadCoordinate);
            // ReSharper disable once StringLiteralTypo
            Assert.AreEqual("{ps~Hya{\\zexzAnbueW", actual);
        }

        [TestMethod]
        public void CheckCustomEncodeOfThreeCoordinates()
        {
            var encoder = new Encoder();
            var geoCoordinates = encoder.Encode
            (
                new GeoCoordinate(52.3702160, 4.895168),
                new GeoCoordinate(37.3316760, -122.030189),
                new GeoCoordinate(37.4160740, -122.075624)
            );

            var customCoordinates = encoder.Encode
            (
                new TestGeoCoordinate(52.3702160, 4.895168),
                new TestGeoCoordinate(37.3316760, -122.030189),
                new TestGeoCoordinate(37.4160740, -122.075624)
            );
            Assert.AreEqual(geoCoordinates, customCoordinates);

        }
    }
}