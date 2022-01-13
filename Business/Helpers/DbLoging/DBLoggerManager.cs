using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;

namespace Business.Helpers.DbLoging
{
    public class DBLoggerManager : ILoggerService
    {
        private readonly ILogRepository _logRepository;

        public DBLoggerManager(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public void Log(string message)
        {
            _logRepository.Add(new Log{Message = message});
            _logRepository.SaveChanges();
        }
    }
}
