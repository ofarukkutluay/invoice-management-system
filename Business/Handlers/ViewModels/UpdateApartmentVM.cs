using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.ViewModels
{
    public class UpdateApartmentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalFloors { get; set; }
    }
}
