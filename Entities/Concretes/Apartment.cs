using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Apartment : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalFloors { get; set; }
    }
}
