using Autofac;
using Autofac.Integration.Wcf;

using System;
using WcfStudent.Distributed.WebServices.Configuration;

namespace WcfStudent.Distributed.WebServices
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            IContainer container = AutofacConfiguration.Configure();
            AutofacHostFactory.Container = container;
        }
    }
}