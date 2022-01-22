using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Dtos;

namespace Business.Services.OutsideService.PaymentService
{
    public interface IPaymentService
    {
        Task<PaymentResult> PayOrder(PaymentOrder payOrder);
        Task<IDataResult<object>> CompanyAllPayOrder();

    }
}
