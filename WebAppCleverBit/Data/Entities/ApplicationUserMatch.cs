namespace WebAppCleverBit.Data.Entities
{
    public class ApplicationUserMatch
    {
        public int ApplicationUserMatchID { get; set; }

        public int Number { get; set; }

        public int MatchID { get; set; }
        public Match Match { get; set; }

        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
