using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public class ProjectRepository : IProjectRepository
    {
        private IRepository<Project> projectRepository;

        public ProjectRepository(IRepository<Project> projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public List<Project> GetAll()
        {
            return projectRepository.GetAll().ToList();
        }

        public Project GetById(int id)
        {
            if (id == 0)
                return null;
            return projectRepository.GetById(id);
        }

        public void Insert(Project model)
        {
            if (model == null)
                throw new ArgumentNullException("project");
            projectRepository.Insert(model);
        }

        public void Update(Project model)
        {
            if (model == null)
                throw new ArgumentNullException("project");
            projectRepository.Update(model);

        }

        public void Delete(Project model)
        {
            if (model == null)
                throw new ArgumentNullException("project");
            projectRepository.Delete(model);
        }

        public void Save()
        {
            projectRepository.Save();
        }
    }
}