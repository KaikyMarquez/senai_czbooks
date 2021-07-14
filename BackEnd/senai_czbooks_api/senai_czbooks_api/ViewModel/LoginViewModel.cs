using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_czbooks_api.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Preencher o Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencher a Senha")]
        public string Senha { get; set; }


    }
}
