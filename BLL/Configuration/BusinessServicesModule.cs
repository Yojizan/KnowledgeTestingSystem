using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject.Modules;

namespace BLL.Configuration
{
    public class BusinessServicesModule : NinjectModule
    {
        private string _connectionString;

        public BusinessServicesModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
