
using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Concretes
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public long CitizenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public OperationClaims OperationClaim { get; set; } = OperationClaims.User;
        public bool IsActive { get; set; } = true;
       
    }
}
