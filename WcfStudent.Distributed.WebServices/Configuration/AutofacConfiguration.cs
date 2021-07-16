using Autofac;
using WcfStudent.Application.Services.AutofacModules;

namespace WcfStudent.Distributed.WebServices.Configuration
{
    public class AutofacConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ApplicationModule());

            return builder.Build();
        }
    }
}