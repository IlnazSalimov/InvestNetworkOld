using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models.MetaData
{
    public class PartycipationUsersInfoMetaData
    {
        public int ProjectId { set; get; }
        public int PaymentId { set; get; }
        public string ProjectName { set; get; }
        public string ProjectStatus { set; get; }
        public decimal Sum { set; get; }
        public string PaymentStatus { set; get; }
        [DisplayFormat(ApplyFormatInEditMode = true,
               DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime PaymentDate { set; get; }
    }
}