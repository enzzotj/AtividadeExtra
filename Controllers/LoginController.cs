using System.Collections.Generic;
using AtividadeExtra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }

        Usuario usuarioModel = new Usuario();

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {

            List<string> UsuariosCSV = usuarioModel.LerTodasLinhasCSV("Database/Usuario.csv");

            var logado = UsuariosCSV.Find(
                x => x.Split(";")[0] == form["Email"] &&
                x.Split(";")[3] == form["Senha"]
            );

            if (logado != null)
            {
                HttpContext.Session.SetString("_UsuarioId", logado.Split(";")[5]);
                return LocalRedirect("~/HomeDados");
            }

            Mensagem = "Dados incorretos, tente novamente";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UsuarioId");
            return LocalRedirect("~/");
        }
    }
}