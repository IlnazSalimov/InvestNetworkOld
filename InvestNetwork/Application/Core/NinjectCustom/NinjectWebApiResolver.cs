﻿using System.Web.Http.Dependencies;
using Ninject;

namespace InvestNetwork.Ninject
{
    public class NinjectWebApiResolver : NinjectWebApiScope, IDependencyResolver
    {
        private IKernel kernel;
        public NinjectWebApiResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectWebApiScope(kernel.BeginBlock());
        }
    }
}