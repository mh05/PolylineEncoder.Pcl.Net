using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolylineEncoder.Pcl.Net.Utility.Decoders;

namespace PolylineEncoder.Pcl.Net.Tests
{
    [TestClass]
    public class DecoderTests
    {
        [TestMethod]
        public void ShouldAlwaysPassDecodeTest()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void DecodeSingleCoordinate()
        {
            var decoder = new Decoder();
            var coordinate = decoder.Decode(TestData.MicrosoftHeadCoordinateEncode);
            Assert.IsTrue(coordinate.Count() == 1);
        }

        [TestMethod]
        public void DecodeSingleCustomCoordinate()
        {
            var decoder = new Decoder();
            var coordinate = decoder.Decode<TestGeoCoordinate>(TestData.MicrosoftHeadCoordinateEncode);
            Assert.IsTrue(coordinate.Count() == 1);
        }

        public void DecodeThreeCoordinateAndCheckSecond()
        {

        }
    }
}