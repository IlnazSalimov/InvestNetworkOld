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
        // GET api/<controller>
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        [HttpGet]
        // GET api/<controller>/5
        public List<CountryDto> GetAll()
        {
            return _countryRepository.GetAll().Select(c => new CountryDto{
                CountryID = c.CountryID,
                CountryName = c.CountryName
            }).ToList();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}