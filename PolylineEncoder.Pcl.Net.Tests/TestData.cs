namespace PolylineEncoder.Pcl.Net.Tests
{
    public static class TestData
    {
        
        /// <summary>
        /// Extra info 
        /// https://developers.google.com/maps/documentation/utilities/polylineutility
        /// </summary>

        #region Coordinates

        public static TestGeoCoordinate AmsterdamCoordinate = new TestGeoCoordinate(52.3702160, 4.895168);
        public static TestGeoCoordinate AppleHeadCoordinate = new TestGeoCoordinate(37.3316760, -122.030189);
        public static TestGeoCoordinate MicrosofHeadCoordinate = new TestGeoCoordinate(37.4160740, -122.075624);
    
        #endregion

        #region Encodestrings

        public const string AmsterdamCoordinateEncode = @"{ps~Hya{\";
        public const string AppleHeadCoordinateEncode = @"_jzbFt_ygV";
        public const string MicrosoftHeadCoordinateEncode = @"myjcFr{ahV";

        #endregion

        #region Trips

        // ReSharper disable once IdentifierTypo
        // Duth word
        public const string TripAroundZwanenBurg =
        @"wns~Hwo{\JiBf@eF??PaBb@qA??zErFzB`CMfCQBmD_DgDuCWWX_CZ{@[We@hA[~CaA_Ae@lDqBgBUxAbF|E";

        #endregion


    }
}