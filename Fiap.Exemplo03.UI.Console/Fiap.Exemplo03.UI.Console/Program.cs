using Fiap.Exemplo03.UI.Console.DTOs_Models_;
using Fiap.Exemplo03.UI.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int resp = 9;

            while (resp != 2)
            {
                System.Console.WriteLine("Bem-vindo ao Cadastro!");
                System.Console.WriteLine("0-Cadastrar");
                System.Console.WriteLine("1-Listar");
                System.Console.WriteLine("2-Sair");
                switch (resp)
                {
                    case 0:
                        cadastrar();
                        break;

                }
            }

        }

        static void cadastrar()
        {
            AlunoRepository aluno = new AlunoRepository();
            System.Console.WriteLine("Digite um nome: ");
            var nome = System.Console.ReadLine();
            System.Console.WriteLine("Digite data de nascimento: ");
            var data = DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Possui bolsa? S/N");
            var resp = System.Console.ReadLine();
            var bolsa = false;
            if (resp.Equals("S"))
            {
                bolsa = true;
            }
            else if (resp.Equals("N"))
            {
                bolsa = false;
            }
            System.Console.WriteLine("Desconto");
            var desconto = double.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Qual é o código do grupo?");
            var idGrupo = int.Parse(System.Console.ReadLine());

            AlunoDTO alunoDTO = new AlunoDTO()
            {
                Nome = nome,
                DataNascimento = data,
                Bolsa = bolsa,
                Desconto = desconto,
                GrupoId = idGrupo
            };

            Uri uri = aluno.Cadastrar(alunoDTO);
            if (uri != null)
            {
                System.Console.WriteLine(uri.ToString());
            }
            else {
                System.Console.WriteLine("Aluno não cadastrado");
            }
        }

        private void Listar()
        {
            AlunoRepository aluno = new AlunoRepository();
            foreach (var item in aluno.Listar())
            {
                System.Console.WriteLine("Nome: " + item.Nome + "\n Data de Nascimento: " + item.DataNascimento);
            }

            System.Console.ReadLine();
        }
    }
}

