using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_App_Pol_V1.Models
{
	public class User_Bank
    {
        [Display(Name ="ID")]
        [Required(ErrorMessage = "Введите ID")]
        public uint ID { get; set; }

        public string Name { get; set; }

        public uint Balance { get; set; }

        public string Currency { get; set; } = "RUB";

    }
}

