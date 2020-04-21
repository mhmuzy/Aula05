using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Entities
{
    public class Funcionario
    {

        public Guid IdFuncionario { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataAdmissao { get; set; }

        public decimal Salario { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }
    }
}
