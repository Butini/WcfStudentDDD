using Autofac;
using WcfStudent.Domain.Entity;
using WcfStudent.Infrastructure.Utils.Contracts;
using WcfStudent.Infrastructure.Utils.Implementation;

namespace WcfStudent.Infrastructure.Repository.AutofacModules
{
    public class RepositoryModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SerilaceTxt>().As<ISerilace<Student>>();
            base.Load(builder);
        }
    }
}
