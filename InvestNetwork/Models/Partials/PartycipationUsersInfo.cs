using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InvestNetwork.Core;
using InvestNetwork.Models.MetaData;

namespace InvestNetwork.Models.Partials
{
    [MetadataType(typeof(PartycipationUsersInfoMetaData))]
    public partial class PartycipationUsersInfo : IEntity
    {
        public int ProjectId { set; get; }
        public int PaymentId { set; get; }
        public string ProjectName { set; get; }
        public string ProjectStatus { set; get; }
        public decimal Sum { set; get; }
        public string PaymentStatus { set; get; }

        public int ID
        {
           get {
               return 0;
           }
        }
    }
}