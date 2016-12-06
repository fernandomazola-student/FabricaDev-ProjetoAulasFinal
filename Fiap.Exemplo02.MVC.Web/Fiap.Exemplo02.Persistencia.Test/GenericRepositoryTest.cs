using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Fiap.Exemplo02.MVC.Web.Repositories;
using Fiap.Exemplo02.Dominio.Models;

namespace Fiap.Exemplo02.Persistencia.Test
{
    public class GenericRepositoryTest
    {
        private GenericRepository<Aluno> _repository;
        private PortalContext _context;

        [TestInitialize]
        public void Inicializacao() {
            //Inicializar objetos
            _context = new PortalContext();
            _repository = new GenericRepository<Aluno>(_context);
        }

        [TestMethod]
        public void Cadastrar_Ok()
        {
            //Instanciar um aluno
            var aluno = new Aluno()
            {
                Nome = "Teste",
                Bolsa = false,
                DataNascimento = DateTime.Now,
                Desconto = 10,
                Grupo = new Grupo() { Nome = "Grupo Teste"}
                
            };

            //Cadastro o aluno
            _repository.Cadastrar(aluno);
            _context.SaveChanges();
            //
        }
    }
}
