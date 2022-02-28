using System;
using System.Collections.Generic;
using Infraestructura.Repository;
using Infraestructura.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Models;

namespace ApplicationCore.Services
{
    public class ServiceCasa : IServiceCasa
    {
        public void DeleteCasa(int id)
        {
            throw new NotImplementedException();
        }

        public Casa GetCasaByID(int id)
        {
            IRepositoryCasa repository = new RepositoryCasa();
            return repository.GetCasaByID(id);
        }

        public IEnumerable<Casa> GetCasas()
        {
            IRepositoryCasa repository = new RepositoryCasa();
            return repository.GetCasas();
        }

        public IEnumerable<Casa> GetTipoCasas(int idTCasa)
        {
            IRepositoryCasa repository = new RepositoryCasa();
            return repository.GetTipoCasa(idTCasa);
        }

        public Casa Save(Casa casa)
        {
            IRepositoryCasa repositoryCasa = new RepositoryCasa();
            return repositoryCasa.Save(casa);
        }
    }
}
