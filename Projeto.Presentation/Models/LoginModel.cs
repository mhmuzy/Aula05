using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.Areas.AreaRestrita.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Por favor, informe o email.")]
        [EmailAddress(ErrorMessage = "Endereço de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }
    }
}
