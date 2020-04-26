using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações
using Projeto.Data.Entities;

namespace Projeto.Presentation.Models
{
    public class FuncionarioConsultaModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, selecione uma opção.")]
        public int? Ativo { get; set; }

        //listagem de funcionários
        //exibir na página o resultado da consulta no banco de dados
        public List<Funcionario> Funcionarios { get; set; }
    }
}
