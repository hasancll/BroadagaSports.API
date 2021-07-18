using BroadagaSports.API.Logging.Abstract;
using BroadagaSports.API.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BroadagaSports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchAllListController : Controller
    {
        private readonly IMatchService _matchService;
        private readonly IMatchLogger _matchLogger;
        public MatchAllListController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMatchAsync()
        {
            try
            {
                var date = DateTime.Now.Date;
                var request = Helper.RequestHelper.HttpRequestMessage(HttpMethod.Get, "https://s0-sports-data-api.broadage.com/soccer/match/list?date=" + date);
                var response = Helper.RequestHelper.GetHttpResponseSingleAsync<List<DTOs.MatchDTO>>(request).GetAwaiter().GetResult();
                return Ok(response);
            }
            catch(Exception e)
            {
                _matchLogger.Error(e.Message);
                return Ok();
            } 
        }
    }
}
