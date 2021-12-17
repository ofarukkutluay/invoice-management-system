using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Resident : IEntity
    {
        public int PersonId { get; set; }
        public int HouseId { get; set; }
        public bool IsHirer { get; set; }
        public string CarPlate { get; set; }

    }
}
