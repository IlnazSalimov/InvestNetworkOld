using InvestNetwork.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    [MetadataType(typeof(UsersInfoMetaData))]
    public partial class UsersInfo : IEntity
    {
        public int ID
        {
            get { return this.UsersInfoID; }
        }
    }
}