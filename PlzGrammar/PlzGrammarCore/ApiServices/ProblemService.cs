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
            

            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.ContentType = ContentType.JSON;
            context.Response.ContentEncoding = Encoding.UTF8;
            
            context.Response.SendResponse(reponseString, Encoding.UTF8);
            return context;
        }
    }
}