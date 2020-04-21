﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //biblioteca de validações

namespace Projeto.Presentation.Models
{
    public class FuncionarioCadastroModel
    {
        [MinLength(6, ErrorMessage = "Por favor, informe no mínimo {1} caractetres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe o endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do funcionário.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de admissão do funcionário.")]
        public DateTime? DataAdmissao { get; set; }

        [Range(1, 999999, ErrorMessage = "Por favor, informe um valor entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe o salário do funcionário.")]
        public decimal? Salario { get; set; }
    }
}
