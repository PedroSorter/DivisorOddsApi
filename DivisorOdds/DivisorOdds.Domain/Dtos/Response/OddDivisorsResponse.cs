using System;
using System.Collections.Generic;
using System.Text;

namespace DivisorOdds.Domain.Dtos.Response
{
    public sealed class OddDivisorsResponse
    {
        public int number { get; set; }
        public IEnumerable<Tuple<bool, int>> oddDivisorsList { get; set; }
    }
}
