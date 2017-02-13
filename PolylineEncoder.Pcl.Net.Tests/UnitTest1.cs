using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolylineEncoder.Pcl.Net.Utility;

namespace PolylineEncoder.Pcl.Net.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var utility = new PolylineUtility();
            var points = utility.Decode<TestGeoCoordinate>(@"_p~iF~ps|U_ulLnnqC_mqNvxq`@").ToList();

            string a = "b";
        }
    }
}
