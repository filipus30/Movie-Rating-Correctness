using System;
using System.Collections.Generic;
using Movie_Rating_Correctness.BE;

namespace Movie_Rating_Correctness
{
    public interface IRatingAccess
    {
        public List<BEReview> GetAllRatings();
    }
}
