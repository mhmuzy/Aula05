using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Presentation.Models; //camada de modelo

namespace Projeto.Presentation.Controlers
{
    [Authorize]
    [Area("AreaRestrita")]
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
                        DataAdmissao = Convert.ToDateTime(model.DataAdmissao),
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

        [HttpPost] //método para receber os dados enviados
        //pelo formulário
        public IActionResult Consulta(FuncionarioConsultaModel model, [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //executando a busca e armazenamento
                    //o resultado na classe model
                    model.Funcionarios = funcionarioRepository.Consultar(model.Nome, model.Ativo == 1);
                }
                catch (Exception e)
                {

                    TempData["MensagemErro"] = $"Erro ao consultar funcionário: {e.Message}.";
                }
            }

            return View(model);
        }

        //método para excluir o funcionário
        public IActionResult Exclusao(string id, [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                //converter o valor do id de string para Guid
                var idFuncionario = Guid.Parse(id);

                //buscar o funcionario pelo id..
                var funcionario = funcionarioRepository.ObterPorId(idFuncionario);

                //excluindo o funcionário
                funcionarioRepository.Excluir(funcionario);

                TempData["MensagemSucesso"] = $"funcionário {funcionario.Nome}, excluído com sucesso.";
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = e.Message;
            }

            return RedirectToAction("Consulta");
        }

        //método para reativar o funcionário
        public IActionResult Reativar(string id, [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            try
            {
                //converter o valor do id de string para Guid
                var idFuncionario = Guid.Parse(id);

                //reativando o funcionário
                funcionarioRepository.Reativar(idFuncionario);

                TempData["MensagemSucesso"] = "Funcionário reativado com sucesso.";
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = e.Message;
            }

            return RedirectToAction("Consulta");
        }

        //método para abrir a página de edição..
        public IActionResult Edicao(string id, [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            //criando um objeto da classe model de edição..
            var model = new FuncionarioEdicaoModel();

            try
            {
                //buscando o funcionário no banco de dados através do id..
                var funcionario = funcionarioRepository.ObterPorId(Guid.Parse(id));

                //carregando  os dados do funcionario na model
                model.IdFuncionario = funcionario.IdFuncionario.ToString();
                model.Nome = funcionario.Nome;
                model.Email = funcionario.Email;
                model.Salario = funcionario.Salario;
                model.DataAdmissao = funcionario.DataAdmissao;
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = e.Message;
            }

            //enviando a model para a página
            return View(model);
        }

        [HttpPost] //método recebe o submit post enviado pelo formulário
        public IActionResult Edicao(FuncionarioEdicaoModel model, [FromServices] IFuncionarioRepository funcionarioRepository)
        {
            //verificar se os campos do formulário estão corretos
            //em relação às regras de validação (DataAnnotations)
            if (ModelState.IsValid)
            {
                try
                {
                    //capturar os dados da model
                    //e instanciar um objeto Funcionario..
                    var funcionario = new Funcionario //classe de entidade
                    {
                        IdFuncionario = Guid.Parse(model.IdFuncionario),
                        Nome = model.Nome,
                        Email = model.Email,
                        Salario = Convert.ToDecimal(model.Salario),
                        DataAdmissao = Convert.ToDateTime(model.DataAdmissao),
                        DataUltimaAlteracao = DateTime.Now
                    };

                    //gravar na base de dados
                    funcionarioRepository.Alterar(funcionario);
                    TempData["MensagemSucesso"] = $"Funcionário {model.Nome}, atualizado com sucesso.";
                }
                catch (Exception e)
                {

                    TempData["MensagemErro"] = $"Erro ao atualizar funcionário: {e.Message}";
                }
            }

            //retornando para a página
            return View(model);
        }
    }
}