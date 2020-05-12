using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Projeto.Presentation.Areas.AreaRestrita.Models;

namespace Projeto.Presentation.Controlers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(LoginModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (model.Email.Equals("sergio.coti@gmail.com") && model.Senha.Equals("123456")) //provisório
        //            {
        //                //criando a identificação de acesso..
        //                var identity = new ClaimsIdentity(
        //                    new []
        //                    {
        //                        new Claim(ClaimTypes.Name, model.Email),
        //                        //nome de usuário
        //                        new Claim(ClaimTypes.Role, "ADMINISTRADOR")
        //                        //perfil
        //                    },
        //                    CookieAuthenticationDefaults.AuthenticationScheme);

        //                //gravar em cookie
        //                var principal = new ClaimsPrincipal(identity);
        //                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

                
        //    }
        //}
    }
}