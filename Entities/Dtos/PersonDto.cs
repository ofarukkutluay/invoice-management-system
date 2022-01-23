using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstracts;

namespace Entities.Dtos
{
    public class PersonDto : IDto
    {
        public int Id { get; set; }
        public long CitizenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public bool IsActive { get; set; } 
    }
}
