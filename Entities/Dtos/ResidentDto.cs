using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstracts;

namespace Entities.Dtos
{
    public class ResidentDto : IDto
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string House { get; set; }
        public bool IsHirer { get; set; }
        public string CarPlate { get; set; }
    }
}
