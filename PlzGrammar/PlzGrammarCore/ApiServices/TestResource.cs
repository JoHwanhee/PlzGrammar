using Grapevine.Core.Interfaces.Server;
using Grapevine.Core.Server;
using Grapevine.Core.Server.Attributes;
using Grapevine.Core.Shared;

namespace PlzGrammarCore.ApiServices
{
    [RestResource]
    public class TestResource
    {
        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/inorder")]
        public IHttpContext MeFirst(IHttpContext context)
        {
            return context;
        }

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/inorder")]
        public IHttpContext MeSecond(IHttpContext context)
        {
            return context;
        }

        [RestRoute(HttpMethod = HttpMethod.GET, PathInfo = "/inorder")]
        public IHttpContext MeThird(IHttpContext context)
        {
            return context;
        }

        [RestRoute]
        public IHttpContext HelloWorld(IHttpContext context)
        {
            context.Response.SendResponse("Hello, world.");
            return context;
        }
    }
}