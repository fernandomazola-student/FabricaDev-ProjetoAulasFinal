using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiap.Exemplo02.MVC.Web.Controllers;
using System.Web.Mvc;
using Fiap.Exemplo02.MVC.Web.ViewModels;

namespace Fiap.Exemplo02.MVC.Web.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Cadastrar_Get()
        {
            AlunoController controller = new AlunoController();
            var result = (ViewResult)controller.Cadastrar("teste");
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void Cadastrar_Post()
        {
            AlunoController controller = new AlunoController();
            var aluno = new AlunoViewModel
            {
                Nome = "Teste",
                Bolsa = false,
                DataNascimento = DateTime.Now,
                Desconto = 10, 
                GrupoId = 1
            };
            var result = (ViewResult)controller.Cadastrar(aluno);
            Assert.IsNotNull(result);
            var modelResultado = result.Model as AlunoViewModel;
            Assert.AreEqual(modelResultado.Mensagem,
            "Aluno Cadastrado com sucesso!");
        }
    }
}
