using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Cadastro(FuncionarioCadastroModel model)
        {
            //verificar se os campos do formulário estão corretos
            //em relação às regras de validação (DataAnnotations)
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }
    }
}