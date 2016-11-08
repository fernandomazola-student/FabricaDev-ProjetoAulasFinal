using Fiap.Exemplo02.MVC.Web.Models;
using Fiap.Exemplo02.MVC.Web.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap.Exemplo02.MVC.Web.Controllers
{
    public class AlunoController : Controller
    {
        //private PortalContext _context = new PortalContext();
        private UnitOfWork _unit = new UnitOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            //Buscar todos os grupos cadastrados
            var lista = _unit.GrupoRepository.Listar();
            ViewBag.grupos = new SelectList(lista, "Id" , "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            _unit.AlunoRepository.Cadastrar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno cadastrado!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            //include -> busca o relacionamento (preenche o grupo que o aluno possui), faz o join
            var lista = _unit.AlunoRepository.Listar();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            //buscar o objeto (aluno) no banco
            var aluno = _unit.AlunoRepository.BuscarPorId(id);
            //manda o aluno para a view
            return View(aluno);
        }

        [HttpPost]
        public ActionResult Editar(Aluno aluno)
        {
            _unit.AlunoRepository.Atualizar(aluno);
            _unit.Salvar();
            TempData["msg"] = "Aluno atualizado";
            return RedirectToAction("Listar");
        }

        [HttpPost]
        public ActionResult Excluir(int alunoId)
        {
            _unit.AlunoRepository.Remover(alunoId);
            _unit.Salvar();
            TempData["msg"] = "Aluno excluido";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            //Busca o aluno no banco por parte do nome
            var lista = _unit.AlunoRepository.BuscarPor(a => a.Nome.Contains(nomeBusca));
            //Retorna para a view Listar com a lista
            return View("Listar",lista);
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }

    }
}