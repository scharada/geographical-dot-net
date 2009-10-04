using Projection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace TestGeographicalDotNet
{
    
    
    /// <summary>
    ///This is a test class for GoogleMapsAPIProjectionTest and is intended
    ///to contain all GoogleMapsAPIProjectionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GoogleMapsAPIProjectionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FromPixelToCoordinates
        ///</summary>
        [TestMethod()]
        public void FromPixelToCoordinatesTest()
        {
            var zoomLevel = 0d;
            var target = new GoogleMapsAPIProjection(zoomLevel);
            var pixel = new PointF(128f, 128f);
            PointF expected = new PointF(0f, 0f);
            var actual = target.FromPixelToCoordinates(pixel);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FromCoordinatesToPixel
        ///</summary>
        [TestMethod()]
        public void FromCoordinatesToPixelTest()
        {
            var zoomLevel = 0d;
            var target = new GoogleMapsAPIProjection(zoomLevel);
            var coordinates = new PointF(0f, 0f);
            var expected = new PointF(128f, 128f);
            var actual = target.FromCoordinatesToPixel(coordinates);
            Assert.AreEqual(expected, actual);
        }
    }
}
