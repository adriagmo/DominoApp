using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dominoes.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;
        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }
    
        // POST api/<GameController>
      
        [HttpPost("[action]")]
        public ActionResult GameStart([FromBody] GameDtoList request)
        {
            try
            {
                /// Validate request is not null
                if (request == null) return BadRequest();
                /// Count pairs  to apply business rules
                var pairsCount = request.Pairs.Count();
                var messageError = _gameService.ValidateNumberPairs(pairsCount);
                /// Show message error
                if (!string.IsNullOrEmpty(messageError))
                    return BadRequest(messageError);
                /// method that sets up the pairs
                var results = _gameService.ListPairs(request.Pairs);

                /// Validate first and last number equals
                if (results.First().N1 != results.Last().N2)
                {
                    return BadRequest($"Cadena resultado no es válida, cambie la parejas ");
                }
                /// Format results
                var res = from a in results
                          select String.Format("[{0}:{1}]", a.N1, a.N2);

                return Ok(JsonConvert.SerializeObject(res));
            }
            catch (System.Exception e)
            {
                /// write exception events server
                _logger.LogError($"Se ha generado una excepcion {e.Message} metodo GameStart");

                return BadRequest($"Se ha generado una excepcion {e.Message} metodo GameStart");
            }
           
        }

    }
}
