using System;
using System.Collections.Generic;
using System.IO;
using Movie_Rating_Correctness.BE;
using Newtonsoft.Json;

namespace Movie_Rating_Correctness
{
    public class DataAccess : IRatingAccess
    {
        public List<BEReview> list = new List<BEReview>();

        public DataAccess()
        {
            GetAll();
        }

        public List<BEReview> GetAllRatings()
        {
            return list;
        }



        public void GetAll()
        {
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            var filename = Path.Combine(basePath, "ratings.json");
            //string text = System.IO.File.ReadAllText(filename);
            using (StreamReader sr = new StreamReader(@filename))
            {
                string json = sr.ReadToEnd();
                List<BEReview> items = JsonConvert.DeserializeObject<List<BEReview>>(json);
                
                list = items;

            }

        }
    }
}
