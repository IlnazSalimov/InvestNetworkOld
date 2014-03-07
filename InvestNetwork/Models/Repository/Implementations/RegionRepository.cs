using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public class RegionRepository:IRegionRepository
    {
        private IRepository<Region> regionRepository;

        public RegionRepository(IRepository<Region> regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        public List<Region> GetAll()
        {
            return regionRepository.GetAll().ToList();
        }

        public Region GetById(int id)
        {
            if (id == 0)
                return null;
            return regionRepository.GetById(id);
        }
    }
}