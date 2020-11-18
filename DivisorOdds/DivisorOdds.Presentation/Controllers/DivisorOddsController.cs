using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DivisorOdds.CrossCutting.DefaultResponses;
using DivisorOdds.Domain.Dtos.Request;
using DivisorOdds.Domain.Handlers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DivisorOdds.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisorOddsController : ControllerBase
    {
        private readonly INumberHandler _numberHandler;
        public DivisorOddsController(INumberHandler numberHandler)
        {
            _numberHandler = numberHandler;
        }
        // GET: api/DivisorOdds
        [HttpGet("divisors")]
        public IActionResult Get([FromQuery] OddDivisorsRequest request)
        {
            if(request == null)
            {
                return StatusCode(400, new GenericResult() { success = false, message = "Requisição incorreta", data = null });
            }

             var result = _numberHandler.CalculateOddDivisors(request);
            if (result.success)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400, result);
            }
        }
    }
}
