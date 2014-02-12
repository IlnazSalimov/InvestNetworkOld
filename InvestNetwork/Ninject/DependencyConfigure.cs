using InvestNetwork.Core;
using InvestNetwork.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvestNetwork.Ninject
{
    public class DependencyConfigure
    {
        public static void Initialize()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IDataContext>().To<InvestNetworkEntities>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<ICityRepository>().To<CityRepository>();
            kernel.Bind<IProjectRepository>().To<ProjectRepository>();
            DependencyResolver.SetResolver(new CustomDependencyResolver(kernel));
        }
    }
}