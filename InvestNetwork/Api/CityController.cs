using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InvestNetwork.Api
{
    public class CityController : ApiController
    {
        private readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            this._cityRepository = cityRepository;
        }

        public CityController() { }

        // GET api/city
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        // GET api/city/5
        public List<City> GetByRegionId(int regionId)
        {
            return _cityRepository.GetAll().Where(c => c.RegionID == regionId).ToList();
        }

        // POST api/city
        public void Post([FromBody]string value)
        {
        }

        // PUT api/city/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/city/5
        public void Delete(int id)
        {
        }
    }
}