using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvestNetwork.Models
{
    public class UsersInfoMetaData
    {
        [Required]
        [Display(Name = "Фамилия")]
        public string Family { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string Middle { get; set; }

        [Required]
        [Display(Name = "Дата Рождения")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Гражданство")]
        public string Citizenship { get; set; }

        [Required]
        [Display(Name = "Серия паспорта")]
        public string PasportSerie { get; set; }

        [Required]
        [Display(Name = "Номер паспорта")]
        public string PasportNumber { get; set; }

        [Required]
        [Display(Name = "Дата выдачи паспорта")]
        public DateTime PasportIssueDate { get; set; }

        [Required]
        [Display(Name = "Кем выдан паспорт")]
        public string PasportIssuedBy { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

    }


}