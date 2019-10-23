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
    public class RequestsController : BaseController
    {
        private readonly ILogger<RequestsController> _logger;
        private readonly IMinionRequestStore _requestStore;

        public RequestsController(ILogger<RequestsController> logger, IMinionRequestStore requestStore)
        {
            _logger = logger;
            _requestStore = requestStore;
        }

        /// <summary>
        /// Returns requests submitted and their status
        /// </summary>
        /// <param name="range">Result range to return. Format: 0-19 (result index from - result index to)</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> List(string range = "0-19", CancellationToken cancellationToken = default)
        {
            try
            {
                //TODO: investigate if stream/id based paging is a better fit since requests get added fast
                var (from, to, _) = range.Split('-').Select(int.Parse).ToList();

                var requests = await _requestStore.GetRequests(from, to - from + 1, cancellationToken);

                return Partial(requests.Select(t => new MinionRequestInfoModel
                {
                    DateRequestedUtc = t.DateRequestedUtc,
                    Id = t.Id.Split('/').Last(),
                    Request = t.Request,
                    Status = t.Status
                }));
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
            try
            {
                var request = await _requestStore.GetRequest(id, cancellationToken);
                if (request == null)
                {
                    _logger.LogWarning($"Request {id} was not found");
                    return NotFound();
                }

                var model = new MinionRequestInfoModel
                {
                    DateRequestedUtc = request.DateRequestedUtc,
                    Id = request.Id.Split("/").Last(),
                    Request = request.Request,
                    Status = request.Status
                };

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting request {id} by id");
                throw;
            }
        }

        /// <summary>
        /// Submit a new request
        /// </summary>
        /// <param name="model">Request information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]MinionRequestModel model, CancellationToken cancellationToken)
        {
            try
            {
                var id = await _requestStore.StoreRequest(new MinionRequest { Request = model.Request }, cancellationToken);
                
                //send to IntentResolverService which will update in db once processed, then send for approval

                return Accepted(Url.Action(nameof(Get), nameof(RequestsController), new { id }));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error receiving request");
                throw;
            }
        }
    }
}
