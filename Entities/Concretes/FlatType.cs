using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class FlatType : IEntity
    {
        public int Id { get; set; }
        public int RoomCount { get; set; }
        public int LivingRoomCount { get; set; }

    }
}
