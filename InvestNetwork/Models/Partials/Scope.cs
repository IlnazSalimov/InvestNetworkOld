﻿using InvestNetwork.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public partial class Scope : IEntity
    {
        public int ID
        {
            get { return this.ScopeID; }
        }
    }
}