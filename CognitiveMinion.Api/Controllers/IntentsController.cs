using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CognitiveMinion.Api.Extensions;
using CognitiveMinion.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CognitiveMinion.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class IntentsController : BaseController
    {
        private readonly ILogger<RequestsController> _logger;
        private readonly IMinionIntentsStore _intentsStore;

        public IntentsController(ILogger<RequestsController> logger, IMinionIntentsStore intentsStore)
        {
            _logger = logger;
            _intentsStore = intentsStore;
        }

        /// <summary>
        /// Returns a list of known intents
        /// </summary>
        /// <param name="range">Result range to return. Format: 0-19 (result index from - result index to)</param>
        /// <returns></returns>
        [Authorize(Policy = "IntentOwners")]
        [HttpGet]
        public async Task<ActionResult> List(string range = "0-19", CancellationToken cancellationToken = default)
        {
            try
            {
                var (from, to, _) = range.Split('-').Select(int.Parse).ToList();

                var requests = await _intentsStore.GetIntents(from, to - from + 1, cancellationToken);

                return Partial(requests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list of requests");
                throw;
            }
        }

        /// <summary>
        /// Returns a request by Id
        /// </summary>
        /// <param name="id">Id of the request</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Submit a new request
        /// </summary>
        /// <param name="model">Request information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]MinionRequestModel model, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
