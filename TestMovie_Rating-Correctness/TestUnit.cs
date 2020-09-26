using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Movie_Rating_Correctness;
using Movie_Rating_Correctness.BE;

namespace Test_Movie_Rating_Correctness.Tests
{
    [TestClass]
    public class TestUnit
    {
       // [TestMethod]
       // public void TestGetAllRatings()
       // {
           // RatingService rs = new RatingService();
          //  List<BEReview> actualResult = rs.GetAllRatings();
          //  Assert.IsTrue(actualResult.Count > 1);
      //  }

        [TestMethod]
        public void TestGetNumberOfReviewsFromReviewer()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>{ new BEReview { Movie = 123, Grade = 7, Reviewer = 20, Date = "06-06-2009" },
                                       new BEReview { Movie = 120, Grade = 3, Reviewer = 50, Date = "08-06-2009"  } };
           
        
            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);

            RatingService rService = new RatingService(m.Object);


           int actualResult = rService.GetNumberOfReviewsFromReviewer(20);
            m.Verify(m => m.GetAllRatings(), Times.Once);
           Console.WriteLine(returnValue[0].Reviewer);
            Assert.IsTrue(actualResult == 1);
           

        }
        


    }
}
