using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using NCS.DSS.Anonymise.Cosmos.Helper;
using NCS.DSS.Anonymise.Helpers;
using NCS.DSS.Anonymise.Ioc;
using NCS.DSS.Anonymise.PostAnonymiseHttpTrigger.Service;

namespace NCS.DSS.Anonymise.PostAnonymiseHttpTrigger.Function
{
    public static class PostAnonymiseFunction
    {

        [FunctionName("Anonymise_with_options")]
        public static async Task<HttpResponseMessage> RunO([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Anonymise/Anonymise_options")]HttpRequestMessage req, ILogger log,
           [Inject]IResourceHelper resourceHelper,
           [Inject]IHttpRequestMessageHelper httpRequestMessageHelper,
           [Inject]IPostAnonymiseHttpTriggerService AnonymisePostService)
        {
            Models.RequestOptions rOpts = req.Content.ReadAsAsync<Models.RequestOptions>().GetAwaiter().GetResult();

            if ( !   (req.Headers.Contains("SourceEndPoint")
                    && req.Headers.Contains("SourceKey")
                    && req.Headers.Contains("TargetEndPoint")
                    && req.Headers.Contains("TargetKey"))
                    )
                return HttpResponseMessageHelper.BadRequest();

            rOpts.SourceEndPoint = req.Headers.GetValues("SourceEndPoint").FirstOrDefault();
            rOpts.SourceKey = req.Headers.GetValues("SourceKey").FirstOrDefault();
            rOpts.TargetEndPoint = req.Headers.GetValues("TargetEndPoint").FirstOrDefault();
            rOpts.TargetKey = req.Headers.GetValues("TargetKey").FirstOrDefault();
            await AnonymisePostService.Anonymise(rOpts);

            return HttpResponseMessageHelper.Created("Ok");

        }

        [FunctionName("Anonymise_TEST_to_AT")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Anonymise/Test-to-AT")]HttpRequestMessage req, ILogger log,
            [Inject]IResourceHelper resourceHelper,
            [Inject]IHttpRequestMessageHelper httpRequestMessageHelper,
            [Inject]IPostAnonymiseHttpTriggerService AnonymisePostService)
        {

            await AnonymisePostService.Anonymise();

            return HttpResponseMessageHelper.Created("Ok");

        }


        [FunctionName("Anonymise_PRE-PROD_to_TEST")]
        public static async Task<HttpResponseMessage> Run2([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Anonymise/Pre-to-Test")]HttpRequestMessage req, ILogger log,
            [Inject]IResourceHelper resourceHelper,
            [Inject]IHttpRequestMessageHelper httpRequestMessageHelper,
            [Inject]IPostAnonymiseHttpTriggerService AnonymisePostService)
        {

            await AnonymisePostService.Anonymise();

            return HttpResponseMessageHelper.Created("Ok");

        }


        [FunctionName("Anonymise_PRODUCTION_to_PRE-PROD")]
        public static async Task<HttpResponseMessage> Run3([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Anonymise/Prod-to-Pre")]HttpRequestMessage req, ILogger log,
        [Inject]IResourceHelper resourceHelper,
        [Inject]IHttpRequestMessageHelper httpRequestMessageHelper,
        [Inject]IPostAnonymiseHttpTriggerService AnonymisePostService)
        {

            await AnonymisePostService.Anonymise();

            return HttpResponseMessageHelper.Created("Ok");

        }


    }
}
