using DivisorOdds.CrossCutting.DefaultResponses;
using DivisorOdds.Domain.Dtos.Request;
using System.Threading.Tasks;

namespace DivisorOdds.Domain.Handlers.Interfaces
{
    public interface INumberHandler
    {
        GenericResult CalculateOddDivisors(OddDivisorsRequest request);
    }
}
