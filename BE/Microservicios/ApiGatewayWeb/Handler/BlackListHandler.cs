using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGatewayWeb.Handler
{
    public class BlackListHandler : DelegatingHandler
    {
        public IWebHostEnvironment Environment { get; }
        public BlackListHandler(IWebHostEnvironment environment)
        {
            Environment = environment;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            if (request.Headers.Authorization != null)
            {
                var myHeader = request.Headers.Authorization.Parameter;

                var urlApi = request.RequestUri.AbsolutePath;
                
                if (myHeader != null)
                    return await base.SendAsync(request, cancellationToken);

                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);

                return await Task.FromResult<HttpResponseMessage>(response);
            }
            else
                return await base.SendAsync(request, cancellationToken);
        }
    }
}
