using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public class CityRepository : ICityRepository
    {
        private IRepository<City> cityRepository;

        public CityRepository(IRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public List<City> GetAll()
        {
            return cityRepository.GetAll().ToList();
        }

        public City GetById(int id)
        {
            if (id == 0)
                return null;
            return cityRepository.GetById(id);
        }
    }
}