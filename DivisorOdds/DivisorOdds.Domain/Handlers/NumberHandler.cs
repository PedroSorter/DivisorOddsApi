using AutoMapper;
using DivisorOdds.CrossCutting.DefaultResponses;
using DivisorOdds.Domain.Dtos.Request;
using DivisorOdds.Domain.Dtos.Response;
using DivisorOdds.Domain.Entities;
using DivisorOdds.Domain.Handlers.Interfaces;
using System;

namespace DivisorOdds.Domain.Handlers
{
    public class NumberHandler : INumberHandler
    {
        private readonly IMapper _mapper;
        //Método síncrono pelo tipo da operação//
        public NumberHandler(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public GenericResult CalculateOddDivisors(OddDivisorsRequest request)
        {
            var oddDivisor = new NumberEntity(request.number);
            if (oddDivisor.Invalid)
            {
                return new GenericResult() { success = false, message = "Erro ao calcular os divisores.", data = oddDivisor.Notifications };
            }

            return new GenericResult() { success = true, message = "Divisores calculados com sucesso.", data = _mapper.Map<OddDivisorsResponse>(oddDivisor)};
        }
    }
}
