using InvestNetwork.Controllers;
using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace InvestNetwork.Api
{
    public class ScopeController : ApiController
    {
        private readonly IScopeRepository _scopeRepository;

        public ScopeController(IScopeRepository scopeRepository)
        {
            this._scopeRepository = scopeRepository;
        }

        public List<ScopeDto> GetAllScopes()
        {
            List<Scope> sc = _scopeRepository.GetAll();
            return _scopeRepository.GetAll().Select(s => new ScopeDto
            {
                ScopeID = s.ScopeID,
                Title = s.Title
            }).ToList();
        }
    }
}
