using CognitiveMinion.Api.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveMinion.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Creates an Microsoft.AspNetCore.Mvc.OkObjectResult object that produces an PartialContent (206) response.
        /// </summary>
        /// <param name="value">The content value to format in the entity body.</param>
        /// <returns>The created Microsoft.AspNetCore.Mvc.PartialObjectResult for the response.</returns>
        [NonAction]
        public PartialObjectResult Partial(object value)
        {
            return new PartialObjectResult(value);
        }
    }
}
