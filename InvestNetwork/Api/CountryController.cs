using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InvestNetwork.Api
{
    public class CountryController : ApiController
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }

        [HttpGet]
        public List<CountryDto> GetAll()
        {
            return _countryRepository.GetAll().Select(c => new CountryDto{
                CountryID = c.CountryID,
                CountryName = c.CountryName
            }).ToList();
        }
    }
}