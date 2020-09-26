using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movie_Rating_Correctness.BE;

namespace Movie_Rating_Correctness.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestGetAll()
        {
            //test
            RatingService rs = new RatingService();
            List<BEReview> actualResult = rs.GetAllRatings();

            Assert.IsTrue(actualResult.Count > 1);
        }


    }

}
