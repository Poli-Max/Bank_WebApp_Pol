using System;
using System.ComponentModel.DataAnnotations;

namespace Bank_App_Pol_V1.Models
{
	public class Dop
	{
        [Display(Name = "Сумма")]
        [Required(ErrorMessage = "Введите сумму")]
        public uint Amount{ get; set; }
	}
}

