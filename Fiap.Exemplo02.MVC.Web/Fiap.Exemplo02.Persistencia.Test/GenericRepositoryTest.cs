using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Fiap.Exemplo02.MVC.Web.Repositories;
using Fiap.Exemplo02.Dominio.Models;
using System.Data.Entity.Infrastructure;

namespace Fiap.Exemplo02.Persistencia.Test
{
    [TestClass]
    public class GenericRepositoryTest
    {
        private GenericRepository<Aluno> _repository;
        private PortalContext _context;

        [TestInitialize]
        public void Inicializacao()
        {
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
                Grupo = new Grupo() { Nome = "Grupo Teste" }

            };

            //Cadastro o aluno
            _repository.Cadastrar(aluno);
            int r = _context.SaveChanges();
            //

            Assert.AreEqual(2, r); //Valida a quantidade de registros afetados no commit
            Assert.AreNotEqual(aluno.Id, 0); //Valida se foi gerada uma chave no banco de dados
        }

        //Teste de grupo obrigatório
        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void Cadastrar_Sem_Grupo_Exception()
        {
            var aluno = new Aluno
            {
                Nome = "Teste",
                Bolsa = false,
                DataNascimento = DateTime.Now,
                Desconto = 10
                
            };
            _repository.Cadastrar(aluno);
            _context.SaveChanges();
        }

     
    }
}
