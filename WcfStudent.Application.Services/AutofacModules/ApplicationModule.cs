using Autofac;
using WcfStudent.Domain.Entity;
using WcfStudent.Domain.StudentMain.Contracts.Repository;
using WcfStudent.Infrastructure.Repository.AutofacModules;
using WcfStudent.Infrastructure.Repository.Implementation;

namespace WcfStudent.Application.Services.AutofacModules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModules());
            builder.RegisterType<StudentRepository>().As<IStudentRepository<Student>>();
            base.Load(builder);
        }
    }
}
