using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public class CountryRepository : ICountryRepository
    {
        private IRepository<Country> countryRepository;

        public CountryRepository(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public List<Country> GetAll()
        {
            return countryRepository.GetAll().ToList();
        }

        public Country GetById(int id)
        {
            if (id == 0)
                return null;
            return countryRepository.GetById(id);
        }
    }
}