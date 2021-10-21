using Common.AutofacManager;
using Common.Repository;
using Entity.Common;
using Microsoft.Extensions.Logging;
using Service.IService.ILoggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Service.Loggers
{
   public class LoggerRepository : ILoggerService, IDependency
    {
        private readonly IRepository<Logger> _logger;
        public LoggerRepository(IRepository<Logger> logger)
        {
            this._logger = logger;
        }

        void ILoggerService.Add(Entity.Common.Logger entity)
        {
            //_logger.Add(new Logger() { 
            // Account= entity

            //})
        }
    }
}
