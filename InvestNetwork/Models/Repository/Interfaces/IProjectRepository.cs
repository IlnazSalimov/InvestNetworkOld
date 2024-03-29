﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Models
{
    public interface IProjectRepository
    {
        IQueryable<Project> GetAll();
        Project GetById(int id);
        int Insert(Project model);
        void Update(Project model);
        void Delete(Project model);
        void SaveChanges();
    }
}
