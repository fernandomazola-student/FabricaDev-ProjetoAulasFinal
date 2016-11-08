using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiap.Exemplo02.MVC.Web.Models;

namespace Fiap.Exemplo02.MVC.Web.Repositories
{
    public class GrupoRepository : IGrupoRepository
    {
        private PortalContext _context;

        public GrupoRepository(PortalContext context)
        {
            _context = context;
        }

        public ICollection<Grupo> Listar()
        {
            return _context.Grupo.ToList();
        }
    }
}
