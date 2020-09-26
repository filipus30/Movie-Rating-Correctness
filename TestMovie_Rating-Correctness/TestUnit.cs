using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movie_Rating_Correctness;
using Movie_Rating_Correctness.BE;

namespace Test_Movie_Rating_Correctness.Tests
{
    [TestClass]
    public class TestUnit
    {
        [TestMethod]
        public void TestGetAllRatings()
        {
            RatingService rs = new RatingService();
            List<BEReview> actualResult = rs.GetAllRatings();
            Assert.IsTrue(actualResult.Count > 1);
        }
    }
}
