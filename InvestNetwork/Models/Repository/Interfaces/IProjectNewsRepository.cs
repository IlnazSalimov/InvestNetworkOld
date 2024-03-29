﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface IProjectNewsRepository
    {
        IQueryable<ProjectNew> GetAll();
        ProjectNew GetById(int id);
        int Insert(ProjectNew model);
        void Update(ProjectNew model);
        void Delete(ProjectNew model);
        void SaveChanges();
    }
}
