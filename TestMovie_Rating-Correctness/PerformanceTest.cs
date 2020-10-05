using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movie_Rating_Correctness;
using Movie_Rating_Correctness.BE;

namespace PerformanceTest.Tests
{
    [TestClass]
    public class PerformanceTest
    {

        public static IRatingAccess ira;
        public static RatingService rs;

        [ClassInitialize]
        public static void Initalizer(TestContext context)
        {
            ira = new DataAccess();
            rs = new RatingService(ira);

        }

        [TestMethod]
        [Timeout(4000)]
        public void TestGetNumberOfReviewsFromReviewer()
        {
            rs.GetNumberOfReviewsFromReviewer(1);
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestGetAverageRateFromReviewer()
        {
            rs.GetAverageRateFromReviewer(1);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetNumberOfRatesByReviewer()
        {
            rs.GetNumberOfRatesByReviewer(1, 5);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetNumberOfReviews()
        {
            rs.GetNumberOfReviews(1488844);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetAverageRateOfMovie()
        {
            rs.GetAverageRateOfMovie(1488844);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetNumberOfRates()
        {
            rs.GetNumberOfRates(1488844, 4);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetMoviesWithHighestNumberOfTopRates()
        {
            rs.GetMoviesWithHighestNumberOfTopRates();
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetMostProductiveReviewers()
        {
            rs.GetMostProductiveReviewers();
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetTopRatedMovies()
        {
            rs.GetTopRatedMovies(3);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetTopMoviesByReviewer()
        {
            rs.GetTopMoviesByReviewer(1);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetReviewersByMovie()
        {
            rs.GetReviewersByMovie(1488844);
        }

    }
}
