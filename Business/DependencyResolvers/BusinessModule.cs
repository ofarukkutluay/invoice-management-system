using Business.Services.Abstracts;
using Business.Services.Concretes;
using Core.Utilities.IoC;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business.Helpers.DbLoging;
using Business.Services.OutsideService.PaymentService;
using Core.CrossCuttingConcerns.Logging;

namespace Business.DependencyResolvers
{
    public class BusinessModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPersonRepository, EfPersonDal>();
            serviceCollection.AddScoped<IApartmentRepository,EfApartmentDal>();
            serviceCollection.AddScoped<IFlatTypeRepository,EfFlatTypeDal>();
            serviceCollection.AddScoped<IHouseRepository,EfHouseDal>();
            serviceCollection.AddScoped<IInvoiceRepository,EfInvoiceDal>();
            serviceCollection.AddScoped<IInvoiceTypeRespository,EfInvoiceTypeDal>();
            serviceCollection.AddScoped<IOwnerRepository,EfOwnerDal>();
            serviceCollection.AddScoped<IResidentRepository,EfResidentDal>();
            serviceCollection.AddScoped<ILogRepository, EfLogDal>();
            serviceCollection.AddScoped<IPayInvoicePersonRepository, EfPayInvoicePersonDal>();
            
            serviceCollection.AddScoped<IPersonService, PersonManager>();
            serviceCollection.AddScoped<IAuthService,AuthManager>();
            serviceCollection.AddScoped<IApartmentService,ApartmentManager>();
            serviceCollection.AddScoped<IFlatTypeService,FlatTypeManager>();
            serviceCollection.AddScoped<IHouseService, HouseManager>();
            serviceCollection.AddScoped<IInvoiceTypeService, InvoiceTypeManager>();
            serviceCollection.AddScoped<IOwnerService, OwnerManager>();
            serviceCollection.AddScoped<IResidentService, ResidentManager>();
            serviceCollection.AddScoped<IInvoiceService, InvoiceManager>();
            serviceCollection.AddScoped<IPayInvoicePersonService,PayInvoicePersonManager>();

            serviceCollection.AddScoped<IPaymentService,PaymentManager>();


        }
    }
}
