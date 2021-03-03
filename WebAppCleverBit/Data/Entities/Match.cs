using System;
using System.Collections.Generic;

namespace WebAppCleverBit.Data.Entities
{
    public class Match
    {
        public int MatchID { get; set; }

        public DateTime ExpiryDate { get; set; }

        public ICollection<ApplicationUserMatch> ApplicationUserMatches { get; set; }
    }
}
