using System;
using Core.Entities.Abstracts;

namespace Core.CrossCuttingConcerns.Logging
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string Message { get; set; }
    }
}
