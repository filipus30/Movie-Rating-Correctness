
using System;
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
            allRatings = GetAllRatings();
        }


        public List<BEReview> GetAllRatings()
        {


            //var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //var filename = Path.Combine(documents, "ratings.json");
            //var text = System.IO.File.ReadAllText(filename);
            //using (StreamReader sr = new StreamReader(text))
            //{
            //    string json = sr.ReadToEnd();
            //    List<BEReview> items = JsonConvert.DeserializeObject<List<BEReview>>(json);

            //    return items;

            //}
            List<BEReview> list = new List<BEReview>();
            return list;

        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {

          return  allRatings.FindAll(x => x.Reviewer == reviewer).Count;

        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
           var list = allRatings.FindAll(x => x.Reviewer == reviewer);
            double sum = 0;
            foreach(BEReview b in list)
            {
                sum += b.Grade;
            }
            return sum / list.Count;

        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            var list = allRatings.FindAll(x => x.Reviewer == reviewer);
            var list2 = list.FindAll(x => x.Grade == rate);
            return list2.Count;
        }


        public int GetNumberOfReviews(int movie)
        {
            var list = allRatings.FindAll(x => x.Movie == movie);
            return list.Count;
        }


        public double GetAverageRateOfMovie(int movie)
        {
            var list = allRatings.FindAll(x => x.Movie == movie);
            double sum = 0;
            foreach (BEReview b in list)
            {
                sum += b.Grade;
            }
            return sum / list.Count;
        }


        public int GetNumberOfRates(int movie, int rate)
        {
            var list = allRatings.FindAll(x => x.Movie == movie);
            var list2 = list.FindAll(x => x.Grade == rate);
            return list2.Count;
        }


        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
           var list = allRatings.OrderBy(x => x.Grade);
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
            var list = allRatings.OrderBy(x => x.Reviewer);
            var list2 = list.Take(5);
            List<int> idslist = new List<int>();
            foreach (BEReview b in list2)
            {
                idslist.Add(b.Movie);
            }
            return idslist;

        }

        public List<int> GetTopRatedMovies(int amount)
        {

            throw new Exception("not implemented");
        }


        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            var list = allRatings.FindAll(x => x.Reviewer == reviewer);
            var list2 = list.OrderBy(x => x.Grade).ThenBy(x => x.Date);
            List<int> list3 = new List<int>();
            foreach(var v in list2)
            {
                list3.Add(v.Movie);
            }
            return list3;

        }

        public List<int> GetReviewersByMovie(int movie)
        {
            var list = allRatings.FindAll(x => x.Movie == movie);
            var list2 = list.OrderBy(x => x.Grade).ThenBy(x => x.Date);
            List<int> list3 = new List<int>();
            foreach (var v in list2)
            {
                list3.Add(v.Movie);
            }
            return list3;

        }






    }
}
