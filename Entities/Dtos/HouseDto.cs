using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstracts;

namespace Entities.Dtos
{
    public class HouseDto : IDto
    {
        public int Id { get; set; }
        public string ApartmentName { get; set; }
        public int FloorLocation { get; set; }
        public int DoorNumber { get; set; }
        public string FlatType { get; set; }
    }
}
