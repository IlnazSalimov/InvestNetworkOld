﻿using InvestNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using AutoMapper;
using InvestNetwork.Application.Core;
using Ninject;
using Microsoft.Data.OData;

namespace InvestNetwork.Api
{
    public class ProjectController : EntitySetController<ProjectDTO, int>
    {
        private IProjectRepository _projectRepository { get; set; }
        private IMapper _modelMapper { get; set; }

        public ProjectController(IProjectRepository projectRepository, IMapper mapper)
        {
            this._projectRepository = projectRepository;
            this._modelMapper = mapper;
        }

        public override IQueryable<ProjectDTO> Get()
        {
            IQueryable<Project> projects = _projectRepository.GetAll();
            List<ProjectDTO> pr = new List<ProjectDTO>();
            foreach (Project p in projects)
            {
                pr.Add(_modelMapper.Map(p, typeof(Project), typeof(ProjectDTO)) as ProjectDTO);
            }
            return pr.AsQueryable();
        }

        protected override ProjectDTO GetEntityByKey(int key)
        {
            return _modelMapper.Map(_projectRepository.GetById(key), typeof(Project), typeof(ProjectDTO)) as ProjectDTO;
        }

        protected override ProjectDTO UpdateEntity(int key, ProjectDTO updateDto)
        {

            if (!_projectRepository.GetAll().Any(p => p.ID == key))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Project project = _modelMapper.Map(updateDto, typeof(ProjectDTO), typeof(Project)) as Project;
            _projectRepository.Update(project);
            _projectRepository.SaveChanges();

            return _modelMapper.Map(_projectRepository.GetById(key), typeof(Project), typeof(ProjectDTO)) as ProjectDTO;
        }

        public override void Delete([FromODataUri] int key)
        {
            Project project = _projectRepository.GetById(key);
            if (project == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _projectRepository.Delete(project);
            _projectRepository.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
