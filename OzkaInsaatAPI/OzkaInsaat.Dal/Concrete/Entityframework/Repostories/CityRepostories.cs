using OzkaInsaat.Dal.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using OzkaInsaat.Entity.Models;

namespace OzkaInsaat.Dal.Concrete.Entityframework.Repostories
{
    public class CityRepostories : GenericRepository<City>, ICityRepostories
    {
        public CityRepostories(DbContext context) : base(context)
        {
        }
    }
}
