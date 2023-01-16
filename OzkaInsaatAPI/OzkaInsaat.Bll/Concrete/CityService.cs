using OzkaInsaat.Bll.Abstract;
using OzkaInsaat.Dal.Abstract;
using OzkaInsaat.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OzkaInsaat.Bll.Concrete
{
    public class CityService : GenericService<City>, ICityService
    {
        public readonly ICityRepostories cityRepostories;

        public CityService(IServiceProvider service) : base(service)
        {
            cityRepostories = service.GetService<ICityRepostories>();
        }
    }
}
