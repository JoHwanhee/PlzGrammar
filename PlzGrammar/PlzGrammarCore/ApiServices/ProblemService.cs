using System.Text;
using Grapevine.Core.Interfaces.Server;
using Grapevine.Core.Server;
using Grapevine.Core.Server.Attributes;
using Grapevine.Core.Shared;

namespace PlzGrammarCore.ApiServices
{
    [RestResource]
    public class ProblemService
    {
        private ProblemManager _problemManager = ProblemManager.Instance;

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/problems/default")]
        public IHttpContext MeFirst(IHttpContext context)
        {
            var defaultProblem = _problemManager.GetProblem(-1).ToJson();
            var reponseString = defaultProblem.ToString();
            var buffer = context.Request.ContentEncoding.GetBytes(reponseString);
            var length = buffer.Length;

            context.Response.ContentType = ContentType.TEXT;
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.ContentLength64 = length;
            context.Response.SendResponse(HttpStatusCode.Ok, reponseString);
            return context;
        }
    }
}