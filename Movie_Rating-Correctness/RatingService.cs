
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Movie_Rating_Correctness.BE;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Movie_Rating_Correctness
{
    public class RatingService
    {
        List<BEReview> allRatings = new List<BEReview>();
        IRatingAccess mratingAccess;
        public RatingService(IRatingAccess ra)
        {
            mratingAccess = ra;           
        }
      
   

        

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {

          return  mratingAccess.GetAllRatings().FindAll(x => x.Reviewer == reviewer).Count;

        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
           var list = mratingAccess.GetAllRatings().FindAll(x => x.Reviewer == reviewer);
            double sum = 0;
            foreach(BEReview b in list)
            {
                sum += b.Grade;
            }
            return sum / list.Count;

        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            var list = mratingAccess.GetAllRatings().FindAll(x => x.Reviewer == reviewer);
            var list2 = list.FindAll(x => x.Grade == rate);
            return list2.Count;
        }


        public int GetNumberOfReviews(int movie)
        {
            var list = mratingAccess.GetAllRatings().FindAll(x => x.Movie == movie);
            return list.Count;
        }


        public double GetAverageRateOfMovie(int movie)
        {
            var list = mratingAccess.GetAllRatings().FindAll(x => x.Movie == movie);
            double sum = 0;
            foreach (BEReview b in list)
            {
                sum += b.Grade;
            }
            return sum / list.Count;
        }


        public int GetNumberOfRates(int movie, int rate)
        {
            var list = mratingAccess.GetAllRatings().FindAll(x => x.Movie == movie);
            var list2 = list.FindAll(x => x.Grade == rate);
            return list2.Count;
        }


        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
           var list = mratingAccess.GetAllRatings().OrderByDescending(x => x.Grade);
            var list2 = list.Take(5);
            List<int> idslist = new List<int>();
            foreach(BEReview b in list2)
            {
                idslist.Add(b.Movie);
            }
            return idslist;
        }

        public List<int> GetMostProductiveReviewers()

        { 

            var list = mratingAccess.GetAllRatings();
            var list2 = list.GroupBy(g => g.Reviewer)
                .OrderByDescending(group => group.Count())
                .SelectMany(g => g);
            var list3 = list2.Select(r => r.Reviewer).Distinct().ToList();
            return list3;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            var list = mratingAccess.GetAllRatings();
            var list2 = from r in list
                        group r by r.Movie into playerGroup
                        select new
                        {
                            Movie = playerGroup.Key,
                            Grade = playerGroup.Average(x => x.Grade),
                        };
            var list3 = list2.OrderByDescending(x => x.Grade)
                .Take(amount)
                .Select(m => m.Movie)
                .Distinct()
                .ToList();

            return list3;
        }


        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            var list = mratingAccess.GetAllRatings().FindAll(x => x.Reviewer == reviewer);
            var list2 = list.OrderByDescending(x => x.Grade).ThenByDescending(x => x.Date);
            List<int> list3 = new List<int>();
            foreach(var v in list2)
            {
                list3.Add(v.Movie);
            }
            return list3;

        }

        public List<int> GetReviewersByMovie(int movie)
        {
            var list = mratingAccess.GetAllRatings().FindAll(x => x.Movie == movie);
            var list2 = list.OrderByDescending(x => x.Grade).ThenByDescending(x => x.Date);
            List<int> list3 = new List<int>();
            foreach (var v in list2)
            {
                list3.Add(v.Movie);
            }
            return list3;

        }






    }
}
