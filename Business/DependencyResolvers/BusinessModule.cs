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
            
            serviceCollection.AddScoped<IPersonService, PersonManager>();
            serviceCollection.AddScoped<IAuthService,AuthManager>();
            serviceCollection.AddScoped<IApartmentService,ApartmentManager>();
            serviceCollection.AddScoped<IFlatTypeService,FlatTypeManager>();

            

        }
    }
}
