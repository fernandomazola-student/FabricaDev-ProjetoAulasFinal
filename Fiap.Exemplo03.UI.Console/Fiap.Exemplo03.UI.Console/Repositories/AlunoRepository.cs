using Fiap.Exemplo03.UI.Console.DTOs_Models_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exemplo03.UI.Console.Repositories
{
    class AlunoRepository
    {
        public Uri Cadastrar(AlunoDTO alunoDTO) {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58692/");
                HttpResponseMessage response = client.PostAsJsonAsync("api/Aluno", alunoDTO).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Headers.Location;
                }
                else {
                    return null;
                }
            }
        }

        public IEnumerable<AlunoDTO> Listar()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58692/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/Aluno").Result;
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<AlunoDTO> alunoDTO =
                    response.Content.ReadAsAsync<IEnumerable<AlunoDTO>>().Result;
                    return alunoDTO;
                }
                else
                {
                    return null;
                }
            }
        }






    }
}
