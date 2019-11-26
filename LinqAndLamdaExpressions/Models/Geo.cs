using System;

namespace LinqAndLamdaExpressions.Models
{
    public class Geo
    {
        public double Lat { get; set; }

        public double Lng { get; set; }

        internal bool ContainsKey(string v)
        {
            throw new NotImplementedException();
        }
    }
}