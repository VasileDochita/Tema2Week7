namespace LinqAndLamdaExpressions.Models
{
    public class Address
    {
        public string Street { get; set; }

        public string Suite { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public Geo Geo { get; set; }
        public User User { get; internal set; }
        public object Posts { get; internal set; }
    }
}