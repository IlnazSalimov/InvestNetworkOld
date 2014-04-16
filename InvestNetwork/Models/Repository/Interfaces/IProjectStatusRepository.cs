using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface IProjectStatusRepository
    {
        List<ProjectStatus> GetAll();
        ProjectStatus GetById(int id);
        ProjectStatus GetByCode(int code);
        void Insert(ProjectStatus model);
        void Update(ProjectStatus model);
        void Delete(ProjectStatus model);
        void Save();
    }
}
