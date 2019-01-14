using System;
using Microsoft.Extensions.DependencyInjection;
using NCS.DSS.Anonymise.Cosmos.Helper;
using NCS.DSS.Anonymise.Helpers;
using NCS.DSS.Anonymise.PostAnonymiseHttpTrigger.Service;


namespace NCS.DSS.Anonymise.Ioc
{
    public class RegisterServiceProvider
    {
        public IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddTransient<IPostAnonymiseHttpTriggerService, PostAnonymiseHttpTriggerService>();
            services.AddTransient<IResourceHelper, ResourceHelper>();
            services.AddTransient<IHttpRequestMessageHelper, HttpRequestMessageHelper>();
            return services.BuildServiceProvider(true);
        }
    }
}
