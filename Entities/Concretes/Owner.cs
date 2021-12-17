using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Owner : IEntity
    {
        public int PersonId { get; set; }
        public int HouseId { get; set; }
    }
}
