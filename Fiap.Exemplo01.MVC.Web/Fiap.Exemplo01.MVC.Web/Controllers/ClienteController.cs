using Fiap.Exemplo01.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo01.MVC.Web.Controllers
{
    public class ClienteController : Controller
    {
        private static List<Cliente> _lista = new List<Cliente>();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            var lista = new List<string>();
            lista.Add("Solteiro");
            lista.Add("Casado");
            lista.Add("Separado");

            ViewBag.estados = new SelectList(lista);

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {
            _lista.Add(cliente);
            TempData["msg"] = "Cliente Cadastrado";
            return RedirectToAction("Cadastrar");
        }

        public ActionResult Listar()
        {
            //ViewBag.lista = _lista; // 1º Opção
            return View(_lista); // 2º Opção
        }
    }
}