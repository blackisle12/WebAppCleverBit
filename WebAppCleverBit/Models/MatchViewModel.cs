using System;
using System.Collections.Generic;

namespace WebAppCleverBit.Models
{
    public class MatchViewModel
    {
        public int MatchID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool HasPlayed { get; set; }
        public int Number { get; set; }
        public IList<MatchVoteViewModel> MatchVotes { get; set; }
    }

    public class MatchVoteViewModel
    {
        public string Username { get; set; }
        public int Number { get; set; }
    }
}
