using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface IProjectCommentRepository
    {
        List<ProjectComment> GetAll();
        ProjectComment GetById(int id);
        List<ProjectComment> GetByProjectId(int id);
        void Insert(ProjectComment model);
        void Update(ProjectComment model);
        void Delete(ProjectComment model);
        void SaveChanges();
    }
}
