
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
    public class RatingService : IRatingAccess
    {
        List<BEReview> allRatings = new List<BEReview>();
        IRatingAccess mratingAccess;
        public RatingService(IRatingAccess ra)
        {
            mratingAccess = ra;
          //  allRatings = GetAllRatings();
        }

    
      

        public List<BEReview> GetAllRatings()
        
        {
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var filename = Path.Combine(basePath, "ratings.json");
            //string text = System.IO.File.ReadAllText(filename);
            using (StreamReader sr = new StreamReader(@filename))
            {
               string json = sr.ReadToEnd();
               List<BEReview> items = JsonConvert.DeserializeObject<List<BEReview>>(json);
               return items;

            }
          
          
            //List<BEReview> list = new List<BEReview>();
            //return list;

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
            SortedList<int,int> list2 = new SortedList<int,int>();
            foreach (BEReview b in list)
            {
                if (!list2.ContainsKey(b.Reviewer))
                {
                    int d = GetNumberOfReviewsFromReviewer(b.Reviewer);
                    list2.Add(b.Reviewer, d);
                }
            }

            
            var list3 = list2.OrderByDescending(x => x.Value).ToList();
            List<int> idslist = new List<int>();
            foreach(var v in list3)
            {
                idslist.Add(v.Key);
            }
            return idslist;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            var list = mratingAccess.GetAllRatings();
            var themovies = new List<int>();
            foreach (var review in list)
            {
                var movie = review.Movie;
                if(!themovies.Contains(movie))
                {
                    themovies.Add(movie);
                }
            }
            var sortedList = new SortedList<double, int>();
            for (int i = 0; i < themovies.Count; i++)
            {
                var movieID = themovies[i];
                var rate = GetAverageRateOfMovie(movieID);
                Console.WriteLine(rate);
                sortedList.Add(rate, movieID);
            }

            List<int> c = sortedList.Values.ToList();
            c.Reverse();
            List<int> theList = new List<int>();
            for (int i = 0; i < amount; i++)
            {
                
                theList.Add(c[i]);
            }
            
            return theList;

            //throw new Exception("not implemented");
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
