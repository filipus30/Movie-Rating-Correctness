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
        
       
        

        [TestMethod]
        public void TestGetNumberOfReviewsFromReviewer()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>{ new BEReview { Movie = 123, Grade = 7, Reviewer = 20, Date = "06-06-2009" },
                                       new BEReview { Movie = 120, Grade = 3, Reviewer = 50, Date = "08-06-2009"  } };

           m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
           //m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            int actualResult = rService.GetNumberOfReviewsFromReviewer(20);
            Console.WriteLine(actualResult);
            Assert.IsTrue(actualResult == 1);
         
        }


        [TestMethod]
        public void  TestGetAverageRateFromReviewer()

        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 7, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 120, Grade = 3, Reviewer = 50, Date = "08-06-2009"},
                new BEReview { Movie = 156, Grade = 7, Reviewer = 50, Date = "09-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
            //  m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            double actualResult = rService.GetAverageRateFromReviewer(50);
            m.Verify(m => m.GetAllRatings(), Times.Once);
            Assert.IsTrue(actualResult == 5);

        }
        [TestMethod]
        public void TestGetNumberOfRatesByReviewer()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 7, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 120, Grade = 7, Reviewer = 50, Date = "08-06-2009"},
                new BEReview { Movie = 156, Grade = 7, Reviewer = 50, Date = "09-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
            //  m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            double actualResult = rService.GetNumberOfRatesByReviewer(50, 7);
            m.Verify(m => m.GetAllRatings(), Times.Once);
            Assert.IsTrue(actualResult == 2);

        }

        [TestMethod]
        public void TestGetNumberOfReviews()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 7, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 120, Grade = 5, Reviewer = 50, Date = "08-06-2009"},
                new BEReview { Movie = 120, Grade = 7, Reviewer = 57, Date = "09-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
            //  m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            double actualResult = rService.GetNumberOfReviews(120);
            m.Verify(m => m.GetAllRatings(), Times.Once);
            Assert.IsTrue(actualResult == 2);

        }
        [TestMethod]
        public void TestGetAverageRateOfMovie()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 7, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 120, Grade = 3, Reviewer = 50, Date = "08-06-2009"},
                new BEReview { Movie = 120, Grade = 7, Reviewer = 57, Date = "09-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
            //  m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            double actualResult = rService.GetAverageRateOfMovie(120);
            m.Verify(m => m.GetAllRatings(), Times.Once);
            Assert.IsTrue(actualResult == 5);
        }

        [TestMethod]
        public void TestGetNumberOfRates()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 7, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 120, Grade = 3, Reviewer = 50, Date = "08-06-2009"},
                new BEReview { Movie = 120, Grade = 7, Reviewer = 57, Date = "09-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
            //  m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            double actualResult = rService.GetNumberOfRates(120,7);
            m.Verify(m => m.GetAllRatings(), Times.Once);
            Assert.IsTrue(actualResult == 1);

        }

        [TestMethod]
        public void TestGetMoviesWithHighestNumberOfTopRates()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 7, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 124, Grade = 3, Reviewer = 50, Date = "08-06-2009"},
                new BEReview { Movie = 120, Grade = 8, Reviewer = 52, Date = "09-07-2000"},
                new BEReview { Movie = 129, Grade = 9, Reviewer = 54, Date = "09-07-2000"},
                new BEReview { Movie = 125, Grade = 6, Reviewer = 57, Date = "09-07-2000"},
                new BEReview { Movie = 120, Grade = 5, Reviewer = 51, Date = "09-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
            //  m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            List<int> actualResult = rService.GetMoviesWithHighestNumberOfTopRates();
            m.Verify(m => m.GetAllRatings(), Times.Once);
            Assert.IsTrue(actualResult.Count == 5);
            Assert.IsTrue(actualResult[0] == returnValue[3].Movie);
            Assert.IsTrue(actualResult[1] == returnValue[2].Movie);
            Assert.IsTrue(actualResult[2] == returnValue[0].Movie);
            Assert.IsTrue(actualResult[3] == returnValue[4].Movie);
            Assert.IsTrue(actualResult[4] == returnValue[5].Movie);

        }

        [TestMethod]
        public void TestGetMostProductiveReviewers()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 7, Reviewer = 60, Date = "06-06-2009"},
                new BEReview { Movie = 124, Grade = 3, Reviewer = 54, Date = "08-06-2009"},
                new BEReview { Movie = 120, Grade = 8, Reviewer = 52, Date = "09-07-2000"},
                new BEReview { Movie = 129, Grade = 9, Reviewer = 54, Date = "09-07-2000"},
                new BEReview { Movie = 125, Grade = 6, Reviewer = 52, Date = "09-07-2000"},
                new BEReview { Movie = 120, Grade = 5, Reviewer = 54, Date = "09-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
             // m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());

            List<int> actualResult = rService.GetMostProductiveReviewers();
            Console.WriteLine("ASASASAS" + actualResult[0]);
            Console.WriteLine("ASASASAS" + actualResult[1]);


            Assert.IsTrue(actualResult.Count == 3);
            Assert.IsTrue(actualResult[0] == returnValue[1].Reviewer);
            Assert.IsTrue(actualResult[1] == returnValue[2].Reviewer);
            Assert.IsTrue(actualResult[2] == returnValue[0].Reviewer);

        }
        [TestMethod]
        public void TestGetTopRatedMovies()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 4, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 124, Grade = 3, Reviewer = 54, Date = "08-06-2009"},
                new BEReview { Movie = 120, Grade = 8, Reviewer = 52, Date = "09-07-2000"},
                new BEReview { Movie = 129, Grade = 9, Reviewer = 54, Date = "09-07-2000"},
                new BEReview { Movie = 125, Grade = 6, Reviewer = 52, Date = "09-07-2000"},
                new BEReview { Movie = 120, Grade = 5, Reviewer = 52, Date = "09-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
          //  m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            List<int> actualResult = rService.GetTopRatedMovies(3);
            Assert.IsTrue(actualResult.Count == 3);
            Assert.IsTrue(actualResult[0] == returnValue[3].Movie);
            Assert.IsTrue(actualResult[1] == returnValue[2].Movie);
            Assert.IsTrue(actualResult[2] == returnValue[4].Movie);
        }

        [TestMethod]
        public void TestGetTopMoviesByReviewer()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 8, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 121, Grade = 3, Reviewer = 54, Date = "08-06-2009"},
                new BEReview { Movie = 126, Grade = 8, Reviewer = 52, Date = "01-07-2000"},
                new BEReview { Movie = 129, Grade = 9, Reviewer = 54, Date = "02-07-2000"},
                new BEReview { Movie = 125, Grade = 6, Reviewer = 52, Date = "09-07-2000"},
                new BEReview { Movie = 120, Grade = 6, Reviewer = 52, Date = "03-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
            //  m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            List<int> actualResult = rService.GetTopMoviesByReviewer(52);
            Assert.IsTrue(actualResult.Count == 3);
            Assert.IsTrue(actualResult[0] == returnValue[2].Movie);
            Assert.IsTrue(actualResult[1] == returnValue[4].Movie);
            Assert.IsTrue(actualResult[2] == returnValue[5].Movie);



        }

        [TestMethod]
        public void TestGetReviewersByMovie()
        {
            Mock<IRatingAccess> m = new Mock<IRatingAccess>();

            List<BEReview> returnValue = new List<BEReview>
            {
                new BEReview { Movie = 123, Grade = 8, Reviewer = 20, Date = "06-06-2009"},
                new BEReview { Movie = 121, Grade = 3, Reviewer = 54, Date = "08-06-2009"},
                new BEReview { Movie = 126, Grade = 8, Reviewer = 52, Date = "01-07-2000"},
                new BEReview { Movie = 120, Grade = 9, Reviewer = 54, Date = "02-07-2000"},
                new BEReview { Movie = 125, Grade = 6, Reviewer = 52, Date = "09-07-2000"},
                new BEReview { Movie = 120, Grade = 6, Reviewer = 52, Date = "03-07-2000"}
            };

            m.Setup(m => m.GetAllRatings()).Returns(() => returnValue);
            RatingService rService = new RatingService(m.Object);
           // m.Setup(m => m.GetAllRatings()).Returns(() => rService.GetAllRatings());
            List<int> actualResult = rService.GetReviewersByMovie(120);
            Assert.IsTrue(actualResult.Count == 2);
            Assert.IsTrue(actualResult[0] == returnValue[3].Movie);
            Assert.IsTrue(actualResult[1] == returnValue[5].Movie);
        }


    }
}
