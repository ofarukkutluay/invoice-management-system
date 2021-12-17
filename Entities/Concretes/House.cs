
using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class House : IEntity
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int FloorLocation { get; set; }
        public int DoorNumber { get; set; }
        public int FlatTypeId { get; set; }

    }
}
