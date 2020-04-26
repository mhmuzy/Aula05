using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Presentation.Models; //camada de modelo

namespace Projeto.Presentation.Controlers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost] //método recebe o submit post enviado pelo formulário
        public IActionResult Cadastro(FuncionarioCadastroModel model, [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            //verificar se os campos do formulário estão corretos
            //em relação às regras de validação (DataAnnotations)
            if (ModelState.IsValid)
            {
                try
                {
                    //capturar os dados da model
                    //e instanciar um objeto Funcionario
                    var funcionario = new Funcionario
                    {
                        IdFuncionario = Guid.NewGuid(),
                        Nome = model.Nome,
                        Email = model.Email,
                        Salario = Convert.ToDecimal(model.Salario),
                        DataAdmissao = DateTime.Now,
                        Ativo = true,
                        DataCriacao = DateTime.Now,
                        DataUltimaAlteracao = DateTime.Now
                    };

                    //gravar na base de dados
                    funcionarioRepository.Inserir(funcionario);

                    TempData["MensagemSucesso"] = $"Funcionário {model.Nome}, cadastrado com sucesso.";

                    ModelState.Clear(); //limpar os campos do formulário
                }
                catch (Exception e)
                {

                    TempData["MensagemErro"] = $"Erro ao cadastrar funionário: {e.Message}.";
                }
            }
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }
    }
}