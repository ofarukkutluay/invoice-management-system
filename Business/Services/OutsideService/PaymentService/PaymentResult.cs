using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.OutsideService.PaymentService
{
    public class PaymentResult
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
