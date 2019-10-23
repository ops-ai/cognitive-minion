using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CognitiveMinion.Api.Extensions
{
    /// <summary>
    /// An Microsoft.AspNetCore.Mvc.ObjectResult that when executed performs content
    /// negotiation, formats the entity body, and will produce a Microsoft.AspNetCore.Http.StatusCodes.Status206PartialContent
    /// response if negotiation and formatting succeed.
    /// </summary>
    public class PartialObjectResult : ObjectResult
    {
        /// <summary>
        /// Initializes a new instance of the Microsoft.AspNetCore.Mvc.OkObjectResult class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public PartialObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status206PartialContent;
        }
    }
}
