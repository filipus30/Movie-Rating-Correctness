
using System;
using System.Collections.Generic;
using System.IO;
using Movie_Rating_Correctness.BE;
using Newtonsoft.Json;

namespace Movie_Rating_Correctness
{
    public class RatingService : IRatingAccess
    {
        public List<BEReview> GetAllRatings()
        {
            string filePath = System.IO.Path.GetFullPath("ratings.json");
          
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = sr.ReadToEnd();
                List<BEReview> items = JsonConvert.DeserializeObject<List<BEReview>>(json);
                
                return items;

            }



            
        }
    }
}
